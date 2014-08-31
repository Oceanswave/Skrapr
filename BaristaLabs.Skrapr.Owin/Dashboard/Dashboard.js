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
                .state('Home', {
                    url: "/projects",
                    views: {
                        "dashboard": {
                            templateUrl: "/dashboard/Projects",
                            controller: "ProjectsCtrl"
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

    $scope.signOut = function () {
        auth.signout();
    };
}]);
///#source 1 1 /Dashboard/projectsCtrl.js
angular.module('ngSkraprDashboard')
.controller('ProjectsCtrl', ['$scope', '$http', function ($scope, $http) {
    $http({
        method: "GET",
        url: "/API/Projects/"
    }).success(function(data) {
        console.log(data);
    });
}]);
