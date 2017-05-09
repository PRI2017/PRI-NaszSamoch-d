console.log('User Tabs Controllers');

var app = angular.module('myApp', ["ngRoute"]);

app.config(function ($routeProvider)
{
    $routeProvider
    .when("User/Info", {
        templateUrl: "\Views/UserPage/UserInfo.cshtml"
    })
    .when("User/Friends", {
        templateUrl: "\Views/UserPage/UserFriends.cshtml"
    })
    .when("User/Gallery", {
        templateUrl: "\Views/UserPage/UserGallery.cshtml"
    })
    .when("User/Statistics", {
        templateUrl: "\Views/UserPage/UserStatistics.cshtml"
    });
});

