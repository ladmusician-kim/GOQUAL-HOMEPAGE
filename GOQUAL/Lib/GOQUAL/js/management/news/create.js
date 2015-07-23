var app = angular.module('myApp', ['summernote']).
       controller('AdviseCtrl', function ($scope) {
           //headerAPI(6);
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

           var lang = $('#Lang').val();

           // ����
           $scope.createAdvise = function () {
               getJson('/Contact/CreateAdvise', { title: $scope.title, content: $('.note-editable').html(), password: $scope.password },
                   function (data) {
                       if (data > 0) {
                           makalu_toast('���������� ����Ǿ����ϴ�.', 'makalu-success', 'success');
                           window.location.href = '/Contact/Index?lang=' + lang;
                       } else {
                           makalu_toast('������ �߻��߽��ϴ�.', 'makalu-error', 'error');
                       }
                   },
                   function (arg) {
                       makalu_toast('������ �߻��߽��ϴ�.', 'makalu-error', 'error');
                   }, $scope);
           }
       })