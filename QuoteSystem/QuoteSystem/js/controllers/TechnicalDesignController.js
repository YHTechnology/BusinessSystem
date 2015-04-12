'use strict';

MetronicApp.controller('TechnicalDesignController', function ($rootScope, $scope, $window, ProjectService, UserService) {
    $scope.$on('$viewContentLoaded', function () {
        // initialize core components
        Metronic.initAjax();
    });
    $scope.Page = 0;
    $scope.PageSize = 10;


    $scope.LoadProjects = function () {
        Metronic.blockUI({ animate: true });
        $scope.ProjectResult = ProjectService.Projects().get({ Page: $scope.Page, PageSize: $scope.PageSize, UserName: $window.sessionStorage.userName }, function (response) {
            Metronic.unblockUI();
        }, function (response) {
            Metronic.unblockUI();
        });
    };

    $scope.LoadProjects();
});