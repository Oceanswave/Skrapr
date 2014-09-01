///#source 1 1 /Dashboard/app.js
angular.module('ngSkraprDashboard', ['ngSanitize', 'ngRoute', 'ui.bootstrap', 'ui.router', 'auth0'])
    .config([
        '$urlRouterProvider', '$stateProvider', 'authProvider', '$httpProvider',
        function($urlRouterProvider, $stateProvider, authProvider, $httpProvider) {

            authProvider.init({
                domain: 'baristalabs.auth0.com',
                clientID: '1IftFqq8Vg4sIER3J247ed81AR1uDwvU',
                callbackURL: 'http://localhost:8888/dashboard',
                callbackOnLocationHash: true
            });

            authProvider.on('loginFailure', ['$window', function ($window) {
                $window.location.href = "/";
            }]);

            authProvider.on('forbidden', ['$window', function ($window) {
                $window.location.href = "/";
            }]);

            authProvider.on('logout', ['$window', function ($window) {
                $window.location.href = "/";
            }]);

            $httpProvider.interceptors.push('authInterceptor');

            $urlRouterProvider.otherwise("/projects");

            $stateProvider
                .state('Projects', {
                    url: "/projects",
                    views: {
                        "dashboard": {
                            templateUrl: "/dashboard/Projects",
                            controller: "ProjectsCtrl"
                        }
                    }
                })
                .state('ProjectDetails', {
                    url: "/projects/{projectId}",
                    views: {
                        "dashboard": {
                            templateUrl: "/dashboard/ProjectDetails",
                            controller: "ProjectDetailsCtrl"
                        }
                    }
                })
                .state('ActiveTasks', {
                    url: "/activetasks",
                    views: {
                        "dashboard": {
                            templateUrl: "/dashboard/ActiveTasks",
                            controller: "ActiveTasksCtrl"
                        }
                    }
                });

        }
    ])
    .run([
        'auth', function(auth) {
            auth.hookEvents();
        }
    ]);
///#source 1 1 /Dashboard/dashboardCtrl.js
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
///#source 1 1 /Dashboard/projectsCtrl.js
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
                    $state.go("ProjectDetails", { projectId: project.Id });
                });
            };

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


///#source 1 1 /Dashboard/projectDetailsCtrl.js
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


///#source 1 1 /Dashboard/activeTasksCtrl.js
angular.module('ngSkraprDashboard')
    .controller('ActiveTasksCtrl', [
        '$scope', '$http', '$modal', '$stateParams',
        function($scope, $http, $modal, $stateParams) {
            
        }
    ]);


