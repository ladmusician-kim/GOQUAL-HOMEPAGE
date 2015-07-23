var app = angular.module('myApp', ['myApp.filters', 'ngTable', 'ui.bootstrap']).
        controller('BlogCtrl', function ($scope, $timeout, ngTableParams) {
            // news
            $scope.news = {
                items: [],
                page: 1,
                perPage: 10
            }

            $scope.resetCacheData = {};
            $scope.tableParams = new ngTableParams({
                page: 1,            // show first page
                count: 10,          // count per page
                sorting: {
                    Id: 'desc',     // initial sorting
                },
                filter: {
                },
            }, {
                total: 0,
                getData: function ($defer, params) {
                    tableResetPageWhenIfNeeded($scope.resetCacheData, $scope.tableParams, function () {

                        $.ajax({
                            url: '/Info/GetBlogs_ngtable',
                            type: 'POST',
                            contentType: 'application/json',
                            data: JSON.stringify(params.url()),
                            dataType: 'json',
                            success: function (data) {
                                $scope.$apply(function () {
                                    $scope.blog.page = $scope.tableParams.page();
                                    $scope.blog.perPage = $scope.tableParams.count();
                                    $scope.blog.items = data.Items;

                                    _.each($scope.blog.items, function (item) {
                                        item.$selected = false;
                                    });

                                    // update table params
                                    params.total(data.RowCount);
                                    $scope.totalLength = data.RowCount;
                                    // set new datax
                                    $defer.resolve(data.Items);
                                })
                            }
                        })
                    });
                }
            });
        });