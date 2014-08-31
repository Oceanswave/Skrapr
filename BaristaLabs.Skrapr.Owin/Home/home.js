///#source 1 1 /Home/app.js
angular.module('ngSkrapr', ['ngSanitize', 'ngRoute', 'ui.bootstrap', 'ui.router', 'auth0'])
    .config([
        '$urlRouterProvider', '$stateProvider', 'authProvider', '$httpProvider', function ($urlRouterProvider, $stateProvider, authProvider, $httpProvider) {

            authProvider.init({
                domain: 'baristalabs.auth0.com',
                clientID: '1IftFqq8Vg4sIER3J247ed81AR1uDwvU',
                callbackURL: 'http://localhost:8888/dashboard',
                callbackOnLocationHash: true
            });

            authProvider.on('loginSuccess', ['$window', function ($window) {
                $window.location.href = "/dashboard";
            }]);

            $httpProvider.interceptors.push('authInterceptor');

            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state('Home', {
                    url: "/",
                    views: {
                        "navbar": {
                            templateUrl: "/NavBar",
                            controller: "NavBarCtrl"
                        },
                        "pageContent": {
                            templateUrl: "/Home",
                            controller: "HomeCtrl"
                        }
                    }
                })
                .state('CardsByColor', {
                    url: "/cards-by-color/{color}",
                    views: {
                        "navbar": {
                            templateUrl: "/NavBar",
                            controller: "NavBarCtrl"
                        },
                        "pageContent": {
                            templateUrl: "/CardsByColor",
                            controller: "CardsByColorCtrl"
                        }
                    }
                })
                .state('CardDetails', {
                    url: "/Details/{metaverseId}",
                    views: {
                        "navbar": {
                            templateUrl: "/NavBar",
                            controller: "NavBarCtrl"
                        },
                        "pageContent": {
                            templateUrl: "/CardDetails",
                            controller: "CardDetailsCtrl"
                        }
                    }
                })
                .state('NotFound', {
                    url: "/NotFound",
                    views: {
                        "navbar": {
                            templateUrl: "/NavBar",
                            controller: "NavBarCtrl"
                        },
                        "pageContent": {
                            templateUrl: "/NotFound"
                        }
                    }
                });
        }
    ])
    .run(['auth', function (auth) {

        auth.hookEvents();
    }]);
///#source 1 1 /Home/cardDetailsCtrl.js
angular.module('ngSkrapr')
.controller('CardDetailsCtrl', ['$scope', '$stateParams', '$http', function ($scope, $stateParams, $http) {

    $http({
        method: "GET",
        url: "/API/metaverseid/" + $stateParams.metaverseId
    }).success(function(data) {
        $scope.card = data;
    });
}]);
///#source 1 1 /Home/cardsByColorCtrl.js
angular.module('ngSkrapr')
.controller('CardsByColorCtrl', ['$scope', '$stateParams', '$http', function ($scope, $stateParams, $http) {
    $http({
        method: "GET",
        url: "/API/metaverseid/4635"
    }).success(function(data) {
        $scope.card = data;
    });
}]);
///#source 1 1 /Home/homeCtrl.js
angular.module('ngSkrapr')
.controller('HomeCtrl', ['$scope', function ($scope) {
}]);
///#source 1 1 /Home/navBarCtrl.js
angular.module('ngSkrapr')
    .controller('NavBarCtrl', [
        '$scope', '$stateParams', '$http', 'auth', '$window',
        function($scope, $stateParams, $http, auth, $window) {
            $scope.auth = auth;

            $scope.dashboard = function() {
                $window.location.href = "/dashboard";
            };

            $scope.signIn = function() {
                auth.signup({
                    popup: true
                }, function() {
                    // Success callback
                }, function() {
                    // Error callback
                });
            };

            $scope.signIn = function() {
                auth.signin({
                    popup: true
                }, function() {
                    // Success callback
                }, function() {
                    // Error callback
                });
            };

            $scope.signOut = function() {
                auth.signout();
            };
        }
    ]);

