var appUserServices = angular.module('UserServices', ['ngResource']);

appUserServices.factory('UserService', function ($resource, $window) {
    return {
        Users: function () {
            return $resource('/api/User/:id', { id: '@_id' }, {
                query: {
                    method: 'GET',
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                },
                update: {
                    method: 'PUT',
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                },
                add: {
                    method: 'PUST',
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                }
            });
        }
    };
});