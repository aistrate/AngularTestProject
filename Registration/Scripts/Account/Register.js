angular.module('accountRegister', [])
    .controller('RegisterController', function () {
        var register = this;

        register.step = 1;

        register.goToStep2 = function () {
            register.step = 2;
        };
    });
