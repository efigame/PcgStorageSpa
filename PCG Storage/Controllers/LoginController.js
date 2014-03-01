/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />
/// <reference path="../Factories/LoginFactory.js" />

app.controller('loginController', function ($scope, $location, loginFactory) {
    var app = this;

    app.loginUser = function (user) {
        var postData = { "Id": null, "Email": user.email, "Password": user.password };

        loginFactory.loginUser(postData, function (results) {
            $location.path('/' + results.Id + '/party');
        }, function () {
            $scope.success = 'Failed';
        });
    };
});