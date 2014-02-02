/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />

app.factory('loginFactory', function ($http) {
    return {
        loginUser: function (postData, success, error) {
            $http.post("http://localhost:4009/api/login", postData).success(success).error(error);
        }
    };
});