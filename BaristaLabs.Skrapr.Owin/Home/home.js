///#source 1 1 /Home/app.js
angular.module('ngSkrapr', ['ngSanitize', 'ngRoute', 'ui.bootstrap', 'ui.router'])
    .config([
        '$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {

            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state('Home', {
                    url: "/",
                    views: {
                        "navbar": {
                            templateUrl: "/NavBar"
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
                            templateUrl: "/NavBar"
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
                            templateUrl: "/NavBar"
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
                            templateUrl: "/StandardNavBar"
                        },
                        "pageContent": {
                            templateUrl: "/NotFound"
                        }
                    }
                });
        }
    ]);
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
