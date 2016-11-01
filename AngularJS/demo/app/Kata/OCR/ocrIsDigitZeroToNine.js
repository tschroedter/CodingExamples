ocrApp.factory('ocrIsDigitOneToNine',
    function () {
        var instance = {};

        instance.isDigitNumber0 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: "| |",
                bottom: "|_|",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber1 = function (actual) {
            const expected = {
                top:    "   ",
                middle: "  |",
                bottom: "  |",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber2 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: " _|",
                bottom: "|_ ",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber3 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: " _|",
                bottom: " _|",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber4 = function (actual) {
            const expected = {
                top:    "   ",
                middle: "|_|",
                bottom: "  |",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber5 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: "|_ ",
                bottom: " _|",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber6 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: "|_ ",
                bottom: "|_|",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber7 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: "  |",
                bottom: "  |",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber8 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: "|_|",
                bottom: "|_|",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        instance.isDigitNumber9 = function (actual) {
            const expected = {
                top:    " _ ",
                middle: "|_|",
                bottom: " _|",
                space:  "   "
            };

            if (expected.top == actual.top &
                expected.middle == actual.middle &
                expected.bottom == actual.bottom &
                expected.space == actual.space)
            {
                return true;
            }

            return false;
        };

        return instance;
    });
