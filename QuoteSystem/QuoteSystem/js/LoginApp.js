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
         $scope.HasError = false;
         $scope.ErrorText = "";
         $scope.ButtonInfo = "登录";
         $scope.ButtonDisabled = false;
         $window.sessionStorage.isLogin = false;
         $scope.OnSubmit = function () {
             $scope.ButtonInfo = "正在登录...";
             $scope.ButtonDisabled = true;
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
                 $scope.HasError = true;
                 $scope.ErrorText = "用户名密码错误";
                 $scope.ButtonInfo = "登录";
                 $scope.ButtonDisabled = false;
                 //alert('error');
             })
         };
     }])