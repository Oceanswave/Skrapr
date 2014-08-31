angular.module('ngSkraprDashboard')
.controller('ProjectsCtrl', ['$scope', '$http', function ($scope, $http) {
    $http({
        method: "GET",
        url: "/API/Projects/"
    }).success(function(data) {
        console.log(data);
    });
}]);