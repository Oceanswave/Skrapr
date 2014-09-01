angular.module('ngSkraprDashboard')
    .controller('ProjectDetailsCtrl', [
        '$scope', '$http', '$modal', '$stateParams',
        function($scope, $http, $modal, $stateParams) {
            $scope.project = null;
            $scope.model = {
                isLoading: true
            };

            $scope.getProjectDetails = function (projectId) {
                $scope.model.isLoading = true;

                $http({
                    method: "GET",
                    url: "/API/Projects/" + projectId
                }).success(function(data) {
                    $scope.project = data;
                    $scope.model.isLoading = false;
                }).error(function(data) {
                    $scope.project = null;
                    $scope.model.isLoading = false;
                });
            };

            $scope.getProjectDetails($stateParams.projectId);
        }
    ]);

