app.controller('PopupAddSessionController', ["$scope","$stateParams", "SessionService",
    function ($scope, $stateParams, SessionService) {
        $scope.name = '';
        $scope.duration = '';
        $scope.difficulty = '';
        $scope.description = '';
        $scope.addSession = function () {
            if (angular.isString($scope.name) && angular.isString($scope.duration) && angular.isString($scope.difficulty) && angular.isString($scope.description)) {
                SessionService.addSession($stateParams.id, $scope.name, $scope.duration, $scope.difficulty, $scope.description, function (response) {
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