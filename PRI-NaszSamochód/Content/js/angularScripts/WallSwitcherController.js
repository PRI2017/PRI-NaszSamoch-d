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
        { name: 'UserPageStatisctics', url: 'UserPage/UserStatistics' },
        { name: 'GroupHeader', url: 'Groups/GroupHeader' },
        { name: 'AddNewGroup', url: 'Groups/AddNewGroup' },
        { name: 'GroupContent', url: 'Groups/GroupContent' }


    ];

   header = 'null';
   content = 'null';


   function setUserPage()
    {
      header = userPageTemplate[0].url;
      content = userPageTemplate[1].url;
      console.log("I setted template", header, content);
      $rootScope.header = header;
      $rootScope.content = content;
      document.getElementById('headerPar').style.display = "none";
   }

   function setInfo() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[2].url;
       console.log("I setted template", header, content);
       $rootScope.header = header;
       $rootScope.content = content;
   }
  
   function setFriends() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[3].url;
       console.log("I setted template", header, content);
       $rootScope.header = header;
       $rootScope.content = content;
   }
   function setGallery() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[4].url;
       console.log("I setted template", header, content);
       $rootScope.header = header;
       $rootScope.content = content;
   }

   function setStatistics() {
       header = userPageTemplate[0].url;
       content = userPageTemplate[5].url;
       console.log("I setted template", header, content);
       $rootScope.header = header;
       $rootScope.content = content;
   }
   function setAddNewGroup() {
       header = userPageTemplate[6].url;
       content = userPageTemplate[7].url;
       console.log("I setted template", header, content);
       $rootScope.header = header;
       $rootScope.content = content;
   }

   function setGroupContent() {
       header = userPageTemplate[6].url;
       content = userPageTemplate[8].url;
       console.log("I setted template", header, content);
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
    $scope.setters = function () {
        if (document.getElementById('userPageInfoClicker') != null) {
            document.getElementById('userPageInfoClicker').addEventListener('click', setInfo);
        }
        if (document.getElementById('userPageFriendsClicker') != null) {
            document.getElementById('userPageFriendsClicker').addEventListener('click', setFriends);
        }
        if (document.getElementById('userPageGalleryClicker') != null) {
            document.getElementById('userPageGalleryClicker').addEventListener('click', setGallery);
        }
        if (document.getElementById('userPageStatisticsClicker') != null) {
            document.getElementById('userPageStatisticsClicker').addEventListener('click', setStatistics);
        }
        if (document.getElementById('addNewGroupClicker') != null) {
            document.getElementById('addNewGroupClicker').addEventListener('click', setAddNewGroup);
        }
        if (document.getElementById('GroupContentClicker') != null) {
            document.getElementById('GroupContentClicker').addEventListener('click', setGroupContent);
        }
    }
    

}]);