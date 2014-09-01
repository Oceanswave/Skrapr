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