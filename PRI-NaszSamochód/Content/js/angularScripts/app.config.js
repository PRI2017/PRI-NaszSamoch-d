angular.
  module('myApp', ['ui.router']).
  config(['$locationProvider', '$stateProvider', '$urlRouterProvider',
    function config($locationProvider, $stateProvider, $urlRouterProvider) {

        $locationProvider.hashPrefix("");

        $stateProvider.state('main', {
            abstract: true,
            url: '/'
        });
        var userPageState = {
            name: 'User/UserPage',
            url: '/User/UserPage',
            views: {
                'header': {
                    templateUrl: 'UserPage/UserPageHeader'
                },
                'content': {
                    templateUrl: 'UserPage/UserPageContent'
                }
            }
        };

        var userInfo = {
            name: 'User/Info',
            url: '/User/Info',
            views: {
                'header': {templateUrl: 'UserPage/UserPageHeader'},
                'content': {templateUrl: 'UserPage/UserInfo'}
            }
        };

        var userFriends = {
            name: 'User/Friends',
            url: '/User/Friends',
            views: {
                'header': {templateUrl: 'UserPage/UserPageHeader'},
                'content': {templateUrl: 'UserPage/UserFriends'}
            }
        };

        var userGallery = {
            name: 'User/Gallery',
            url: '/User/Gallery',
            views: {
                'header': {templateUrl: 'UserPage/UserPageHeader'},
                    'content': {templateUrl: 'UserPage/UserGallery'}
            }
        };

        var userStatistics = {
            name: 'User/Statistics',
            url: '/User/Statistics',
            views: {
                'header': {templateUrl: 'UserPage/UserPageHeader'},
                'content': {templateUrl: 'UserPage/UserStatistics'}
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
        $stateProvider.state(logOff);
    }
    ]).controller('LogOffController', ['$scope', function ($scope) {
        $scope.LogOff = function() {
            window.location.replace("/Account/LogOff");
        }

    }])