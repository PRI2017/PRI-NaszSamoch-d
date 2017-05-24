angular.
  module('myApp').
  config(['$locationProvider', '$routeProvider', '$stateProvider', '$urlRouterProvider',
    function config($locationProvider, $routeProvider, $stateProvider, $urlRouterProvider) {
        $locationProvider.hashPrefix("");

        $urlRouterProvider.otherwise('/');

        var mainState = {
            name: 'main',
            views: {
                header: 'UserPage/UserPageHeader',
                content: 'UserPage/UserPageContent'
            }
        }
         
    }
  ]);
