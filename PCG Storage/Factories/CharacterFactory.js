/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />
app.factory('characterFactory', function ($http, $routeParams) {
    return {
        getCharacter: function (success, error) {
            var characterId = $routeParams.characterid;

            $http.get('http://localhost:4009/api/character/' + characterId).success(success).error(error);
        }
    };
});