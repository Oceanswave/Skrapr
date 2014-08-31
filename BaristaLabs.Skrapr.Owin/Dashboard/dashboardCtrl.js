angular.module('ngSkraprDashboard')
.controller('DashboardCtrl', ['$scope', 'auth', function ($scope, auth) {
    $scope.auth = auth;

    $scope.signOut = function () {
        auth.signout();
    };
}]);