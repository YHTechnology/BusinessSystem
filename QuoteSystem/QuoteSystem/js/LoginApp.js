/***
AngularJS App Login Script
***/

var LoginApp = angular.module("LoginApp", [
    "UserServices"
    ]);

LoginApp.controller('LoginController',
    ['$scope',
     '$rootScope',
     '$location',
     '$http',
     '$window',
     'UserService',
     function ($scope, $rootScope, $location, $http, $window, UserService) {
         $scope.formData;
         $scope.hasError = false;
         $scope.ErrorText = "";
         $scope.ButtonInfo = "Login";
         $scope.buttondisabled = false;
         $window.sessionStorage.isLogin = false;
         $scope.OnSubmit = function () {

             $scope.ButtonInfo = "Login...";
             $scope.buttondisabled = true;
             var logindata = $(".login-form").serialize();
             logindata = logindata + "&grant_type=password";
             //alert(logindata);
             $http.post('/Token', logindata).success(function (data, status, header, config) {
                 $window.sessionStorage.expires_in = data.expires_in;
                 $window.sessionStorage.token_type = data.token_type;
                 $window.sessionStorage.access_token = data.access_token;
                 $window.sessionStorage.userName = data.userName;

                 $scope.user = UserService.Users().query({ id: data.userName }, function (response) {
                     $window.sessionStorage.userCName = $scope.user.UserCName;
                     $window.sessionStorage.userGroup = $scope.user.Group;
                     $window.sessionStorage.userDepartment = $scope.user.Department;
                     $window.sessionStorage.isLogin = true;
                     var mainUrl = $location.protocol() + "://" + $location.host() + ":" + $location.port() + "/index.html";
                     window.location.replace(mainUrl);
                 }, function (error) {

                 });
             }).error(function (data, status, header, config) {
                 //alert('error');
             })
         };
     }])