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
        var q = JSON.stringify(data);
        urlSvr.query({q:q}, function (a) {
            console.log(a);
            $scope.form = a;

        });

    });

    $scope.$on('xi.save', function () {
        var newObject = new urlSvr;

        for (var i in $scope.form) {
            newObject[i] = $scope.form[i];
        }

        newObject.$save();
    });


   

    $scope.$on('xi.update', function () {
        urlSvr.update($scope.form);

    });

    $scope.$on('xi.delete', function () {
        if (confirm('Are you sure?')) {
            urlSvr.delete({ id: $scope.form.id });
        }
    });

});