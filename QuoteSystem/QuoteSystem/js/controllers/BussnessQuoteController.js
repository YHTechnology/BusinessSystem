'use strict'

MetronicApp.controller('BussnessQuoteController', function ($rootScope, $scope, $http, $timeout) {
    $scope.$on('$viewContentLoaded', function () {
        // initialize core components
        Metronic.initAjax();
    });

    $scope.clqd = false;
    $scope.xy = false;
})