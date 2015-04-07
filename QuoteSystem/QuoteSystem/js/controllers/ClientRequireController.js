'use strict'

MetronicApp.controller('ClientRequireController', function ($rootScope, $scope, $http, $timeout, ClientService, ProjectService, UserService) {
    $scope.$on('$viewContentLoaded', function () {
        // initialize core components
        Metronic.initAjax();
    });



    $scope.OnSubmitClientRequire = function () {
        
    }
})