'use strict'

MetronicApp.controller('ClientRequireController', function ($rootScope, $scope, $http, $timeout, ClientService, ProjectService, UserService) {
    $scope.$on('$viewContentLoaded', function () {
        // initialize core components
        Metronic.initAjax();
    });
    
    $scope.Init = function () {
        $scope.client = new Object;
        $scope.client.ClientName = "";
        $scope.client.CountryDomain = "";
        $scope.client.ContactPerson = "";
        $scope.client.ContactWay = "";
        $scope.client.Duties = "";
        $scope.IsSelectClient = false;
    };

    $scope.LoadClients = function () {
        Metronic.blockUI({ animate: true });
        $scope.ClientNames = new Array();
        $scope.Clients = ClientService.Clients().query(function (response) {
            angular.forEach($scope.Clients, function (client) {
                $scope.ClientNames.push(client.ClientName);
            })
            console.log("Load Client Info success");
            $scope.LoadUsers();
        }, function (response) {
            console.log("Load Client Info failed");
            Metronic.unblockUI();
        });
    };

    $scope.LoadUsers = function () {
        $scope.Users = UserService.Users().query({Department:'技术部'}, function (response) {
            console.log("Load User Info success");
            Metronic.unblockUI();
        }, function (response) {
            console.log("Load User Info failed");
        });
    };

    $scope.OnSubmitClientRequire = function () {
        Metronic.blockUI({ animate: true });
        $scope.project.Client = $scope.client;
        ProjectService.Projects().add($scope.project, function (response) {
            console.log("add projects success");
            $scope.LoadClients();
            //Metronic.unblockUI();
        }, function (response) {
            console.log("add projects failed");
            Metronic.unblockUI();
        });
    };

    $scope.OnClientNameChanged = function () {
        var clientname = $scope.client.ClientName;
        var IsFined = false;
        angular.forEach($scope.Clients, function (client) {
            if (client.ClientName == clientname) {
                $scope.client = angular.copy(client);
                IsFined = true;
                $scope.IsSelectClient = true;
            }
        });
        if (!IsFined) {
            $scope.Init();
            $scope.client.ClientName = clientname;
            $scope.IsSelectClient = false;
        }
    };

    $scope.OnSelectName = function ($item, $model, $label) {
        var clientname = $scope.client.ClientName;
        var IsFined = false;
        angular.forEach($scope.Clients, function (client) {
            if (client.ClientName == clientname) {
                $scope.client = angular.copy(client);
                IsFined = true;
                $scope.IsSelectClient = true;
            }
        });
        if (!IsFined) {
            $scope.Init();
            $scope.client.ClientName = clientname;
            $scope.IsSelectClient = false;
        }
    };

    $scope.OnSelectTechnologyUser = function ($item, $model, $label) {
        $scope.project.TechnologyUser = $item.UserName;
    };

    $scope.Init();
    $scope.LoadClients();
})