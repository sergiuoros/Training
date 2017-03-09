app.controller('PopupAddController', ["$scope", "EventService",
    function ($scope, EventService) {
        $scope.name = '';
        $scope.date = '';
        $scope.price = '';
        $scope.location = '';
        $scope.addEvent = function () {
            if(angular.isString($scope.name) && angular.isDate($scope.date) && angular.isNumber($scope.price) && angular.isString($scope.location)){
                EventService.addEvent($scope.name, $scope.date, $scope.price, $scope.location, function (response) {
                    if (response.success) {
                        $scope.closeThisDialog('Add');
                    } else {
                        alert("Adding an event failed");
                    }
                })
            }
            else {
                alert("Invalid inputs");
            }
        };
        $scope.Close = function () {
            $scope.closeThisDialog('Closed');
        }
    }]);