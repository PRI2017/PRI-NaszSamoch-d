angular.
  module('myApp')
.controller('WallSwitcherController', ['$scope', '$rootScope', function ($scope, $rootScope) {
   
    userPageTemplate =
    [
        { name: 'UserPageHeader', url: 'UserPage/UserPageHeader' },
        { name: 'UserPageContent', url: 'UserPage/UserPageContent' },
        { name: 'UserPageInfo', url: 'UserPage/UserInfo' },
        { name: 'UserPageFriends', url: 'UserPage/UserFriends' },
        { name: 'UserPageGallery', url: 'UserPage/UserGallery' },
        { name: 'UserPageStatisctics', url: 'UserPage/UserStatistics' }
    ];

   header = 'null';
   content = 'null';


   function setUserPage()
    {
      header = userPageTemplate[0].url;
      content = userPageTemplate[1].url;
      console.log("I setted template", header, content)
      $rootScope.header = header;
      $rootScope.content = content;
           
   }

   function setInfo() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[2].url;
       console.log("I setted template", header, content)
       $rootScope.header = header;
       $rootScope.content = content;
   }
  
   function setFriends() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[3].url;
       console.log("I setted template", header, content)
       $rootScope.header = header;
       $rootScope.content = content;
   }
   function setGallery() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[4].url;
       console.log("I setted template", header, content)
       $rootScope.header = header;
       $rootScope.content = content;
   }
   function setStatistics() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[5].url;
       console.log("I setted template", header, content)
       $rootScope.header = header;
       $rootScope.content = content;
   }
    $scope.getHeader = function()
    {
        
        return $rootScope.header;
    }
    $scope.getContent = function () {
   
        return $rootScope.content;
    }

    document.getElementById('userPageClicker').addEventListener('click', setUserPage);
    $scope.setters = function()
    {
        document.getElementById('userPageInfoClicker').addEventListener('click', setInfo);
        document.getElementById('userPageFriendsClicker').addEventListener('click', setFriends);
        document.getElementById('userPageGalleryClicker').addEventListener('click', setGallery);
        document.getElementById('userPageStatisticsClicker').addEventListener('click', setStatistics);
    }


}]);