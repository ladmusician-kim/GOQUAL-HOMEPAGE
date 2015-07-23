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

            // ���� ������
            getEachAdvise();

            // ��۷� �̵�
            $scope.goComment = function () {
                var comment = angular.element(document.getElementById('comment'));
                $document.scrollTo(comment, 0, 1000);
            }

            // ��� ������
            $scope.moreComment = function () {
                $scope.comment.perPage += 10;
                getComments($scope.comment.page, $scope.comment.perPage);
            }

            // ��� ���
            $scope.registComment = function () {
                if (!$scope.comment.name || $scope.comment.name === "") {
                    alert('�̸��� �Է����ּ���');
                } else if (!$scope.comment.password || $scope.comment.password === "") {
                    alert('��й�ȣ�� �Է����ּ���');
                } else if (!$scope.comment.comment || $scope.comment.comment === "") {
                    alert('��Ʈ �Է����ּ���');
                }
                else {
                    registComment();
                }
            }

            // ��� ����
            $scope.deleteComment = function (comment) {
                getJson('/Contact/DeleteComment', { id: comment.Id, password: comment.confirmPass },
                    function (data) {
                        if (data == 1) {
                            alert('����� �����Ǿ����ϴ�');
                            getEachAdvise();
                        } else if (data == 2) {
                            alert('��й�ȣ�� Ʋ�Ƚ��ϴ�');
                            comment.confirmPass = "";
                        } else {
                            alert('������ �߻��߽��ϴ�');
                            comment.confirmPass = "";
                            comment.canDelete = false;
                        }
                    },
                    function (arg) {
                    }, $scope);
            }

            // ��� ����
            $scope.editComment = function (comment) {
                if (comment.Password === comment.confirmPass) {
                    $scope.pushReply('lg', comment, 2);
                } else {
                    alert('��й�ȣ�� Ʋ�Ƚ��ϴ�.');
                    //comment.editConfirmPass = "";
                }
            }

            // ���� ���
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
                    if (reply.type == 1) {    // ���� ���
                        registCommentInComment(reply, comment);
                    } else if (reply.type == 2) {     // ��� ����
                        editCommentInComment(reply);
                    }

                });
            }




            // ��� ��� �Լ�
            function registComment() {
                getJson('/Contact/RegistComment', { name: $scope.comment.name, comment: $scope.comment.comment, password: $scope.comment.password, adviseId: $scope.advise.Id },
                    function (data) {
                        alert('������ �ǰ� �����մϴ�');
                        //$scope.comment.items.push(data);
                        //$scope.advise.Comments.push(data);

                        $scope.comment.name = "";
                        $scope.comment.comment = "";
                        $scope.comment.password = "";
                        getEachAdvise();
                    },
                    function (arg) {
                        alert('������ �߻��߽��ϴ�');
                        location.reload();
                    }, $scope);
            }

            // ��� ���� �Լ�
            function editCommentInComment(reply) {
                getJson('/Contact/EditComment', { name: reply.name, comment: reply.comment, id: reply.id },
                        function (data) {
                            alert('�����Ǿ����ϴ�');

                            getEachAdvise();
                        },
                        function (arg) {
                            alert('������ �߻��߽��ϴ�');
                            location.reload();
                        }, $scope);
            }

            // ���� ��� �Լ� 
            function registCommentInComment(reply, comment) {
                getJson('/Contact/RegistComment', { name: reply.name, comment: reply.comment, adviseId: $scope.advise.Id, commentId: comment.Id },
                       function (data) {
                           alert('������ �ǰ� �����մϴ�');

                           getEachAdvise();
                       },
                       function (arg) {
                           alert('������ �߻��߽��ϴ�');
                           location.reload();
                       }, $scope);
            }

            // ������ handler
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

            // ���� �ۿ� �ִ� �̹��� ũ�� ����
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

            // ��� ��������
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

            // ���� �� ��������
            function getEachAdvise() {
                getJson('/Contact/GetEachAdvise', { id: $('#Id').val() },
                    function (data) {
                        $scope.advise = data;
                        $scope.advise.Content = $sce.trustAsHtml(data.Content);

                        // ��� ��������
                        getComments($scope.comment.page, $scope.comment.perPage);
                        contentImageHandler();
                    },
                    function (arg) {
                        alert('������ �߻��߽��ϴ�');
                    }, $scope);
            }

        });

// ������ ó���ϴ� controller
var ModalInstanceCtrl = function ($scope, $modalInstance, item, type) {
    $scope.comment = item;

    if (type == 1) { // ���� ���
        $scope.reply = {
            name: "(��) ����",
            comment: ""
        };
        $scope.reply.type = 1;
    } else if (type == 2) { // ��� ���� 
        $scope.reply = {};
        $scope.reply.type = 2;
        $scope.reply.id = $scope.comment.Id;
        $scope.reply.name = $scope.comment.Name;
        $scope.reply.comment = $scope.comment.Comment;
    }

    $scope.ok = function () {
        if (!$scope.reply.name || $scope.reply.name === "" || (jQuery.trim($scope.reply.name)).length == 0) {
            alert('�̸��� �Է����ּ���');
        } else if (!$scope.reply.comment || $scope.reply.comment === "" || (jQuery.trim($scope.reply.comment)).length == 0) {
            alert('��Ʈ�� �Է����ּ���');
        }
        $modalInstance.close($scope.reply);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};