app.controller('SessionController', ["$scope", "$stateParams", "ngDialog", "SessionService",
    function ($scope, $stateParams, ngDialog, SessionService) {
        SessionService.GetAll($stateParams.id).then(function (result) {
            $scope.sessions = result.data;
        })
        var vm = this;
        //open Popup
        var dialog;
        vm.OpenPopup = function () {
            dialog = ngDialog.open({
                template: '/myApp/modals/popup.add.session.html',
                controller: 'PopupAddSessionController',
                trapFocus: false,
                
            });
            dialog.closePromise.then(function (data) {
                if (data.value == 'Add') {
                    SessionService.GetAll($stateParams.id).then(function (result) {
                        $scope.sessions = result.data;
                    })
                }
            });
        }
    }]);