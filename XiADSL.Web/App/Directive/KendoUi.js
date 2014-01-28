var ngKendoui = angular.module("kendoui", []);

ngKendoui.directive('kuiMselect', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            model: '=',
            url: '@',
            enable:'='
        },
        template: '<div></div>',
        link: function (scope, element, attrs) {

            var createControl = function (value) {
                 console.log(attrs)
                $(element[0]).kendoMultiSelect({
                    //placeholder: "Select products...",
                    dataTextField: "name",
                    dataValueField: "id",
                    autoBind: false,
                    enable:scope.enable,
                    change: function () {
                        scope.model = this.dataItems();
                    },
                    select: function () {
                        scope.model = this.dataItems();
                    },
                    dataSource: {
                        serverFiltering: true,
                        transport: {
                            read: {
                                url: attrs.url,
                                data: function () {
                                    return { text: $(element[0]).data('kendoMultiSelect').input.val() };
                                }
                            }
                        }
                    },
                    value: value
                });

                scope.$watch('model', function (a,b) {
                    var multiselect = $(element[0]).data("kendoMultiSelect");
                    if (!b) {
                        multiselect.value([]);
                        multiselect.refresh();
                    }
                });

            };




            if (scope.model && scope.model.promise) {
                scope.model.promise.then(function (r) {
                    scope.model = r;
                    createControl(r);
                });
            } else {
                createControl(scope.model);
            }

        }
    };
});


ngKendoui.directive('kuiCombobox', function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            model: '=',
            emodel: '=',
            kdisable:'=',
            url: '@'

        },
        template: '<div></div>',
        link: function (scope, element, attrs) {

            var createControl = function (value) {
                $(element[0]).kendoMultiSelect({
                    //placeholder: "Select products...",
                    dataTextField: "name",
                    dataValueField: "id",
                    autoBind: false,
                    enable:scope.kdisable,
                    maxSelectedItems: 1,
                    change: function () {
                        scope.model = this.dataItems()[0].id;
                        scope.$digest();
                    },
                    select: function () {
                        scope.model = this.dataItems().id;
                    },
                    dataSource: {
                        serverFiltering: true,
                        transport: {
                            read: {
                                url: attrs.url,
                                data: function () {
                                    return { text: $(element[0]).data('kendoMultiSelect').input.val() };
                                }
                            }
                        }
                    },
                    value: value
                });
                
                //scope.$watch('model', function (a,b) {
                //    var multiselect = $(element[0]).data("kendoMultiSelect");
                //    if (!b) {
                //        multiselect.value([]);
                //        multiselect.refresh();
                //    }
                //});
            };



            if (scope.model && scope.model.promise) {
                scope.model.promise.then(function (r) {
                    //scope.model = r;
                    console.log('promise')
                    createControl(r);
                });
            } else {
                console.log(scope.emodel, scope.model);

                createControl(scope.emodel);
            }

        }
    };
});