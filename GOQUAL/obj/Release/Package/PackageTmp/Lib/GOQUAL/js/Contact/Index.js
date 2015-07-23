var link = document.location.href;
$(document).ready(function () {
    var windowWidth = $(window).width();
    var map_height = 400;
    var isMobile = $('#isMobile').val();
    if (isMobile && isMobile == 1) {
        map_height = 220;
    }
    var mapWidth = $('#about').width();
    var oPoint = new nhn.api.map.LatLng(35.872859, 128.624890); //LatLng 값이 y, x 좌표
    nhn.api.map.setDefaultPoint('LatLng');
    oMap = new nhn.api.map.Map('makaluMap', { //표시될 div의 id 입니다.
        point: oPoint,
        zoom: 11, //기본 지도 줌 크기
        enableWheelZoom: true,
        enableDragPan: true,
        enableDblClickZoom: true,
        mapMode: 0,
        activateTrafficMap: false,
        activateBicycleMap: false,
        minMaxLevel: [1, 14],
        size: new nhn.api.map.Size(mapWidth, map_height) //표시될 지도 크기
    });

    //아래는 위에서 지정한 좌표에 마커를 표시하는 소스 입니다.
    var oSize = new nhn.api.map.Size(28, 37);
    var oOffset = new nhn.api.map.Size(14, 37);
    var oIcon = new nhn.api.map.Icon('http://static.naver.com/maps2/icons/pin_spot2.png', oSize, oOffset);
    //icon 이미지를 바꿔서 사용할 수 있습니다.
    var oMarker = new nhn.api.map.Marker(oIcon, { title: '타이틀' });
    oMarker.setPoint(oPoint);
    oMap.addOverlay(oMarker);
    //아래는 사이드에 줌 컨트롤을 추가하는 소스 입니다.
    var mapZoom = new nhn.api.map.ZoomControl(); // - 줌 컨트롤 선언
    mapZoom.setPosition({ left: 20, bottom: 40 }); // - 줌 컨트롤 위치 지정
    oMap.addControl(mapZoom); // - 줌 컨트롤 추가.
});

var app = angular.module('myApp', ['myApp.filters', 'ngTable', 'ui.bootstrap']).
       controller('ContactCtrl', function ($scope, $timeout, ngTableParams) {
           //headerAPI(6);

           var windowHeight = $(window).height();
           $('.adviseBody').css('min-height', windowHeight - 330);

           $scope.advise = {
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
                           url: '/Contact/GetAdvise',
                           type: 'POST',
                           contentType: 'application/json',
                           data: JSON.stringify(params.url()),
                           dataType: 'json',
                           success: function (data) {
                               $scope.$apply(function () {
                                   $scope.advise.page = $scope.tableParams.page();
                                   $scope.advise.perPage = $scope.tableParams.count();
                                   $scope.advise.items = data.Items;

                                   _.each($scope.advise.items, function (item) {
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

           // email 보내기
           $scope.sendMessage = function () {
               getJson('/Contact/SendMessage', { name: $scope.name, email: $scope.email, phone: $scope.phone, content: $scope.content },
                   function (data) {
                       makalu_toast($scope.name + '님 소중한 의견 감사합니다. 답변이 필요한 문의일 경우 빠른 시일내로 연락을 드리겠습니다.',
                           'makalu-success',
                           'success');
                   },
                   function (arg) {
                       makalu_toast($scope.name + '님께서 문의하신 내용이 프로그램 문제로 인해 발송되지 않았습니다. gq@goqual.com으로 문의해주세요',
                           'makalu-error',
                           'error');
                   }, $scope);
           }

           // detail advise
           $scope.detailAdvise = function (item) {
               if (item.password == "") {
                   makalu_toast('비밀번호를 입력해주세요', 'makalu-error', 'error');
               } else {
                   getJson('/Contact/ConfirmPassword', { id: item.Id, password: item.password },
                   function (data) {
                       if (data > 0) {
                           window.location.href = "/Contact/Detail?id=" + item.Id;
                       } else {
                           makalu_toast('비밀번호를 잘못입력하셨습니다', 'makalu-error', 'error');
                       }
                   },
                   function (arg) {
                       makalu_toast('오류가 발생했습니다', 'makalu-error', 'error');
                   }, $scope);
               }
           }

           // 언어 이동
           $scope.lang = $("#Lang").val();
           $scope.changeLang_eng = function () {
               if ($scope.lang == 0) {
                   window.location.href = "/Contact/Index?lang=1";
               }
           }

           $scope.changeLang_ko = function () {
               if ($scope.lang == 1) {
                   window.location.href = "/Contact/Index?lang=0";
               }
           }
       });