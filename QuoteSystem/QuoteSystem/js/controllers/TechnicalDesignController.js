'use strict';

MetronicApp.controller('TechnicalDesignController', function ($rootScope, $scope, $http, $timeout, ProjectService, UserService) {
    $scope.$on('$viewContentLoaded', function () {
        // initialize core components
        Metronic.initAjax();
    });




});