describe('ocrNumbersChecksumValidator', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (_ocrNumbersChecksumValidator_) {
        sut = _ocrNumbersChecksumValidator_;
    }));

    describe('ocrNumbersChecksumValidator should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        var assertInfo = function (expected, actual) {
            expect(actual.number).toEqual(expected.number);
            expect(actual.isValid).toEqual(expected.isValid);
            expect(actual.isValidText).toEqual(expected.isValidText);
        };

        it('return Valid when areNumbersValid is called with [[1,2,3,4,5,6,7,8,9]]', inject(function () {
            // Arrange
            var expected = {
                number: [1,2,3,4,5,6,7,8,9],
                isValid: true,
                isValidText: ""
            };

            var numbers = [expected.number];

            // Act
            var actual = sut.areNumbersValid(sut, numbers);

            // Assert
            expect(actual.length).toEqual(1);
            assertInfo(expected, actual[0]);
        }));

        it('return Valid, Valid when areNumbersValid is called with [[3,4,5,8,8,2,8,6,5],[3,4,5,8,8,2,8,6,5]]', inject(function () {
            // Arrange
             var expected = {
                 number: [3,4,5,8,8,2,8,6,5],
                 isValid: true,
                 isValidText: ""
             };

            var numbers = [expected.number,expected.number];

            // Act
            var actual = sut.areNumbersValid(sut, numbers);

            // Assert
            expect(actual.length).toEqual(2);
            assertInfo(expected, actual[0]);
            assertInfo(expected, actual[1]);
        }));

        it('return Valid, Invalid when areNumbersValid is called with [[1,2,3,4,5,6,7,8,9],[2,2,3,4,5,6,7,8,9]]', inject(function () {
            // Arrange
            var expectedValid = {
                number: [1,2,3,4,5,6,7,8,9],
                isValid: true,
                isValidText: ""
            };

            var expectedInvalid = {
                number: [2,2,3,4,5,6,7,8,9],
                isValid: false,
                isValidText: "ILL"
            };

            var numbers = [expectedValid.number, expectedInvalid.number];

            // Act
            var actual = sut.areNumbersValid(sut, numbers);

            // Assert
            expect(actual.length).toEqual(2);
            assertInfo(expectedValid, actual[0]);
            assertInfo(expectedInvalid, actual[1]);
        }));

        it('return Err when areNumbersValid is called with [[3,4,5,8,8,2,8,6,-1]]', inject(function () {
            // Arrange
            var expectedInvalid = {
                number: [3,4,5,8,8,2,8,6,-1],
                isValid: false,
                isValidText: "ERR"
            };

            var numbers = [expectedInvalid.number];

            // Act
            var actual = sut.areNumbersValid(sut, numbers);

            // Assert
            expect(actual.length).toEqual(1);
            assertInfo(expectedInvalid, actual[0]);
        }));
    });
});

