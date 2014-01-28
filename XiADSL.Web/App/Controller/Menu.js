XiApp.controller('menuCtrl', function ($scope, $resource) {
    $scope.menu = $resource('/menu.json').query();
});
