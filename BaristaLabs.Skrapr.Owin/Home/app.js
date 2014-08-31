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