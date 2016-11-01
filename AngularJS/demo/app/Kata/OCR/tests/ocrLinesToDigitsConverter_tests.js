describe('ocrLinesToDigitsConverter', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (ocrLinesToDigitsConverter) {
        sut = ocrLinesToDigitsConverter;
    }));

    describe('ocrLinesToDigitsConverter should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));


        it('return digits for valid lines', inject(function () {
            // Arrange
            var validLines = [
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           "
            ];

            // Act
            var actual = sut.linesToDigits(validLines);

            // Assert
            expect(actual.length).toEqual(9);
        }));
        
        it('throws error for invalid lines', inject(function () {
            // Arrange
            var validLines = [
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
            ];

            // Act
            // Assert
            expect(function() { sut.linesToDigits(validLines); }).toThrow();
        }));
    });
});

