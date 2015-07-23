var app = angular.module('myApp', ['myApp.filters']).
controller('ProductCtrl', function ($scope) {
    $scope.lang = $("#Lang").val();

    // 언어 이동
    $scope.changeLang_eng = function () {
        if ($scope.lang == 0) {
            window.location.href = "/Product/Ko?lang=1";
        }
    }

    $scope.changeLang_ko = function () {
        if ($scope.lang == 1) {
            window.location.href = "/Product/Eng?lang=0";
        }
    }

    $(document).ready(function () {
        $('#fullpage').fullpage({
            sectionsColor: ['#FFF', '#FFF', '#FFF', '#FFF', '#FFF'],
            anchors: ['1', '2', '3', '4', '5'],
            navigation: true,
            navigationPosition: 'right',
            navigationTooltips: ['Product_1', 'Product_2', 'Product_3', 'Product_4', 'Product_5']
        });
    });
});






