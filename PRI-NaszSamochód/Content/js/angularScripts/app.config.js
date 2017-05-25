angular.
  module('myApp').
  config(['$locationProvider', '$routeProvider', '$stateProvider', '$urlRouterProvider',
    function config($locationProvider, $routeProvider, $stateProvider, $urlRouterProvider) {
        $locationProvider.hashPrefix("");

        $urlRouterProvider.otherwise('/');

        var userPageState = {
            name: 'User/UserPage',
            url: 'User/UserPage',
            views: {
                header: 'UserPage/UserPageHeader',
                content: 'UserPage/UserPageContent'
            }
        }

        var userInfo = {
            name: 'User/Info',
            url: 'User/Info',
            views: {
                header: 'UserPage/UserPageHeader',
                content: 'UserPage/UserInfo'
            }
        }

        var userFriends = {
            name: 'User/Friends',
            url: 'User/Friends',
            views: {
                header: 'UserPage/UserPageHeader',
                content: 'UserPage/UserFriends'
            }
        }

        var userGallery = {
            name: 'User/Gallery',
            url: 'User/Gallery',
            views: {
                header: 'UserPage/UserPageHeader',
                content: 'UserPage/UserGallery'
            }
        }

        var userStatistics = {
            name: 'User/Statistics',
            url: 'User/Statistics',
            views: {
                header: 'UserPage/UserPageHeader',
                content: 'UserPage/UserStatistics'
            }
        }


        $stateProvider.state(userPageState);
        $stateProvider.state(userInfo);
        $stateProvider.state(userFriends);
        $stateProvider.state(userGallery);
        $stateProvider.state(userStatistics);
         
    }
  ]);
