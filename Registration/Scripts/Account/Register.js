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
            var model = {
                email: register.user.login || '',
                password: register.user.password || '',
                agree: !!register.user.agree, // force to boolean
                countryId: parseInt(register.user.countryId),
                provinceId: parseInt(register.user.provinceId)
            };
            //window.console.log(JSON.stringify(model));

            $http.post('/api/Account/Register', model)
                .then(function (response) {
                    window.console.log(JSON.stringify(response));
                }, function (reason) {
                    window.console.log(JSON.stringify('ERROR: ' + reason));
                });
        };
    });
