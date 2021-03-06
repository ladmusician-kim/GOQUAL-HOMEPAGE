﻿var app = angular.module('myApp', ['myApp.filters', 'duScroll', 'ui.bootstrap']).
        controller('BlogCtrl', function ($scope, $document, $sce, $modal, $log) {
            //headerAPI(7);
            $scope.comment = {
                page: 1,
                perPage: 10,
                isMore: false,
                items: [],
                totalCount: 0
            };
            $scope.blog = {};
            $scope.blogImageCount = 0;
            var windowWidth = $(window).width();

            // 블로그 들고오기
            getEachBlog();

            // 댓글로 이동
            $scope.goComment = function () {GetEachBlog
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
                    makalu_toast('이름을 입력해주세요', 'comment', 'error');
                } else if (!$scope.comment.password || $scope.comment.password === "") {
                    makalu_toast('비밀번호를 입력해주세요', 'comment', 'error');
                } else if (!$scope.comment.comment || $scope.comment.comment === "") {
                    makalu_toast('멘트 입력해주세요', 'comment', 'error');
                }
                else {
                    registComment();
                }
            }

            // 댓글 삭제
            $scope.deleteComment = function (comment) {
                getJson('/Info/DeleteComment', { id: comment.Id, password: comment.confirmPass },
                    function (data) {
                        if (data == 1) {
                            makalu_toast('댓글이 삭제되었습니다', 'comment', 'success');
                            //$scope.comment.items = _.filter($scope.comment.items, function (item) { return item.Id != comment.Id; });
                            getEachBlog();
                        } else if (data == 2) {
                            makalu_toast('비밀번호가 틀렸습니다', 'comment', 'error');
                            comment.confirmPass = "";
                        } else {
                            makalu_toast('오류가 발생했습니다', 'comment', 'error');
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
                    makalu_toast('비밀번호가 틀렸습니다.', 'comment', 'error');
                    //comment.editConfirmPass = "";
                }
            }

            // 블로그 글 가져오기
            function getEachBlog() {
                getJson('/Info/GetEachBlog', { id: $('#Id').val() },
                    function (data) {
                        $scope.blog = data;
                        $scope.blog.Content = $sce.trustAsHtml(data.Content);

                        // 댓글 가져오기
                        getComments($scope.comment.page, $scope.comment.perPage);
                        contentImageHandler();
                    },
                    function (arg) {
                        makalu_toast('오류가 발생했습니다', 'comment', 'error');
                    }, $scope);
            }

            // 블로그 글에 있는 이미지 크기 수정
            function contentImageHandler() {
                $scope.$watch('blog.Content', function (newValue, oldValue) {
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

            function getComments(page, perPage) {
                getJson('/Info/GetComments', { blogId: $scope.blog.Id, page: $scope.comment.page, perPage: $scope.comment.perPage },
                    function (data) {
                        $scope.comment.items = _.sortBy(data.Comments, function (item) { return item.Id; });
                        $scope.comment.totalCount = data.TotalCount;
                        updateMoreComment();
                    },
                    function (arg) {
                    }, $scope);
            }

            function updateMoreComment() {
                if ($scope.blog.Comments && $scope.blog.Comments.length == $scope.comment.totalCount) {
                    $scope.comment.isMore = false;
                } else if (!$scope.blog.Comments) {
                    $scope.comment.isMore = false;
                } else {
                    $scope.comment.isMore = true;
                }
            }

            // 댓글 등록 함수
            function registComment() {
                getJson('/Info/RegistComment', { name: $scope.comment.name, comment: $scope.comment.comment, password: $scope.comment.password, blogId: $scope.blog.Id },
                    function (data) {
                        makalu_toast('소중한 의견 감사합니다', 'comment', 'success');
                        //$scope.comment.items.push(data);
                        //$scope.blog.Comments.push(data);

                        $scope.comment.name = "";
                        $scope.comment.comment = "";
                        $scope.comment.password = "";
                        getEachBlog();
                    },
                    function (arg) {
                        makalu_toast('오류가 발생했습니다', 'comment', 'error');
                        location.reload();
                    }, $scope);
            }

            // 덧글 등록 함수 
            function registCommentInComment(reply, comment) {
                getJson('/Info/RegistComment', { name: reply.name, comment: reply.comment, blogId: $scope.blog.Id, commentId: comment.Id },
                       function (data) {
                           makalu_toast('소중한 의견 감사합니다', 'comment', 'success');

                           getEachBlog();
                       },
                       function (arg) {
                           makalu_toast('오류가 발생했습니다', 'comment', 'error');
                           location.reload();
                       }, $scope);
            }

            // 댓글 수정 함수
            function editCommentInComment(reply) {
                getJson('/Info/EditComment', { name: reply.name, comment: reply.comment, id: reply.id },
                        function (data) {
                            makalu_toast('수정되었습니다', 'comment', 'success');

                            getEachBlog();
                        },
                        function (arg) {
                            makalu_toast('오류가 발생했습니다', 'comment', 'error');
                            location.reload();
                        }, $scope);
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
            makalu_toast('이름을 입력해주세요', 'comment', 'error');
        } else if (!$scope.reply.comment || $scope.reply.comment === "" || (jQuery.trim($scope.reply.comment)).length == 0) {
            makalu_toast('멘트를 입력해주세요', 'comment', 'error');
        }
        $modalInstance.close($scope.reply);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};