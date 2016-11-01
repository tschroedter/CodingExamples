describe('ocrController', function () {
    beforeEach(module('ocrApp'));

    var mockScope = {};
    var mockNotificationService = {};
    var mockOcrLinesToPackOfFourLines = {
        name: "Mock",
        query: jasmine.createSpy('linesToPackOfFourLines',
        function (test){ console.log("???" + test); return [];} )
    };
    var mockOcrLinesValidator = {};
    var mockOcrTextToNumbersConverter = {
        query: jasmine.createSpy('validatePackOfFourLines')
    };
    var mockOcrChecksumValidator = {};
    var mockOcrNumbersChecksumValidator = {};

    function createSut($controller) {
        return $controller('ocrController', {
            $scope: mockScope,
            notificationService: mockNotificationService,
            ocrLinesToPackOfFourLines: mockOcrLinesToPackOfFourLines,
            ocrLinesValidator: mockOcrLinesValidator,
            ocrTextToNumbersConverter: mockOcrTextToNumbersConverter,
            ocrChecksumValidator: mockOcrChecksumValidator,
            ocrNumbersChecksumValidator: mockOcrNumbersChecksumValidator
        });
    }

    describe('ocrController should', function () {

        it('be defined', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController;

            expect(actual).toBeDefined();
        }));

        it('set scope', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.scope;

            expect(actual).toBeDefined();
        }));

        it('set ocrLinesToPackOfFourLines', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.ocrLinesToPackOfFourLines;

            expect(actual).toBeDefined();
        }));

        it('set ocrLinesValidator', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.ocrLinesValidator;

            expect(actual).toBeDefined();
        }));

        it('set ocrTextToNumbersConverter', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.ocrTextToNumbersConverter;

            expect(actual).toBeDefined();
        }));

        it('set ocrChecksumValidator', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.ocrChecksumValidator;

            expect(actual).toBeDefined();
        }));

        it('set ocrNumbersChecksumValidator', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.ocrNumbersChecksumValidator;

            expect(actual).toBeDefined();
        }));

        it('set numbers', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.numbers;

            expect(actual).toBeDefined();
        }));

        it('sets linesText to default', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.linesText;

            expect(actual.length).toBeGreaterThan(0);
        }));

        it('sets numbersText to default', inject(function ($controller) {
            // Arrange
            // Act
            createSut($controller);

            // Assert
            var actual = mockScope.ocrController.numbersText;

            expect(actual.length).toBeGreaterThan(0);
        }));

        it('numberToString returns 123456789 for [1,2,3,4,5,6,7,8,9]', inject(function ($controller) {
            // Arrange
            var expected = "123456789";
            var number = [1,2,3,4,5,6,7,8,9];
            createSut($controller);

            // Act
            var actual = mockScope.ocrController.numberToString(number);

            // Assert
            expect(actual).toEqual(expected);
        }));

        it('numberToString returns 12345678? for [1,2,3,4,5,6,7,8,-1]', inject(function ($controller) {
            // Arrange
            var expected = "12345678?";
            var number = [1,2,3,4,5,6,7,8,-1];
            createSut($controller);

            // Act
            var actual = mockScope.ocrController.numberToString(number);

            // Assert
            expect(actual).toEqual(expected);
        }));

        it('resultToString returns string for single info instance', inject(function ($controller) {
            // Arrange
            var expected = "123456789 \r\n";
            var info = {
                number: [1,2,3,4,5,6,7,8,9],
                isValid: true,
                isValidText: ""
            };

            var result = [info];

            createSut($controller);

            // Act
            var actual =
                mockScope
                    .ocrController
                    .resultToString(
                        mockScope.ocrController,
                        result);

            // Assert
            expect(actual).toEqual(expected);
        }));

        it('resultToString returns string for multiple info instances', inject(function ($controller) {
            // Arrange
            var expected = "123456789 \r\n12345678? ERR\r\n";
            var infoOne = {
                number: [1,2,3,4,5,6,7,8,9],
                isValid: true,
                isValidText: ""
            };
            var infoTwo = {
                number: [1,2,3,4,5,6,7,8,-1],
                isValid: false,
                isValidText: "ERR"
            };

            var result = [infoOne, infoTwo];

            createSut($controller);

            // Act
            var actual =
                mockScope
                    .ocrController
                    .resultToString(
                        mockScope.ocrController,
                        result);

            // Assert
            expect(actual).toEqual(expected);
        }));

        it('onClickValidate calls linesToPackOfFourLines', inject(function ($controller) {
            // Arrange
            createSut($controller);
            mockScope
                .ocrController.linesText = "abc";

            // Act
            var actual =
                mockScope
                    .ocrController
                    .onClickValidate(
                        mockScope.ocrController,
                        "");

            // Assert
            expect(mockOcrLinesToPackOfFourLines.linesToPackOfFourLines).toHaveBeenCalled();
        }));
    });
});

