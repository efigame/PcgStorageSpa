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

                characterFactory.updateSkill($scope.character.Skills[i], function () { $scope.success = true; }, function () { $scope.success = false; });
            }
        }
    };

    $scope.updatePower = function (powerid, id) {
        for (var i = 0; i < $scope.character.Powers.length; i++) {
            if ($scope.character.Powers[i].Id == powerid) {
                for (var j = 0; j < $scope.character.Powers[i].PowersList.length; j++) {
                    if ($scope.character.Powers[i].PowersList[j].Key == id) {
                        $scope.character.Powers[i].PowersList[j].Value = !$scope.character.Powers[i].PowersList[j].Value;
                    }
                }

                characterFactory.updatePower($scope.character.Powers[i], function () { $scope.success = true; }, function () { $scope.success = false; });
            }
        }
    };

    $scope.updateList = function (cardlist, id) {
        for (var i = 0; i < cardlist.length; i++) {
            if (cardlist[i].Key < id) {
                cardlist[i].Value = true;
            } else if (cardlist[i].Key == id) {
                cardlist[i].Value = !cardlist[i].Value;
            } else {
                cardlist[i].Value = false;
            }
        }

        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.updateLightArmor = function ($event) {
        var checkbox = $event.target;

        if (checkbox.checked) {
            $scope.character.LightArmors = 2;
        } else {
            $scope.character.LightArmors = 1;
        };

        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.updateHeavyArmor = function ($event) {
        var checkbox = $event.target;

        if (checkbox.checked) {
            $scope.character.HeavyArmors = 2;
        } else {
            $scope.character.HeavyArmors = 1;
        };

        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.updateWeapon = function ($event) {
        var checkbox = $event.target;

        if (checkbox.checked) {
            $scope.character.Weapons = 2;
        } else {
            $scope.character.Weapons = 1;
        };

        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.addWeaponCard = function () {
        if ($scope.SelectedWeaponCard) {
            $scope.character.SelectedCards.WeaponCards.push($scope.SelectedWeaponCard);
            characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
        }
    };

    $scope.addSpellCard = function () {
        if ($scope.SelectedSpellCard) {
            $scope.character.SelectedCards.SpellCards.push($scope.SelectedSpellCard);
            characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
        }
    };

    $scope.addArmorCard = function () {
        if ($scope.SelectedArmorCard) {
            $scope.character.SelectedCards.ArmorCards.push($scope.SelectedArmorCard);
            characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
        }
    };

    $scope.addItemCard = function () {
        if ($scope.SelectedItemCard) {
            $scope.character.SelectedCards.ItemCards.push($scope.SelectedItemCard);
            characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
        }
    };

    $scope.addAllyCard = function () {
        if ($scope.SelectedAllyCard) {
            $scope.character.SelectedCards.AllyCards.push($scope.SelectedAllyCard);
            characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
        }
    };

    $scope.addBlessingCard = function () {
        if ($scope.SelectedBlessingCard) {
            $scope.character.SelectedCards.BlessingCards.push($scope.SelectedBlessingCard);
            characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
        }
    };

    $scope.removeWeaponCard = function (index) {
        $scope.character.SelectedCards.WeaponCards.splice(index, 1);
        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.removeSpellCard = function (index) {
        $scope.character.SelectedCards.SpellCards.splice(index, 1);
        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.removeArmorCard = function (index) {
        $scope.character.SelectedCards.ArmorCards.splice(index, 1);
        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.removeItemCard = function (index) {
        $scope.character.SelectedCards.ItemCards.splice(index, 1);
        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.removeAllyCard = function (index) {
        $scope.character.SelectedCards.AllyCards.splice(index, 1);
        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };

    $scope.removeBlessingCard = function (index) {
        $scope.character.SelectedCards.BlessingCards.splice(index, 1);
        characterFactory.updateCharacter($scope.character, function () { $scope.success = true; }, function () { $scope.success = false; });
    };
});
