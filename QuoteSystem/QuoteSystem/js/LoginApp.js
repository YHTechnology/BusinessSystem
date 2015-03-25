/***
AngularJS App Login Script
***/

var LoginApp = angular.module("LoginApp", []);

LoginApp.controller('LoginController',
    ['$scope',
     '$rootScope',
     '$location',
     '$window',
     function ($scope, $rootScope, $location, $window) {
         $scope.OnSubmit = function () {
             var mainUrl = $location.protocol() + "://" + $location.host() + ":" + $location.port() + "/index.html";
             window.location.replace(mainUrl);
         };
     }])