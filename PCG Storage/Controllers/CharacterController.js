/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />
/// <reference path="../Factories/CharacterFactory.js" />

app.controller('characterController', function ($scope, $location, $routeParams, characterFactory) {
    $scope.parties = [];
    $scope.user = { Id: $routeParams.userid };
    $scope.party = { Id: $routeParams.partyid };

    characterFactory.getCharacter(function (results) {
        $scope.success = 'Success';
        $scope.character = results;
    }, function () {
        $scope.success = 'Failed';
    });
});
