﻿/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />
app.factory('characterFactory', function ($http, $routeParams) {
    return {
        getCharacter: function (success, error) {
            var characterId = $routeParams.characterid;

            $http.get('http://localhost:4009/api/character/' + characterId).success(success).error(error);
        },
        updateCharacter: function (postData, success, error) {
            var characterId = $routeParams.characterid;

            $http.post('http://localhost:4009/api/character/' + characterId, postData).success(success).error(error);
        },
        updateSkill: function (skill, success, error) {
            $http.post('http://localhost:4009/api/skill/' + skill.Id, skill).success(success).error(error);
        },
        updatePower: function (power, success, error) {
            $http.post('http://localhost:4009/api/power/' + power.Id, power).success(success).error(error);
        }
    };
});