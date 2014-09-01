angular.module('ngSkraprDashboard')
    .controller('ProjectDetailsCtrl', [
        '$scope', '$http', '$modal', '$stateParams',
        function($scope, $http, $modal, $stateParams) {
            $scope.project = null;

            $scope.getProjectDetails = function(projectId) {
                $http({
                    method: "GET",
                    url: "/API/Projects/" + projectId
                }).success(function(data) {
                    $scope.project = data;
                }).error(function(data) {
                    $scope.project = null;
                });
            };

            $scope.getProjectDetails($stateParams.projectId);
        }
    ]);

