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
