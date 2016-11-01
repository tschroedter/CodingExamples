ocrApp.factory('ocrChecksumValidator',
    function () {
        var instance = {};

        const ExpectedLinesCount = 9;
        
        instance.isNumberValid = function (numbers) {
            if (numbers.length != ExpectedLinesCount) {
                return false;
            }

            var sum = numbers[numbers.length-1];

            for(var i = numbers.length-2, factor = 2; i>=0; i--, factor++ )
            {
                sum += numbers[i] * factor;
            }

            var result = sum % 11 == 0;
            
            return result;
        };

    return instance;
});
