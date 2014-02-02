/// <reference path="../Scripts/angular.min.js" />
/// <reference path="../Modules/main.js" />
app.factory('partyFactory', function ($http, $routeParams) {
    return {
        getParties: function (success, error) {
            var userId = $routeParams.userid;

            $http.get('http://localhost:4009/api/' + userId + '/party').success(success).error(error);
        },
        getParty: function (success, error) {
            var partyId = $routeParams.partyid;

            $http.get('http://localhost:4009/api/party/' + partyId).success(success).error(error);
        }
    };
});