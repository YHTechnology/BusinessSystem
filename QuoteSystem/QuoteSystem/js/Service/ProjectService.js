var appProjectServices = angular.module('ProjectServices', ['ngResource']);

appProjectServices.factory('ProjectService', function ($resource, $window) {
    return {
        Clients: function () {
            return $resource('/api/Project/:id', { id: '@_id' }, {
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
})