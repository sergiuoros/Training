(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('EventService', EventService);

    EventService.$inject = ['$http'];
    function EventService($http) {
        var service = {};

        //getAll
        service.GetAll = function () {
           return $http({
                method: 'get',
                url: 'http://localhost:51427/api/event/getevents',
            })
        }
        //AddEvent
        service.addEvent = function (name, date, price, location, callback) {
            var response;
            return $http({
                method: 'post',
                url: 'http://localhost:51427/api/event/add',
                data: {
                    'Name': name,
                    'Date': date,
                    'Price': price,
                    'Location': location,
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

        //AutoFill
        service.GetEventById = function(id,callback){
            var response;
            return $http({
                method: 'post',
                url: 'http://localhost:51427/api/event/getbyid',
                data: {
                    'IdEvent': id,
                }
            }).then(function (result) {
                if (result.status = "200") {
                    response = {
                        success: true,
                        data: result.data
                    };
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

        service.UpdateEvent= function(model,callback){
            var response;
            return $http({
                method: 'post',
                url: 'http://localhost:51427/api/event/update',
                data: {
                    'IdEvent': model.idEvent,
                    'Name': model.name,
                    'Date': model.date,
                    'Price': model.price,
                    'Location': model.location,
                }
            }).then(function (result) {
                if (result.status = "200") {
                    response = {
                        success: true,
                        data: result.data
                    };
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