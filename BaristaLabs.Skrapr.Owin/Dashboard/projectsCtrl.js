angular.module('ngSkraprDashboard')
    .controller('ProjectsCtrl', [
        '$scope', '$http', '$modal', '$state',
        function ($scope, $http, $modal, $state) {
            $scope.model = {
                isLoading: true
            };

            $scope.projects = [];

            $scope.addNewProject = function() {
                $modal.open({
                    templateUrl: 'new-project-tmpl.html',
                    controller: "NewProjectCtrl"
                }).result.then(function(project) {
                    $state.go("ProjectDetails", { projectId: project._id });
                });
            };

            $scope.deleteProject = function (projectId) {
                $scope.model.isLoading = true;

                $http({
                    method: "DELETE",
                    url: "/API/Projects/" + projectId
                }).then(function() {
                    $scope.listProjects();
                });
            }

            $scope.listProjects = function () {
                $scope.model.isLoading = true;

                $http({
                    method: "GET",
                    url: "/API/Projects/"
                }).success(function(data) {
                    $scope.projects = data;
                    $scope.model.isLoading = false;
                }).error(function(data) {
                    $scope.projects = [];
                    $scope.model.isLoading = false;
                });
            }

            $scope.listProjects();
        }
    ])
    .controller('NewProjectCtrl', [
        '$scope', '$http', '$modalInstance',
        function ($scope, $http, $modalInstance) {
            $scope.model = {
                isSaving: false
            };

            $scope.project = {
                name: "",
                description: ""
            };

            $scope.ok = function () {
                $http({
                    method: "PUT",
                    url: "/API/Projects/",
                    data: $scope.project
                }).success(function (data) {
                    $modalInstance.close(data);
                });
                
            };
        }
    ]);

