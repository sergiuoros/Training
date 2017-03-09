app.controller('EventController', ["$scope", "$state","$stateParams", "ngDialog", "EventService",
    function ($scope, $state, $stateParams, ngDialog, EventService) {
        EventService.GetAll().then(function (result) {
            $scope.events = result.data;
        })
        //todo: put catch / error;
        var vm = this;


        //open Popup
        var dialog;
        vm.clickToOpen = function (){
            dialog = ngDialog.open({
                template: '/myApp/modals/popup.add.event.html',
                controller: 'PopupAddController',
                trapFocus: false,
            });
            dialog.closePromise.then(function (data) {
                if (data.value == 'Add') {
                    EventService.GetAll().then(function (result) {
                        $scope.events = result.data;
                    })
                }
            });
        }
        //Session
        $scope.openSession = function (event) {
            $state.go('eventsession', {
                "id": event.idEvent,
            });
        };
        



        

    }]);