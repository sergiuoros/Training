(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('AuthenticationService', AuthenticationService);

    AuthenticationService.$inject = ['$http'];
    function AuthenticationService($http) {
        var service = {};

        service.Login = function(username, password, callback) {
                var response
                $http({
                    method: 'Post',
                    url: 'http://localhost:51427/api/account/login',
                    data: {
                        'Username': username,
                        'Password': password,
                    }
                }).then(function (result) {
                    if (result.status = "200") {
                        response = { success: true };
                    } else {
                        response = { success: false };
                    }
                    callback(response);

                }).catch(function (result) {
                    response = {
                        success: false 
                    }
                    callback(response)
                })
        }


        return service;
    }
})();