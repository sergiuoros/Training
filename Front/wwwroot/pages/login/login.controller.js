app.controller('LoginController', ["$http", "AuthenticationService",
    function ($http, AuthenticationService) {
        var vm = this;
        vm.username = '';
        vm.password = '';
        vm.goLogin = function () {
            AuthenticationService.Login(vm.username, vm.password, function (response) {
                if (response.success) {
                    alert("Success");
                } else {
                    alert("Failed");
                }
            })
        };
    }]);