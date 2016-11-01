'use strict';

var ocrApp = angular.module('ocrApp', []);

ocrApp.factory('notificationService', function () {
    return {
        alert: function (message) {
            alert(message);
        }
    };
});