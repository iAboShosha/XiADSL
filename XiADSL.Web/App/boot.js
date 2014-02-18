var XiApp = angular.module('xiApp', ['ngRoute', 'ngResource', 'kendoui']);





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