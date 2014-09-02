angular.module('ngSkraprDashboard')
    .controller('ProjectDetailsCtrl', [
        '$scope', '$http', '$modal', '$stateParams',
        function($scope, $http, $modal, $stateParams) {
            $scope.project = null;
            $scope.skraprs = [];
            $scope.model = {
                isLoading: true
            };

            $scope.addNewSkrapr = function () {
                $modal.open({
                    templateUrl: 'new-skrapr-tmpl.html',
                    controller: "NewSkraprCtrl"
                }).result.then(function () {
                    $scope.listSkraprs($stateParams.projectId);
                });
            };

            $scope.listSkraprs = function (projectId) {
                $scope.model.isLoading = true;
                $http({
                    method: "GET",
                    url: "/API/Projects/" + projectId + "/Skraprs"
                }).success(function (data) {
                    $scope.skraprs = data;
                    $scope.model.isLoading = false;
                }).error(function (data) {
                    $scope.project = null;
                    $scope.model.isLoading = false;
                });
            };

            $scope.deleteSkrapr = function (projectId, skraprId) {
                $scope.model.isLoading = true;
                $http({
                    method: "DELETE",
                    url: "/API/Projects/" + projectId + "/Skraprs/" + skraprId
                }).success(function () {
                    $scope.listSkraprs();
                }).error(function (data) {
                    $scope.project = null;
                    $scope.model.isLoading = false;
                });
            };

            $scope.getProject = function (projectId) {
                $scope.model.isLoading = true;

                $http({
                    method: "GET",
                    url: "/API/Projects/" + projectId
                }).success(function(data) {
                    $scope.project = data;
                    $scope.listSkraprs(projectId);
                    $scope.model.isLoading = false;
                }).error(function(data) {
                    $scope.project = null;
                    $scope.model.isLoading = false;
                });
            };

            $scope.getProject($stateParams.projectId);
        }
    ])
    .controller('NewSkraprCtrl', [
            '$scope', '$http', '$stateParams', '$modalInstance',
            function ($scope, $http, $stateParams, $modalInstance) {
                $scope.model = {
                    isSaving: false
                };

                $scope.skrapr = {
                    name: "",
                    description: ""
                };

                $scope.ok = function () {
                    $http({
                        method: "PUT",
                        url: "/API/Projects/" + $stateParams.projectId + "/Skraprs",
                        data: $scope.skrapr
                    }).success(function (data) {
                        $modalInstance.close(data);
                    });

                };
            }
    ]);

