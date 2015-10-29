angular.module('accountRegister', [])
    .controller('RegisterController', function ($http) {
        var register = this;

        register.step = 1;

        register.goToStep2 = function () {
            register.step = 2;
        };

        var emptyProvinceList = function () {
            register.provinces = [{
                Id: 0,
                Name: 'Please select country first'
            }];
            register.province = '0';
        };

        register.country = '0';
        emptyProvinceList();

        register.countryChanged = function () {
            emptyProvinceList();

            if (register.country != '0') {
                $http.get('/api/Countries/' + register.country + '/Provinces')
                    .then(function (response) {
                        var emptyLine = [{
                            Id: 0,
                            Name: 'Select province'
                        }];
                        register.provinces = emptyLine.concat(response.data);
                        register.province = '0';
                    });
            }
        };
    });
