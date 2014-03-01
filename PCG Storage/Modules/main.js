/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Scripts/angular-route.min.js" />
/// <reference path="../Controllers/LoginController.js" />
/// <reference path="../Controllers/PartyController.js" />

var app = angular.module("app", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', { templateUrl: "partials/user/login.html", controller: "loginController" })
        .when('/:userid/party', { templateUrl: "partials/party/index.html", controller: "partyController" })
        .when('/:userid/party/new', { templateUrl: "partials/party/new.html", controller: "partyController" })
        .when('/:userid/party/:partyid', { templateUrl: "partials/party/view.html", controller: "partyController" })
        .when('/:userid/party/:partyid/edit', { templateUrl: "partials/party/edit.html", controller: "partyController" })
        .when('/:userid/party/:partyid/character/:characterid', { templateUrl: "partials/character/view.html", controller: "characterController" })
        .when('/:userid/party/:partyid/character/:characterid/edit', { templateUrl: "partials/character/edit.html", controller: "characterController" })
        .otherwise({ template: "This doesn't exist!" });
});
