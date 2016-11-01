describe('ocrLinesToPackOfFourLines', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (_ocrLinesToPackOfFourLines_) {
        sut = _ocrLinesToPackOfFourLines_;
    }));

    describe('ocrLinesToPackOfFourLines should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('return 2 pack of 4 lines for 8 lines', inject(function () {
            // Arrange
            var lines = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8";

            // Act
            var actual = sut.linesToPackOfFourLines(lines);

            // Assert
            expect(actual.length).toEqual(2);
        }));
        // todo more tests
    });
});

