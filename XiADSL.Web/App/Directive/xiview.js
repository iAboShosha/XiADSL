XiApp.directive("xiview", function () {
    return {
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: {
            model: '=',
            view: '@',
            mode: '@'

        },
        controller: function ($scope, $resource, $location, $routeParams) {


            var url = "/view?v=" + $scope.view + '-' + $scope.mode;

            $resource(url).query(function (d) {

                var dd = d.sort(function (a, b) {
                    if (a.row == b.row)
                        return (a.sort > b.sort) ? 1 : -1;
                    else return (a.row > b.row) ? 1 : -1;
                });

                var grouped = [];
                for (var i in dd) {
                    var x = dd[i];
                    if (x.name) {
                        grouped[x.row] = grouped[x.row] || [];
                        grouped[x.row].push(x); // [x.sort] = x;
                    }
                }

                $scope.meta = grouped;
                $scope.rawMeta = dd;

                $scope.saveMeta = function () {
                    $scope.$emit('xi.saveMeta', $scope.rawMeta);
                    $location.path('/view/' + $scope.mode + '/' + $scope.view);
                };
                $scope.save = function () {
                    $scope.$emit('xi.save');
                    $location.path('/view/list/' + $scope.view);
                };

                $scope.update = function () {
                    $scope.$emit('xi.update');
                    $location.path('/view/list/' + $scope.view);
                };

                $scope.viewUpdate = function (v) {
                    $location.path('/view/edit/' + $scope.view + '/' + v.id);
                };

                $scope.viewCreate = function (v) {
                    $location.path('/view/new/' + $scope.view);
                };

                $scope.editMetadata = function (v) {
                    $location.path('/metadata/' + $scope.view + '/' + $scope.mode);
                };



                $scope.delete = function (itemid) {
                    $scope.$emit('xi.delete');
                };

            }, function (response) {
                if (response.status === 404) {
                    $resource('/API/' + $scope.view + '/CreateMeta?fileName=' + $scope.view + '-' + $scope.mode).query();
                }
            });

        },
        templateUrl: function (z, a) {
            return 'app/template/share/xiview-' + a.mode + '.html';
        }
    };
}
        );