/***
AngularJS App Login Script
***/

var LoginApp = angular.module("LoginApp", []);

LoginApp.controller('LoginController',
    ['$scope',
     '$rootScope',
     function ($scope, $rootScope) {
         $scope.OnSubmit = function () {
             alert('Submit');
         };
     }])