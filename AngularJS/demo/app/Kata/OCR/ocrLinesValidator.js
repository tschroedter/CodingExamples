ocrApp.factory('ocrLinesValidator',
    function () {
        var instance = {};

        const ExpectedLinesCount = 4;
        const ExpectedColumnsCount = 27;
        
        instance.areLinesValid = function (lines) {
            if (lines.length != ExpectedLinesCount) {
                return false;
            }

            for (var i = 0; i < lines.length; i++) {
                if (lines[i].length != ExpectedColumnsCount) {
                    return false;
                }
            }

            return true;
        };

    return instance;
});
