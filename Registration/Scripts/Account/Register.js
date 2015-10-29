angular.module('accountRegister', ['ngMessages'])
    .controller('RegisterController', function ($http) {
        var register = this;

        register.step = 1;

        register.showStep1Val = false;
        register.showStep2Val = false;

        register.goToStep2 = function (isValidForm) {
            register.showStep1Val = true;

            if (isValidForm) {
                register.step = 2;
            }
        };

        register.user = {};

        register.user.countryId = '';
        register.user.provinceId = '';
        register.provinces = [];

        register.countryChanged = function () {
            register.user.provinceId = '';
            register.provinces = [];

            if (register.user.countryId) {
                $http.get('/api/Countries/' + register.user.countryId + '/Provinces')
                    .then(function (response) {
                        register.provinces = response.data;
                    });
            }
        };

        register.save = function (isValidForm) {
            register.showStep2Val = true;

            if (isValidForm) {
                var user = {
                    email: register.user.login || '',
                    password: register.user.password || '',
                    agree: !!register.user.agree, // force to boolean
                    countryId: parseInt(register.user.countryId) || 0,
                    provinceId: parseInt(register.user.provinceId) || 0
                };

                $http.post('/api/Account/Register', user)
                    .then(function (response) {
                        window.console.log(JSON.stringify(response));
                    }, function (reason) {
                        window.console.log(JSON.stringify('ERROR: ' + reason));
                    });
            }
        };
    });
