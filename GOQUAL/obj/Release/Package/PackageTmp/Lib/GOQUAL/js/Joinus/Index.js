var app = angular.module('myApp', ['myApp.filters']).
controller('JoinCtrl', function ($scope) {
    //headerAPI(5);
    var windowHeight = $(window).height();
    $('.goqual_table_row').css('height', windowHeight - 220);

    $scope.join = function () {
        var lang = $('#Lang').val();
        console.log(lang);
        if (lang == 0) {
            makalu_toast('죄송합니다 준비중입니다...', 'comment', 'success');
        } else {
            makalu_toast("I'm sorry. We are preparing...", 'comment', 'success');
        }
    }

    // 언어 이동
    $scope.lang = $("#Lang").val();
    $scope.changeLang_eng = function () {
        if ($scope.lang == 0) {
            window.location.href = "/Joinus/Index?lang=1";
        }
    }

    $scope.changeLang_ko = function () {
        if ($scope.lang == 1) {
            window.location.href = "/Joinus/Index?lang=0";
        }
    }
});