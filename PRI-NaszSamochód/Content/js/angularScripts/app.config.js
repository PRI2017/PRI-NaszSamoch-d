﻿angular.
  module('myApp', ['ui.router']).
    config(['$locationProvider', '$stateProvider', '$urlRouterProvider','$controllerProvider',
        function config($locationProvider, $stateProvider, $urlRouterProvider, $scope, $rootScope, $controllerProvider) {
            var tmp = null;
            var tmp1 = null;
        $locationProvider.hashPrefix("");
            $scope.create
                = function create($event,$state) {

                window.userId = $event.currentTarget.id;
                $state.go('User/UserPage');
            };
        $stateProvider.state('main', {
            
            url: '',
            views: {
             
                'content': {
                    templateUrl: function ($scope) {

                        return 'Wall/WallContent';
                    },
                    controller: 'PostController'
                }
            }
        });
        var userPageState = {
            name: 'User/UserPage',
            url: '/User/UserPage',
            views: {
                'header': {
                    templateUrl: function($scope) {
                        
                        return 'UserPage/UserPageHeader?userId='+window.userId;
                    }
                    
                },             
                'content': {
                    templateUrl: function ($scope) {

                        return 'UserPage/UserPageContent?userId=' + window.userId;
                    },
                    controller: 'PostController'
                }
            }
        }; 

        var userInfo = {
            name: 'User/Info',
            url: '/User/Info',
            views: {
                'header': {
                    templateUrl: function ($scope) {

                        return 'UserPage/UserPageHeader?userId=' + window.userId;
                    }
                    
                },
                'content': {
                    templateUrl: function ($scope) {

                        return 'UserPage/UserInfo?userId=' + window.userId;
                    }
                }
            }
        };

        var userFriends = {
            name: 'User/Friends',
            url: '/User/Friends',
            views: {
                'header': {
                    templateUrl: function($scope) {

                        return 'UserPage/UserPageHeader?userId=' + window.userId;

                    }
                },
                'content': {
                    templateUrl: function ($scope) {

                        return 'UserPage/UserFriends?userId=' + window.userId;

                    },
                    controller:"FriendController"
                }
            }
        };

        var userGallery = {
            name: 'User/Gallery',
            url: '/User/Gallery',
            views: {
                'header': {
                    templateUrl: function($scope) {

                        return 'UserPage/UserPageHeader?userId=' + window.userId;
                    }
                },
                'content': {
                    templateUrl: function ($scope) {

                        return 'Gallery/?userId' + window.userId;
                    }
                    
                }
            }
        };

        var userStatistics = {
            name: 'User/Statistics',
            url: '/User/Statistics',
            views: {
                'header': {
                    templateUrl: function($scope) {

                        return 'UserPage/UserPageHeader?userId=' + window.userId;
                    }
                },
                'content': {
                    templateUrl: function ($scope) {
                        return 'UserPage/UserStatistics?userId=' + window.userId;
                    }
                }
            }
        };

        var addNewGroup = {
            name: 'Groups/AddNewGroup',
            url: '/Groups/AddNewGroup',
            views: {
                'header': { templateUrl: 'Groups/GroupHeader' },
                'content': { templateUrl: 'Groups/AddNewGroup' }
            }
        };
        var groupDetails = {
            name: 'Groups/Details',
            url: '/Groups/GroupDetails',
            views: {
                'header': {
                    templateUrl: function ($scope) {
                        return 'Groups/GroupHeader';
                    }
                },
                'content': {
                    templateUrl: function ($scope) {
                        console.log("GROUP: " + window.GroupId);
                        if (tmp1 == null && window.GroupId != undefined) {
                            tmp1 = window.GroupId;
                        };

                        window.onbeforeunload = function (e) {
                            window.GroupId = tmp1;
                            console.log(e + "Gunwo");
                        }
                        return 'Groups/GroupContent?id=' + window.GroupId;
                    }
                }
            }
        };

        var pathMachine = function (path, param) {

            var superPath = path + param;
            console.log(superPath);
            return superPath;
        };

        //var groupContent = {
        //    name: 'Groups/Content',
        //    url: '/Groups/Content/:groupId',
        //    controller: function ($scope, $stateParams) {
        //        console.log("RAZ: " + $scope.razrId);
        //        $scope._groupId = $stateParams.groupId;
        //    },
        //    views: {
        //        'header': { templateUrl: 'Groups/GroupHeader' },
        //        'content': { templateUrl: pathMachine("Groups/GroupContent/", /*$stateParams.groupId JAK SIĘ WPISZE Z PALCA TO DZIAŁA, A TAK TO NIE :((*/ 12) }
        //    }
        //};
        var logOff = {
            name: 'User/LogOff',
            url: '/User/LogOff',
            controller: 'LogOffController'
            //views: {
            //    'header': { templateUrl: 'Account/LogOff' },
            //    'content': { templateUrl: 'Account/LogOff' }
            //}
        };


        $stateProvider.state(userPageState);
        $stateProvider.state(userInfo);
        $stateProvider.state(userFriends);
        $stateProvider.state(userGallery);
        $stateProvider.state(userStatistics);
        $stateProvider.state(addNewGroup);
        $stateProvider.state(groupDetails);
        //$stateProvider.state(groupContent);
        $stateProvider.state(logOff);
    }]).controller('LogOffController', ['$scope', function ($scope) {
        $scope.LogOff = function () {
            window.location.replace("/Account/LogOff");
        };

    }]).controller('PostController', ['$scope','$state', function($scope,$state) {
        $scope.PostClicked = function ($event) {
            
            
            window.userId = $event.currentTarget.id;
            $state.go('User/UserPage');
        }


    }]).controller('FriendController', ['$scope', '$state','$http', function ($scope, $state, $http) {
        $scope.DeleteFriend = function DeleteFriend($event) {
            var urlDelete = '/Friends/DeleteFriend?userId=' + $event.currentTarget.id;

            $http({
                method: 'POST',
                url: urlDelete
            }).then(function successCallback(response) {
                $state.reload();
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }
        $scope.ViewProfile = function ViewProfile($event) {

            window.userId = $event.currentTarget.id;
            $state.go('User/UserPage');
        }
        $scope.AddFriend = function AddFriend($event) {
            var url = '/Friends/AddFriend?userId=' + $event.currentTarget.id;
            $http({
                method: 'POST',
                url: url
            }).then(function successCallback(response) {
                $state.reload();
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }

    }]).controller('GroupController', ['$scope', '$state', '$http', function($scope, $state, $http) {

        $scope.GroupDetails = function GroupDetails($event) {
            window.GroupId = $event.currentTarget.id;
            var group_id = window.GroupId;
            console.log("Id form controller" + group_id);
            //$state.go('Groups/GroupDetails', {}, { reload: true });
            //$state.reload();
        }
        this.$update().then(function () {
            $state.go('Groups/GroupDetails', {}, { reload: true });
        });

    }]);