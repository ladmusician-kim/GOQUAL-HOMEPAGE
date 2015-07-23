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

            // ����
            $scope.createAdvise = function () {
                getJson('/Contact/CreateAdvise', { title: $scope.title, content: $('.note-editable').html(), password: $scope.password },
                    function (data) {
                        if (data > 0) {
                            makalu_toast('���������� ����Ǿ����ϴ�.', 'makalu-success', 'success');
                            window.location.href = "/Management/Advise";

                        } else {
                            makalu_toast('������ �߻��߽��ϴ�.', 'makalu-error', 'error');
                        }
                    },
                    function (arg) {
                        makalu_toast('������ �߻��߽��ϴ�.', 'makalu-error', 'error');
                    }, $scope);
            }
        })