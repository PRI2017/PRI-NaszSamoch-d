angular.
  module('myApp').
  config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix("");

        $routeProvider.
          when('/UserPageHeader', {
              templateUrl: 'UserPage/UserPageHeader'
          });
    }
  ]);

//docs.angularjs.org/api/ng/directive/ngInclude
//docs.angularjs.org/api/ng/directive/ngSwitch