XiApp.factory('filterBuilder', function () {
    var b = function (o) {
        var str = '';

        for (var i in o) {
            if (o[i]) {
                if (str) {
                    str += ' and ' + i + ' eq ' + "'" + o[i] + "'";
                } else {
                    str += i + ' eq ' + "'" + o[i] + "'";
                }

            }
        }

        return str;
    };



    return {
        build: b
    };

});