app.controller('EventEditController', ["$scope", "$state", "$stateParams", "ngDialog", "EventService",
    function ($scope, $state, $stateParams, ngDialog, EventService) {
        
        console.log('da');
        //AutoFill
        var dbModel;
        $scope.model = {
            idEvent: '',
            name: '',
            date: '',
            price: '',
            location: '',
        };
        $scope.AutoFill = function () {
            EventService.GetEventById($stateParams.id, function (EventResponse) {
                if (EventResponse.success) {
                    dbModel = EventResponse.data;
                    dbModel.date = new Date(dbModel.date);
                    $scope.model = angular.copy(dbModel);
                } else {
                    alert("Failed");
                }
            });
        };
        //Edit
        $scope.Edit = function () {
            if (angular.equals($scope.model, dbModel)) {
                alert('No changes');
            }
            else {
                EventService.UpdateEvent($scope.model, function (response) {
                    if (response.success) {
                        $state.go('events');
                    } else {
                        alert('An error occurred')
                    }
                })
            }
        }
        //Session

        $scope.openSession = function (event) {
            $state.go('eventsession', { "id": event.id });
            console.log('Opeeen');
        };






    }]);