describe('ocrIsDigitOneToNine', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (ocrIsDigitOneToNine) {
        sut = ocrIsDigitOneToNine;
    }));

    describe('ocrIsDigitOneToNine should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('returns true for valid digit one', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "| |",
                bottom: "|_|",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber0(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit one', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "| |",
                bottom: "| |",
                space: "***"
            };

            // Act
            var actual = sut.isDigitNumber0(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit one', inject(function () {
            // Arrange
            var digit = {
                top: "   ",
                middle: "  |",
                bottom: "  |",
                space: "   "
            };

            // Act
            var actual = sut.isDigitNumber1(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit one', inject(function () {
            // Arrange
            var digit = {
                top: "   ",
                middle: "  |",
                bottom: "  |",
                space: "***"
            };

            // Act
            var actual = sut.isDigitNumber1(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit two', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: " _|",
                bottom: "|_ ",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber2(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit two', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: " _|",
                bottom: "|_ ",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber2(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit three', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: " _|",
                bottom: " _|",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber3(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit three', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: " _|",
                bottom: " _|",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber3(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit four', inject(function () {
            // Arrange
            var digit = {
                top:    "   ",
                middle: "|_|",
                bottom: "  |",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber4(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit four', inject(function () {
            // Arrange
            var digit = {
                top:    "   ",
                middle: "|_|",
                bottom: "  |",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber4(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit five', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_ ",
                bottom: " _|",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber5(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit five', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_ ",
                bottom: " _|",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber5(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit six', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_ ",
                bottom: "|_|",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber6(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit six', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_ ",
                bottom: "|_|",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber6(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit seven', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "  |",
                bottom: "  |",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber7(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit seven', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "  |",
                bottom: "  |",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber7(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit eight', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_|",
                bottom: "|_|",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber8(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit eight', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_|",
                bottom: "|_|",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber8(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('returns true for valid digit nine', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_|",
                bottom: " _|",
                space:  "   "
            };

            // Act
            var actual = sut.isDigitNumber9(digit);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('returns false for invalid digit nine', inject(function () {
            // Arrange
            var digit = {
                top:    " _ ",
                middle: "|_|",
                bottom: " _|",
                space:  "***"
            };

            // Act
            var actual = sut.isDigitNumber9(digit);

            // Assert
            expect(actual).toBeFalsy();
        }));
    });
});

