var appClientServices = angular.module('ClientServices', ['ngResource']);

appClientServices.factory('ClientService', function ($resource, $window) {
    return {
        Clients: function () {
            return $resource('/api/Client/:id', { id: '@_id' }, {
                query: {
                    method: 'GET',
                    isArray: true,
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
})