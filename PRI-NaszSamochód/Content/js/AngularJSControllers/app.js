angular.
  module('myApp').
  config(['$locationProvider', '$routeProvider','$sceProvider',
    function config($locationProvider, $routeProvider, $sceProvider) {
        $locationProvider.hashPrefix("");

        $routeProvider.
          when('/UserPageHeader', {
              templateUrl: 'UserPage/UserPageHeader'
          });

        // Allow loading from our assets domain.  Notice the difference between * and **.
        //$sceDelegateProvider.resourceUrlWhitelist(['self', 'http://srv*.assets.example.com/**', 'http://localhost:62368/**']);
        $sceProvider.enabled(false);

    }
  ]);

//docs.angularjs.org/api/ng/directive/ngInclude
//docs.angularjs.org/api/ng/directive/ngSwitch