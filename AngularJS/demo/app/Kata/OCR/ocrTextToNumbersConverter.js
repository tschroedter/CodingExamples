ocrApp.factory('ocrTextToNumbersConverter',
    function (ocrLinesToPackOfFourLines,
              ocrLinesValidator,
              ocrLinesToDigitsConverter,
              ocrDigitsToNumbersConverter) {
        var instance = {};

        instance.ocrLinesToPackOfFourLines =  ocrLinesToPackOfFourLines;
        instance.ocrLinesValidator = ocrLinesValidator;
        instance.ocrLinesToDigitsConverter = ocrLinesToDigitsConverter;
        instance.ocrDigitsToNumbersConverter = ocrDigitsToNumbersConverter;

        instance.validatePackOfFourLines = function (self, packOfFourLines) {

            for (var i = 0; i < packOfFourLines.length; i++) {

                if (!self.ocrLinesValidator.areLinesValid(packOfFourLines[i])) {
                    var message = "[" + i + "] Lines are invalid!";

                    self.notificationService.alert(message);

                    return false;
                }
            }

            return true;
        };

        instance.convert = function (self, text) {

            var packOfFourLines = self.ocrLinesToPackOfFourLines.linesToPackOfFourLines(text);

            var isValid = self.validatePackOfFourLines(
                self,
                packOfFourLines);

            if (!isValid) {
                return;
            }

            var numbers = [];


            for (var i = 0; i < packOfFourLines.length; i++) {

                var digits = self.ocrLinesToDigitsConverter.linesToDigits(packOfFourLines[i]);
                var numbersForDigits = self.ocrDigitsToNumbersConverter.digitsToNumbers(digits);

                numbers.push(numbersForDigits);
            }

            return numbers;
        };

        return instance;
    });
