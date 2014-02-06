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

    $scope.updateAddon = function ($event, skillid, id) {
        var checkbox = $event.target;
        var action = (checkbox.checked ? 'add' : 'remove');

        if (action == 'add' && $scope.selected.indexOf(id) == -1) {
            var skill = $scope.character
        }
        if (action == 'remove' && $scope.selected.indexOf(id) != -1) {
            $scope.selected.splice($scope.selected.indexOf(id), 1);
        }
    }
});
