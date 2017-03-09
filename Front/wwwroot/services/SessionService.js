(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('SessionService', SessionService);

    SessionService.$inject = ['$http'];
    function SessionService($http) {
        var service = {};

        //getAll
        service.GetAll = function (idEvent) {
            return $http({
                method: 'post',
                url: 'http://localhost:51427/api/session/getsessionsforevent',
                data: {
                    'IdEvent': idEvent,
                }
            })
        }

        //AddSession
        service.addSession = function (id, name, duration, difficulty, description, callback) {
            var response;
            return $http({
                method: 'post',
                url: 'http://localhost:51427/api/session/add',
                data: {
                    'IdEvent': id,
                    'Name': name,
                    'Duration': duration,
                    'Difficulty': difficulty,
                    'Description': description,
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
        };
        
        return service;
    }
})();