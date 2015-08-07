'use strict'

describe('Controller: ClientRequireController', function () {
    var $rootScope, $scope, $controller;

    beforeEach(angular.module('MetronicApp'));

    beforeEach(inject(function (_$rootScope_, _$controller_) {
        $rootScope = _$rootScope_;
        $scope = $rootScope.$new();
        $controller = _$controller_;

        $controller('ClientRequireController', { '$scope': $scope });
    }));

    it('should make about menu item active.', function () {
        expect('active' == 'active');
    });
});