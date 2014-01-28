XiApp.controller('CoreCtrl', function ($scope, $resource, $routeParams) {

    $scope.conf = {
        viewMode: $routeParams.viewMode,
        modelName: $routeParams.modelName,
        id: $routeParams.id
    };
    
    var manager = new breeze.EntityManager("Api/customer");
    var query1a = breeze.EntityQuery.from('select').where('Name', 'startsWith', 'A');
        manager.executeQuery(query1a).then(function(a) {
            console.log('breeze', a);
        });
    

    var pa = null;
    if ($routeParams.q) {
        pa=JSON.parse($routeParams.q);
    }
    
    var url = 'API/' + $scope.conf.modelNamex;

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


    $scope.$on('xi.update', function () {
        urlSvr.update($scope.form);

    });

    $scope.$on('xi.delete', function () {
        if (confirm('Are you sure?')) {
            urlSvr.delete({ id: $scope.form.id });
        }
    });

});