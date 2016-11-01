ocrApp.factory('ocrNumbersChecksumValidator',
    function (ocrChecksumValidator) {
        var instance = {};

        instance.areAllNumbersValidNumbers = function (numbers) {
            for (var j = 0; j < numbers.length; j++)
            {
                var integer = numbers[j];
                if (!(integer >= 0 && integer <= 9))
                {
                    return false;
                }
            }

            return true; // todo testing
        };

        instance.determineStatus = function (self, numbers) {
            var areAllNumbers = self.areAllNumbersValidNumbers(numbers);

            if (!areAllNumbers)
            {
                return "ERR";
            }

            var isChecksumValid =
                ocrChecksumValidator
                    .isNumberValid(numbers);

            var text = "";

            if (!isChecksumValid)
            {
                text = "ILL";
            }

            return text;
        };
        
        instance.areNumbersValid = function (self, numbers) {

            if (numbers.length == 0) {
                return "";
            }

            var result = [];

            for(var i = 0; i < numbers.length; i++)
            {
                var oneSetOfNumbers = numbers[i];

                var status = self.determineStatus(self, oneSetOfNumbers);

                var isValid = status == "";

                var info = {
                    number: oneSetOfNumbers,
                    isValid: isValid,
                    isValidText: status
                };

                result.push(info);
            }

            return result;
        };

    return instance;
});
