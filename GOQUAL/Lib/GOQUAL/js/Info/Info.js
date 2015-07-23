var app = angular.module('myApp', ['myApp.filters', 'ngTable', 'ui.bootstrap']).
        controller('InfoCtrl', function ($scope, $timeout, ngTableParams) {
            $scope.isLoading = true;

            // wrapper height
            var colum = parseInt($('.isotopeItem').length / 3);
            if (colum == 0) { colum = 1; }

            var wrapperHeight = 411 * colum + 'px'

            $('.isotopeWrapper').css('height', wrapperHeight);

            $(document).ready(function () {
                //headerAPI(7);

                $scope.page = 1;
                $scope.perPage = 6;

                $scope.blogs = [];
                $scope.totalCount = 0;
                $scope.isMoreShow = true;



                getTotalCount();
                getBlogs($scope.page, $scope.perPage);

                $scope.moreBlogs = function () {
                    getBlogs($scope.page, $scope.perPage + 6);
                }
            });

            function getBlogs(page, perPage) {
                getJson('/Info/GetBlogs', { page: page, perPage: perPage },
                function (data) {
                    $scope.blogs = [];
                    $scope.blogs = data;
                    $scope.isLoading = false;

                    isMoreShow();
                },
                function (arg) {
                }, $scope);
            }

            function getTotalCount() {
                getJson('/Info/GetTotalBlogCount', {},
                    function (data) {
                        $scope.totalCount = data;
                    },
                    function (arg) {
                    }, $scope);
            }

            function isMoreShow() {
                if ($scope.blogs.length == $scope.totalCount) {
                    $scope.isMoreShow = false;
                } else {
                    $scope.isMoreShow = true;
                }
            }



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
                            url: '/Info/GetNews',
                            type: 'POST',
                            contentType: 'application/json',
                            data: JSON.stringify(params.url()),
                            dataType: 'json',
                            success: function (data) {
                                $scope.$apply(function () {
                                    $scope.news.page = $scope.tableParams.page();
                                    $scope.news.perPage = $scope.tableParams.count();
                                    $scope.news.items = data.Items;

                                    _.each($scope.news.items, function (item) {
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

            // 언어 이동
            $scope.lang = $("#Lang").val();
            $scope.changeLang_eng = function () {
                if ($scope.lang == 0) {
                    window.location.href = "/Info/Index?lang=1";
                }
            }

            $scope.changeLang_ko = function () {
                if ($scope.lang == 1) {
                    window.location.href = "/Info/Index?lang=0";
                }
            }
        });