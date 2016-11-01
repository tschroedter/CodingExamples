describe('ocrLinesValidator', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (_ocrLinesValidator_) {
        sut = _ocrLinesValidator_;
    }));

    describe('ocrLinesValidator should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('return true for valid lines', inject(function () {
            // Arrange
            var validLines = [
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           "
            ];

            // Act
            var actual = sut.areLinesValid(validLines);

            // Assert
            expect(actual).toBeTruthy();
        }));

        it('return false for empty array', inject(function () {
            // Arrange
            // Act
            var actual = sut.areLinesValid([]);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('return false for too many lines', inject(function () {
            // Arrange
            var invalidLines = [
                "   _  _     _  _  _  _  _  ",
                " | _| _||_||_ |_   ||_||_| ",
                " ||_  _|  | _||_|  ||_| _| ",
                "                           ",
                "   _  _     _  _  _  _  _  "
            ];

            // Act
            var actual = sut.areLinesValid(invalidLines);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('return false for not enough lines', inject(function () {
            // Arrange
            var invalidLines = [
                "   _  _     _  _  _  _  _  ",
                " | _| _||_||_ |_   ||_||_| "
            ];

            // Act
            var actual = sut.areLinesValid(invalidLines);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('return false for wrong line length', inject(function () {
            // Arrange
            var invalidLines = [
                "   _  _     _  _  _  _  _  ",
                " | _| _||_||_ |_   ||_||_| ",
                " ||_  _|  | _||_|  ||_| _| ",
                "                           TOO LONG"
            ];

            // Act
            var actual = sut.areLinesValid(invalidLines);

            // Assert
            expect(actual).toBeFalsy();
        }));
    });
});

