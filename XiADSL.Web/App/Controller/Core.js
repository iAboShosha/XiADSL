XiApp.controller('CoreCtrl', function ($scope, $resource, $routeParams, $http) {

    $scope.conf = {
        viewMode: $routeParams.viewMode,
        modelName: $routeParams.modelName,
        id: $routeParams.id
    };


    var pa = null;
    if ($routeParams.q) {
        pa = JSON.parse($routeParams.q);
    }

    var url = 'API/' + $scope.conf.modelName;

    var urlSvr = $resource(url, pa, {
        update: { method: 'put' }
    });

    if ($scope.conf.viewMode == 'edit')
        $scope.form = urlSvr.get({ id: $scope.conf.id });
    else if ($scope.conf.viewMode == 'new')
        $scope.form = {};
    else if ($scope.conf.viewMode == 'list')
        $scope.form = urlSvr.query();


    $scope.$on('xi.query', function (event, data) {
        data = urlSvr.query();

    });

    $scope.$on('xi.save', function () {
        var newObject = new urlSvr;

        for (var i in $scope.form) {
            newObject[i] = $scope.form[i];
        }

        newObject.$save();
    });



    //$scope.$on('xi.saveMeta', function (event, data) {
    //    var url = 'API/' + $scope.conf.modelName + '/saveMeta';


    //    $http({
    //        url: url,
    //        method: "POST",
    //        data: { model: $scope.conf.viewMode, meta: JSON.stringify(data) },
    //        //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
    //    }).success(function (pdata, status, headers, config) {

    //    }).error(function (pdata, status, headers, config) {

    //    });


    //});

    $scope.$on('xi.update', function () {
        urlSvr.update($scope.form);

    });

    $scope.$on('xi.delete', function () {
        if (confirm('Are you sure?')) {
            urlSvr.delete({ id: $scope.form.id });
        }
    });

});