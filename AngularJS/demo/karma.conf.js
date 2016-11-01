// Karma configuration
// Generated on Thu Apr 21 2016 12:01:55 GMT+1000 (AUS Eastern Standard Time)

module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '',


    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine'],


    // list of files / patterns to load in the browser
    files: [
      'node_modules/angular/angular.js',
      'node_modules/angular-mocks/angular-mocks.js',
      'node_modules/angular-resource/angular-resource.js',
      'app/mainApp.js',
      'app/daysView/**/*.js',
      'app/doctorSlotsView/**/*.js',
      'app/doctorsView/**/*.js',
      'app/slotsView/**/*.js',
      'app/bookingView/**/*.js',
      'app/Kata/OCR/ocrApp.js',
      'app/Kata/OCR/ocrLinesToPackOfFourLines.js',
      'app/Kata/OCR/ocrLinesValidator.js',
      'app/Kata/OCR/ocrIsDigitZeroToNine.js',
      'app/Kata/OCR/ocrDigitToNumberConverter.js',
      'app/Kata/OCR/ocrDigitsToNumbersConverter.js',
      'app/Kata/OCR/ocrLinesToDigitsConverter.js',
      'app/Kata/OCR/ocrTextToNumbersConverter.js',
      'app/Kata/OCR/ocrChecksumValidator.js',
      'app/Kata/OCR/ocrNumbersChecksumValidator.js',
      'app/Kata/OCR/ocrController.js',
      'app/Kata/OCR/tests/*_tests.js',
      'tests/**/*.js'
    ],


    // list of files to exclude
    exclude: [
    ],


    // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
    },


    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    browsers: ['PhantomJS'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: false
  })
};
