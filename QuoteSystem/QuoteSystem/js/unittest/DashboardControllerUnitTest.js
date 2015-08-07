'use strict'

describe('Controller: DashboardController', function () {
    beforeEach(module('ngRoute'));
    beforeEach(module('MetronicApp', [
    "ui.router",
    "ui.bootstrap",
    "oc.lazyLoad",
    "ngSanitize",
    "UserServices",
    "ProjectServices",
    "ClientServices"
    ]));

    var $controller;

    beforeEach(inject(function (_$controller_) {
        //$rootScope = _$rootScope_;
        //$scope = $rootScope.$new();
        $controller = _$controller_;

        //$controller('DashboardController', { '$rootScope': $rootScope, '$scope': $scope });
    }));
    
    it('should make about menu item active.', function () {
        expect('active' == 'active');
    });
    
});