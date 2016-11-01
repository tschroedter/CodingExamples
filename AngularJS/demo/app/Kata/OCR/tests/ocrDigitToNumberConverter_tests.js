describe('ocrDigitToNumberConverter', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (ocrDigitToNumberConverter) {
        sut = ocrDigitToNumberConverter;
    }));

    describe('ocrDigitToNumberConverter should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('returns 0 for valid digit one', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "| |",
                bottom: "|_|",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(0);
        }));

        it('returns 1 for valid digit one', inject(function () {
            // Arrange
            var digit = {
                top: "   ",
                middle: "  |",
                bottom: "  |",
                space: "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(1);
        }));

        it('returns 2 for valid digit two', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: " _|",
                bottom: "|_ ",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(2);
        }));

        it('returns 3 for valid digit three', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: " _|",
                bottom: " _|",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(3);
        }));

        it('returns 4 for valid digit four', inject(function () {
            // Arrange
            var digit = {
                top:    "   ",
                middle: "|_|",
                bottom: "  |",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(4);
        }));

        it('returns 5 for valid digit five', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_ ",
                bottom: " _|",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(5);
        }));

        it('returns 6 for valid digit six', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_ ",
                bottom: "|_|",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(6);
        }));

        it('returns 7 for valid digit seven', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "  |",
                bottom: "  |",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(7);
        }));

        it('returns 8 for valid digit eight', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_|",
                bottom: "|_|",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(8);
        }));

        it('returns 9 for valid digit nine', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_|",
                bottom: " _|",
                space:  "   "
            };

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(9);
        }));

        it('throws error for invalid digit', inject(function () {
            // Arrange
            var digit = [
                "   ",
                "  |",
                "  |",
                "***",
            ];

            // Act
            var actual = sut.digitToNumber(
                sut.isDigitNumberFunctions,
                digit);

            // Assert
            expect(actual).toEqual(-1);
        }));
    });
});

