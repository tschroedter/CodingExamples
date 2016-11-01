ocrApp.factory('ocrDigitToNumberConverter',
    function (ocrIsDigitOneToNine) {
        var instance = {};

        instance.isDigitNumberFunctions = [
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber0,
                number: 0
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber1,
                number: 1
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber2,
                number: 2
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber3,
                number: 3
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber4,
                number: 4
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber5,
                number: 5
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber6,
                number: 6
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber7,
                number: 7
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber8,
                number: 8
            },
            {
                isNumber: ocrIsDigitOneToNine.isDigitNumber9,
                number: 9
            }
        ];
        
        instance.digitToNumber = function (isDigitNumberFunctions, digit) {
            // todo no extra checking of the digit

            for(var i = 0; i < isDigitNumberFunctions.length; i++)
            {
                var functionAndValue = isDigitNumberFunctions[i];

                if (functionAndValue.isNumber(digit))
                {
                    return functionAndValue.number;
                }
            }

            return -1;
        };

        return instance;
    });
