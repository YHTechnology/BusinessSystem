var appUserServices = angular.module('UserServices', ['ngResource']);

appUserServices.factory('UserService', function ($resource, $window) {
    return {
        Users: function () {
            return $resource('/api/User/:id', { id: '@_id' }, {
                query: {
                    method: 'GET',
                    isArray: true,
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                },
                get: {
                    method: 'GET',
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                },
                update: {
                    method: 'PUT',
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                },
                add: {
                    method: 'POST',
                    headers: { 'Authorization': $window.sessionStorage.token_type + ' ' + $window.sessionStorage.access_token }
                }
            });
        }
    };
});