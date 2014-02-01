XiApp.controller('MetaCtrl', function ($scope, $resource, $routeParams, $http, $location) {

    $scope.conf = {
        viewMode: $routeParams.viewMode,
        modelName: $routeParams.modelName,
        mode: $routeParams.modelName + '-' + $routeParams.viewMode
    };

    var url = "/view?v=" + $scope.conf.mode;

    $scope.rawMeta = $resource(url).query(function (d) {

        var dd = d.sort(function (a, b) {
            if (a.row == b.row)
                return (a.sort > b.sort) ? 1 : -1;
            else return (a.row > b.row) ? 1 : -1;
        });

        $scope.rawMeta = dd;



    });

    $scope.saveMeta = function () {
        var surl = 'View/saveMeta';


        if ($scope.rawMeta)
            $http({
                url: surl,
                method: "POST",
                data: { mode: $scope.conf.mode, meta: JSON.stringify($scope.rawMeta) },
                //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (pdata, status, headers, config) {
                $location.path('/view/' + $scope.conf.viewMode + '/' + $scope.conf.modelName );

            }).error(function (pdata, status, headers, config) {

            });

    };


});