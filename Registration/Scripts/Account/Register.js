angular.module('accountRegister', [])
    .controller('RegisterController', function ($http) {
        var register = this;

        register.step = 1;

        register.user = {};

        register.user.countryId = '0';
        register.user.provinceId = '0';
        register.provinces = [];

        register.countryChanged = function () {
            register.user.provinceId = '0';
            register.provinces = [];

            if (register.user.countryId != '0') {
                $http.get('/api/Countries/' + register.user.countryId + '/Provinces')
                    .then(function (response) {
                        register.provinces = response.data;
                    });
            }
        };

        register.save = function () {
            window.console.log(JSON.stringify(register.user));
        };
    });
