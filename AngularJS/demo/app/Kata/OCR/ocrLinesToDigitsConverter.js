ocrApp.factory('ocrLinesToDigitsConverter',
    function () {
        var instance = {};

        instance.linesToDigits = function (lines) {
            // todo no extra checking of lines
            var digits = [];

            for (var i = 0; i < lines[0].length; i += 3) {
                var digit = {};

                digit.top = lines[0].substring(i, i + 3);
                digit.middle = lines[1].substring(i, i + 3);
                digit.bottom = lines[2].substring(i, i + 3);
                digit.space = lines[3].substring(i, i + 3);

                digits.push(digit);
            }

            return digits;
        };

        return instance;
    });
