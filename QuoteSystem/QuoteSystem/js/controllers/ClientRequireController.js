'use strict'

MetronicApp.controller('ClientRequireController', function ($rootScope, $scope, $http, $timeout) {
    $scope.$on('$viewContentLoaded', function () {
        // initialize core components
        Metronic.initAjax();
    });

    $scope.OnSubmitClientRequire = function () {
        alert('save project');
    }
})