var app = angular.module('myApp', ['myApp.filters']).
controller('CompanyCtrl', function ($scope) {
    $scope.lang = $("#Lang").val();

    // 언어 이동
    $scope.changeLang_eng = function () {
        if ($scope.lang == 0) {
            window.location.href = "/Company/Ko?lang=1";
        }
    }

    $scope.changeLang_ko = function () {
        if ($scope.lang == 1) {
            window.location.href = "/Company/Eng?lang=0";
        }
    }

    $(document).ready(function () {
        $('#fullpage').fullpage({
            sectionsColor: ['#FFF', '#FFF', '#FFF', '#FFF', '#FFF', '#FFF'],
            anchors: ['Company', 'Company Introduction', 'Business field', 'Our team', 'Product_4', 'History'],
            navigation: true,
            navigationPosition: 'right',
            navigationTooltips: ['Company', 'Company Introduction', 'Business field', 'Our team', 'Product_4', 'History']
        });
    });
});






