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

    $scope.updateAddon = function (skillid, id) {
        for (var i = 0; i < $scope.character.Skills.length; i++) {
            if ($scope.character.Skills[i].Id == skillid) {
                for (var j = 0; j < $scope.character.Skills[i].Addons.length; j++) {
                    if ($scope.character.Skills[i].Addons[j].Key < id) {
                        $scope.character.Skills[i].Addons[j].Value = true;
                    } else if ($scope.character.Skills[i].Addons[j].Key == id) {
                        $scope.character.Skills[i].Addons[j].Value = !$scope.character.Skills[i].Addons[j].Value;
                    } else {
                        $scope.character.Skills[i].Addons[j].Value = false;
                    }
                }

                characterFactory.updateSkill($scope.character.Skills[i], function (results) {
                    $scope.success = true;
                }, function () {
                    $scope.success = false;
                });
            }
        }
    };

    $scope.updateCardsList = function (cardlist, id) {
        for (var i = 0; i < cardlist.length; i++) {
            if (cardlist[i].Key < id) {
                cardlist[i].Value = true;
            } else if (cardlist[i].Key == id) {
                cardlist[i].Value = !cardlist[i].Value;
            } else {
                cardlist[i].Value = false;
            }
        }

        characterFactory.updateCharacter($scope.character, function (results) {
            $scope.success = true;
        }, function () {
            $scope.success = false;
        });
    }
});
