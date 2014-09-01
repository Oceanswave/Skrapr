angular.module('ngSkraprDashboard')
.controller('DashboardCtrl', ['$scope', 'auth', function ($scope, auth) {
    $scope.auth = auth;
    $scope.model = {
        isMinimized: false
    };

    $scope.toggleMinimized = function() {
        $scope.model.isMinimized = !$scope.model.isMinimized;
    };

    $scope.getDashboardStyle = function() {
        var result = {
            left: $scope.model.isMinimized ? "58px" : "220px"
        };

        return result;
    };

    $scope.signOut = function () {
        auth.signout();
    };
}]);