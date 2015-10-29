angular.module('accountRegister', [])
    .controller('RegisterController', function ($http) {
        var register = this;

        register.step = 1;

        register.user = {};

        var emptyProvinceList = function () {
            register.provinces = [{
                Id: 0,
                Name: 'Please select country first'
            }];
            register.user.provinceId = '0';
        };

        register.user.countryId = '0';
        emptyProvinceList();

        register.countryChanged = function () {
            emptyProvinceList();

            if (register.user.countryId != '0') {
                $http.get('/api/Countries/' + register.user.countryId + '/Provinces')
                    .then(function (response) {
                        var provinces = response.data;

                        var emptyLine = [{
                            Id: 0,
                            Name: 'Select province'
                        }];
                        register.provinces = emptyLine.concat(provinces);
                        register.user.provinceId = '0';
                    });
            }
        };
    });
