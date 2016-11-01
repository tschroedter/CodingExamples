describe('ocrChecksumValidator', function () {
    var sut;

    beforeEach(module('ocrApp'));
    
    beforeEach(inject(function (_ocrChecksumValidator_) {
        sut = _ocrChecksumValidator_;
    }));

    describe('ocrChecksumValidator should', function () {

        it('be defined', inject(function () {
            // Arrange
            // Act
            // Assert
            expect(sut).toBeDefined();
        }));

        it('return false when isNumberValid is called for []', inject(function () {
            // Arrange
            // Act
            var actual = sut.isNumberValid([]);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('return false when isNumberValid is called for to many numbers', inject(function () {
            // Arrange
            var numbers = [1,2,3,4,5,6,7,8,9,10];

            // Act
            var actual = sut.isNumberValid(numbers);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('return true when isNumberValid is called for [1,1,1,1,1,1,1,1,1,1]', inject(function () {
            // Arrange
            var numbers = [1,1,1,1,1,1,1,1,1,1];

            // Act
            var actual = sut.isNumberValid(numbers);

            // Assert
            expect(actual).toBeFalsy();
        }));

        it('return true when isNumberValid is called for [1,1,1,1,1,1,1,1,1,1]', inject(function () {
            // Arrange
            var numbers = [3,4,5,8,8,2,8,6,5];

            // Act
            var actual = sut.isNumberValid(numbers);

            // Assert
            expect(actual).toBeTruthy();
        }));
    });
});

