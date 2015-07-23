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

           // 저장
           $scope.createAdvise = function () {
               getJson('/Contact/CreateAdvise', { title: $scope.title, content: $('.note-editable').html(), password: $scope.password },
                   function (data) {
                       if (data > 0) {
                           alert('정상적으로 저장되었습니다.');
                           window.location.href = '/Contact/Mobile?lang=' + lang;
                       } else {
                           alert('오류가 발생했습니다.');
                       }
                   },
                   function (arg) {
                       alert('오류가 발생했습니다.');
                   }, $scope);
           }
       })