describe('ocrDigitsToNumbersConverter', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (ocrDigitsToNumbersConverter) {
        sut = ocrDigitsToNumbersConverter;
    }));

    describe('ocrDigitToNumberConverter should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('returns 1,2,3,4,5,6,7,8,9 for valid digits 1-9', inject(function () {
            // Arrange
            var digitOne = {
                top: "   ",
                middle: "  |",
                bottom: "  |",
                space: "   "
            };

            var digitTwo = {
                top:    " _ ",
                middle: " _|",
                bottom: "|_ ",
                space:  "   "
            };

            var digitThree = {
                top:    " _ ",
                middle: " _|",
                bottom: " _|",
                space:  "   "
            };

            var digitFour = {
                top:    "   ",
                middle: "|_|",
                bottom: "  |",
                space:  "   "
            };

            var digitFive = {
                top:    " _ ",
                middle: "|_ ",
                bottom: " _|",
                space:  "   "
            };

            var digitSix = {
                top:    " _ ",
                middle: "|_ ",
                bottom: "|_|",
                space:  "   "
            };

            var digitSeven = {
                top:    " _ ",
                middle: "  |",
                bottom: "  |",
                space:  "   "
            };

            var digitEight = {
                top:    " _ ",
                middle: "|_|",
                bottom: "|_|",
                space:  "   "
            };

            var digitNine = {
                top:    " _ ",
                middle: "|_|",
                bottom: " _|",
                space:  "   "
            };

            var digits = [
                digitOne,
                digitTwo,
                digitThree,
                digitFour,
                digitFive,
                digitSix,
                digitSeven,
                digitEight,
                digitNine,
            ];

            // Act
            var actual = sut.digitsToNumbers(digits);

            // Assert
            expect(actual).toEqual([1,2,3,4,5,6,7,8,9]);
        }));
        it('returns 1,2,3,4,5,6,7,8,-1 for valid digits 1-8 and 9 invalid', inject(function () {
            // Arrange
            var digitOne = {
                top: "   ",
                middle: "  |",
                bottom: "  |",
                space: "   "
            };

            var digitTwo = {
                top:    " _ ",
                middle: " _|",
                bottom: "|_ ",
                space:  "   "
            };

            var digitThree = {
                top:    " _ ",
                middle: " _|",
                bottom: " _|",
                space:  "   "
            };

            var digitFour = {
                top:    "   ",
                middle: "|_|",
                bottom: "  |",
                space:  "   "
            };

            var digitFive = {
                top:    " _ ",
                middle: "|_ ",
                bottom: " _|",
                space:  "   "
            };

            var digitSix = {
                top:    " _ ",
                middle: "|_ ",
                bottom: "|_|",
                space:  "   "
            };

            var digitSeven = {
                top:    " _ ",
                middle: "  |",
                bottom: "  |",
                space:  "   "
            };

            var digitEight = {
                top:    " _ ",
                middle: "|_|",
                bottom: "|_|",
                space:  "   "
            };

            var digitNine = {
                top:    " _ ",
                middle: "|_|",
                bottom: " _|",
                space:  "***"
            };

            var digits = [
                digitOne,
                digitTwo,
                digitThree,
                digitFour,
                digitFive,
                digitSix,
                digitSeven,
                digitEight,
                digitNine,
            ];

            // Act
            var actual = sut.digitsToNumbers(digits);

            // Assert
            expect(actual).toEqual([1,2,3,4,5,6,7,8,-1]);
        }));
    });
});

