/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />
/// <reference path="../Factories/PartyFactory.js" />

app.controller('partyController', function ($scope, $location, $routeParams, partyFactory) {
    $scope.parties = [];
    $scope.user = { Id: $routeParams.userid };

    partyFactory.getParties(function (results) {
        $scope.success = 'Success';
        $scope.parties = results;
    }, function () {
        $scope.success = 'Failed';
    });

    partyFactory.getParty(function (results) {
        $scope.success = 'Success';
        $scope.party = results;
    }, function () {
        $scope.success = 'Failed';
    });
});
