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

    $scope.updatePartyCharacters = function ($event, id) {
        var proceed = true;
        var checkbox = $event.target;
        
        if (!checkbox.checked)
        {
            proceed = confirm('Are you sure you want to delete your character? This cannot be reverted.');
        }

        if (proceed)
        {
            for (var i = 0; i < $scope.party.PossibleCharacters.length; i++) {
                if ($scope.party.PossibleCharacters[i].Key.Id == id) {
                    $scope.party.PossibleCharacters[i].Value = !$scope.party.PossibleCharacters[i].Value;
                }
            }

            partyFactory.updateParty($scope.party, function (results) {
                $scope.success = true;
            }, function () {
                $scope.success = false;
            });
        }
        else
        {
            checkbox.checked = true;
        }
    };

    $scope.updateParty = function () {
        partyFactory.updateParty($scope.party, function (results) {
            $scope.success = true;
        }, function () {
            $scope.success = false;
        });
    };
});
