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
            register.user.province = '0';
        };

        register.user.country = '0';
        emptyProvinceList();

        register.countryChanged = function () {
            emptyProvinceList();

            if (register.user.country != '0') {
                $http.get('/api/Countries/' + register.user.country + '/Provinces')
                    .then(function (response) {
                        var provinces = response.data;

                        var emptyLine = [{
                            Id: 0,
                            Name: 'Select province'
                        }];
                        register.provinces = emptyLine.concat(provinces);
                        register.user.province = '0';
                    });
            }
        };
    });
