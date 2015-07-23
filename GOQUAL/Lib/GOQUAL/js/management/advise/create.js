var app = angular.module('myApp', ['summernote']).
        controller('AdviseCtrl', function ($scope) {
            $scope.options = {
                height: 500,
                focus: true,
                toolbar: [
                  ['style', ['bold', 'fontname', 'underline', 'clear']],
                  ['fontsize', ['fontsize']],
                  ['color', ['color']],
                  ['para', ['paragraph']],
                  ['height', ['height']],
                  ['insert', ['picture', 'table']]
                ]
            };

            // 저장
            $scope.createAdvise = function () {
                getJson('/Contact/CreateAdvise', { title: $scope.title, content: $('.note-editable').html(), password: $scope.password },
                    function (data) {
                        if (data > 0) {
                            makalu_toast('정상적으로 저장되었습니다.', 'makalu-success', 'success');
                            window.location.href = "/Management/Advise";

                        } else {
                            makalu_toast('오류가 발생했습니다.', 'makalu-error', 'error');
                        }
                    },
                    function (arg) {
                        makalu_toast('오류가 발생했습니다.', 'makalu-error', 'error');
                    }, $scope);
            }
        })