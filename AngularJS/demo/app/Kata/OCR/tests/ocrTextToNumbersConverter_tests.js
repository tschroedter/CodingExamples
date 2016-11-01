describe('ocrTextToNumbersConverter', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (_ocrTextToNumbersConverter_) {
        sut = _ocrTextToNumbersConverter_;
    }));

    describe('ocrTextToNumbersConverter should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('return numbers for valid text', inject(function () {
            // Arrange
            var expected =
                [
                    [1,2,3,4,5,6,7,8,9],
                    [1,2,3,4,5,6,7,8,9],
                    [1,2,3,4,5,6,7,8,9]
                ];

            var linesText  = "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|\r\n                           \r\n";
            linesText += "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|\r\n                           \r\n";
            linesText += "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|\r\n                           ";

            // Act
            var actual = sut.convert(sut, linesText);

            // Assert
            expect(actual).toEqual(expected);
        }));
    });
});

