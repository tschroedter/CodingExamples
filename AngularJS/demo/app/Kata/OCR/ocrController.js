ocrApp.controller('ocrController',
    function ($scope,
              notificationService,
              ocrLinesToPackOfFourLines,
              ocrLinesValidator,
              ocrTextToNumbersConverter,
              ocrChecksumValidator,
              ocrNumbersChecksumValidator) {

        var createController =
            function (scope,
                      notificationService,
                      ocrLinesToPackOfFourLines,
                      ocrLinesValidator,
                      ocrTextToNumbersConverter,
                      ocrChecksumValidator,
                      ocrNumbersChecksumValidator) {
                var controller = {
                    scope: scope,
                    notificationService: notificationService, // todo testing
                    ocrLinesToPackOfFourLines: ocrLinesToPackOfFourLines,
                    ocrLinesValidator: ocrLinesValidator,
                    ocrTextToNumbersConverter: ocrTextToNumbersConverter,
                    ocrChecksumValidator: ocrChecksumValidator,
                    ocrNumbersChecksumValidator: ocrNumbersChecksumValidator,
                    linesText: "",
                    numbers: [],
                    numbersText: "",
                    numbersChecksumText: "",
                    
                    init: function () {
                        this.linesText  = "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|\r\n                           \r\n";
                        this.linesText += "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|\r\n                           \r\n";
                        this.linesText += " _  _  _     _  _  _  _  _ \r\n _| _| _||_||_ |_   ||_||_|\r\n|_ |_  _|  | _||_|  ||_| _|\r\n                           \r\n";
                        this.linesText += "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|\r\n                        ???"; // todo testing not empty
                        this.numbers = [];
                        this.numbersText = "---------\r\n---------\r\n---------\r\n---------"; // todo testing not empty
                        this.numbersChecksumText = "Invalid\r\nInvalid\r\nInvalid"; // todo testing not empty
                    },

                    onClickValidate: function (ocrController) {
                        // todo testing function
                        
                        var packOfFourLines =
                            ocrController
                                .ocrLinesToPackOfFourLines
                                .linesToPackOfFourLines(
                            ocrController.linesText);

                        ocrController.ocrTextToNumbersConverter.validatePackOfFourLines(packOfFourLines, ocrController); // todo swap parameters
                    },

                    onClickConvert: function (ocrController) {
                        // todo testing function

                        ocrController.numbers = ocrController
                            .ocrTextToNumbersConverter
                            .convert(
                                ocrController.ocrTextToNumbersConverter,
                                ocrController.linesText);

                        ocrController.numbersText = "";

                        for(var i=0; i < ocrController.numbers.length; i++) {
                            ocrController.numbersText += ocrController.numbers[i].join("");
                            ocrController.numbersText += "\r\n";
                        }
                    },

                    numberToString: function (number) {

                        var numberWithoutMinusOne = [];

                        for(var j = 0; j < number.length; j++)
                        {
                            if (number[j] < 0 || number[j] > 9)
                            {
                                numberWithoutMinusOne.push("?");
                            }
                            else {
                                numberWithoutMinusOne.push(number[j].toString());
                            }
                        }
                        numberWithoutMinusOne = numberWithoutMinusOne.join("");

                        return numberWithoutMinusOne;
                    },

                    resultToString: function (ocrController, result) {

                        var text = "";

                        for(var i = 0; i < result.length; i++)
                        {
                            var number = ocrController.numberToString(result[i].number);

                            text += number + " ";
                            text += result[i].isValidText + "\r\n";
                        }

                        return text;
                    },

                    onClickChecksumValidate: function (ocrController) {
                        // todo testing function
                        var result =
                            ocrController
                                .ocrNumbersChecksumValidator
                                .areNumbersValid(
                                    ocrController.ocrNumbersChecksumValidator,
                                    ocrController.numbers);

                        var text =
                            ocrController
                                .resultToString(
                                    ocrController,
                                    result);

                        ocrController.numbersChecksumText = text;
                    }
                };

                controller.init();

                return controller;
            };

        $scope.ocrController =
            createController(
                $scope,
                notificationService,
                ocrLinesToPackOfFourLines,
                ocrLinesValidator,
                ocrTextToNumbersConverter,
                ocrChecksumValidator,
                ocrNumbersChecksumValidator);
    });