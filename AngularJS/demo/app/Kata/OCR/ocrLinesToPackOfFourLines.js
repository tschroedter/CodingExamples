ocrApp.factory('ocrLinesToPackOfFourLines',
    function () {
        var instance = {};

        instance.linesToPackOfFourLines = function (linesText) {
            var lines = linesText.split("\r\n");

            var packOfFourLines = [];

            for (var i = 0, lineCount = 0; i < lines.length; i += 4, lineCount++) {
                
                var fourLines = [
                    lines[i],
                    lines[i + 1],
                    lines[i + 2],
                    lines[i + 3]
                ];

                packOfFourLines.push(fourLines);
            }

            return packOfFourLines;
        };

    return instance;
});
