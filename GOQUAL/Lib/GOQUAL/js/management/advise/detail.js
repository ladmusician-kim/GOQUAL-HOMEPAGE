var app = angular.module('myApp', ['myApp.filters', 'ui.bootstrap']).
        controller('AdviseCtrl', function ($scope, $document, $sce, $modal, $log) {
            //headerAPI(6);
            $scope.comment = {
                page: 1,
                perPage: 10,
                isMore: false,
                items: [],
                totalCount: 0
            };
            $scope.advise = {};
            $scope.adviseImageCount = 0;
            var windowWidth = $(window).width();

            // 조언 들고오기
            getEachAdvise();

            // 댓글로 이동
            $scope.goComment = function () {
                var comment = angular.element(document.getElementById('comment'));
                $document.scrollTo(comment, 0, 1000);
            }

            // 댓글 더보기
            $scope.moreComment = function () {
                $scope.comment.perPage += 10;
                getComments($scope.comment.page, $scope.comment.perPage);
            }

            // 댓글 등록
            $scope.registComment = function () {
                if (!$scope.comment.name || $scope.comment.name === "") {
                    alert('이름을 입력해주세요');
                } else if (!$scope.comment.password || $scope.comment.password === "") {
                    alert('비밀번호를 입력해주세요');
                } else if (!$scope.comment.comment || $scope.comment.comment === "") {
                    alert('멘트 입력해주세요');
                }
                else {
                    registComment();
                }
            }

            // 댓글 삭제
            $scope.deleteComment = function (comment) {
                getJson('/Contact/DeleteComment', { id: comment.Id, password: comment.confirmPass },
                    function (data) {
                        if (data == 1) {
                            alert('댓글이 삭제되었습니다');
                            getEachAdvise();
                        } else if (data == 2) {
                            alert('비밀번호가 틀렸습니다');
                            comment.confirmPass = "";
                        } else {
                            alert('오류가 발생했습니다');
                            comment.confirmPass = "";
                            comment.canDelete = false;
                        }
                    },
                    function (arg) {
                    }, $scope);
            }

            // 댓글 수정
            $scope.editComment = function (comment) {
                if (comment.Password === comment.confirmPass) {
                    $scope.pushReply('lg', comment, 2);
                } else {
                    alert('비밀번호가 틀렸습니다.');
                    //comment.editConfirmPass = "";
                }
            }

            // 덧글 등록
            $scope.pushReply = function (size, comment, type) {
                var modalInstance = $modal.open({
                    templateUrl: 'myModalContent.html',
                    controller: ModalInstanceCtrl,
                    size: size,
                    resolve: {
                        item: function () {
                            return comment;
                        },
                        type: function () {
                            return type;
                        }
                    }
                });

                modalInstance.result.then(function (reply) {
                    if (reply.type == 1) {    // 덧글 등록
                        registCommentInComment(reply, comment);
                    } else if (reply.type == 2) {     // 댓글 수정
                        editCommentInComment(reply);
                    }

                });
            }




            // 댓글 등록 함수
            function registComment() {
                getJson('/Contact/RegistComment', { name: $scope.comment.name, comment: $scope.comment.comment, password: $scope.comment.password, adviseId: $scope.advise.Id },
                    function (data) {
                        alert('소중한 의견 감사합니다');
                        //$scope.comment.items.push(data);
                        //$scope.advise.Comments.push(data);

                        $scope.comment.name = "";
                        $scope.comment.comment = "";
                        $scope.comment.password = "";
                        getEachAdvise();
                    },
                    function (arg) {
                        alert('오류가 발생했습니다');
                        location.reload();
                    }, $scope);
            }

            // 댓글 수정 함수
            function editCommentInComment(reply) {
                getJson('/Contact/EditComment', { name: reply.name, comment: reply.comment, id: reply.id },
                        function (data) {
                            alert('수정되었습니다');

                            getEachAdvise();
                        },
                        function (arg) {
                            alert('오류가 발생했습니다');
                            location.reload();
                        }, $scope);
            }

            // 덧글 등록 함수 
            function registCommentInComment(reply, comment) {
                getJson('/Contact/RegistComment', { name: reply.name, comment: reply.comment, adviseId: $scope.advise.Id, commentId: comment.Id },
                       function (data) {
                           alert('소중한 의견 감사합니다');

                           getEachAdvise();
                       },
                       function (arg) {
                           alert('오류가 발생했습니다');
                           location.reload();
                       }, $scope);
            }

            // 더보기 handler
            function updateMoreComment() {
                console.log($scope.advise.Comments);
                if ($scope.advise.Comments && $scope.advise.Comments.length == $scope.comment.totalCount) {
                    $scope.comment.isMore = false;
                } else if (!$scope.advise.Comment) {
                    $scope.comment.isMore = false;
                } else {
                    $scope.comment.isMore = true;
                }
            }

            // 조언 글에 있는 이미지 크기 수정
            function contentImageHandler() {
                $scope.$watch('advise.Content', function (newValue, oldValue) {
                    if (newValue) {
                        _.each($('.content_body img'), function (item) {
                            var splitedStyle = $(item).attr('style').split(":");
                            if (_.contains(splitedStyle, "width")) {
                                var widthFullString = jQuery.trim(splitedStyle[_.indexOf(splitedStyle, "width") + 1]);
                                var parseintedWidth = parseInt(widthFullString.substring(0, widthFullString.length - 3));

                                if (parseintedWidth > windowWidth) {
                                    $(item).attr('style', 'width: 100%');
                                }
                            }
                        });
                    }
                });
            }

            // 댓글 가져오기
            function getComments(page, perPage) {
                getJson('/Contact/GetComments', { adviseId: $scope.advise.Id, page: $scope.comment.page, perPage: $scope.comment.perPage },
                    function (data) {
                        $scope.comment.items = _.sortBy(data.Comments, function (item) { return item.Id; });
                        $scope.comment.totalCount = data.TotalCount;
                        updateMoreComment();
                    },
                    function (arg) {
                    }, $scope);
            }

            // 조언 글 가져오기
            function getEachAdvise() {
                getJson('/Contact/GetEachAdvise', { id: $('#Id').val() },
                    function (data) {
                        $scope.advise = data;
                        $scope.advise.Content = $sce.trustAsHtml(data.Content);

                        // 댓글 가져오기
                        getComments($scope.comment.page, $scope.comment.perPage);
                        contentImageHandler();
                    },
                    function (arg) {
                        alert('오류가 발생했습니다');
                    }, $scope);
            }

        });

// 덧글을 처리하는 controller
var ModalInstanceCtrl = function ($scope, $modalInstance, item, type) {
    $scope.comment = item;

    if (type == 1) { // 덧글 등록
        $scope.reply = {
            name: "(주) 고퀄",
            comment: ""
        };
        $scope.reply.type = 1;
    } else if (type == 2) { // 댓글 수정 
        $scope.reply = {};
        $scope.reply.type = 2;
        $scope.reply.id = $scope.comment.Id;
        $scope.reply.name = $scope.comment.Name;
        $scope.reply.comment = $scope.comment.Comment;
    }

    $scope.ok = function () {
        if (!$scope.reply.name || $scope.reply.name === "" || (jQuery.trim($scope.reply.name)).length == 0) {
            alert('이름을 입력해주세요');
        } else if (!$scope.reply.comment || $scope.reply.comment === "" || (jQuery.trim($scope.reply.comment)).length == 0) {
            alert('멘트를 입력해주세요');
        }
        $modalInstance.close($scope.reply);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};