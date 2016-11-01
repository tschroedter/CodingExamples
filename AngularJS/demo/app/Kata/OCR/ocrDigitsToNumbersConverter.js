ocrApp.factory('ocrDigitsToNumbersConverter',
    function (ocrDigitToNumberConverter) {
        var instance = {};

        instance.digitsToNumbers = function (digits) {
            // todo no extra checking of lines
            var numbers = [];

            for (var i = 0; i < digits.length; i ++) {
                
                var number = ocrDigitToNumberConverter.digitToNumber(
                    ocrDigitToNumberConverter.isDigitNumberFunctions,
                    digits[i]);

                numbers.push(number);
            }

            return numbers;
        };

        return instance;
    });
