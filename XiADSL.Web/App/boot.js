var XiApp = angular.module('xiApp', ['ngRoute', 'ngResource', 'kendoui', 'breeze.angular.q']);



XiApp.run(['$q', 'use$q', function ($q, use$q) {
    use$q($q);
}]);

XiApp.config(function($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'app/template/home.html'
        })
        .when('/view/:viewMode/:modelName/:id?', {
            templateUrl: 'app/template/xivewCore.html',
            controller: 'CoreCtrl'
        })
        .when('/metadata/:modelName/:viewMode', {
            templateUrl: 'app/template/ximetadata.html',
            controller: 'MetaCtrl'
        })
        ;
});