var app = angular.module('myApp', ['myApp.filters']).
controller('HomeCtrl', function ($scope) {
    $scope.lang = $("#Lang").val();

    // 블로그 이동
    $scope.goBlogs = function () {
        window.location.href = "/Info/Index?lang=" + $scope.lang;
    }

    // 언어 이동
    $scope.changeLang_eng = function () {
        if ($scope.lang == 0) {
            window.location.href = "/Home/Index?lang=1";
        }
    }

    $scope.changeLang_ko = function () {
        if ($scope.lang == 1) {
            window.location.href = "/Home/Index?lang=0";
        }
    }
});