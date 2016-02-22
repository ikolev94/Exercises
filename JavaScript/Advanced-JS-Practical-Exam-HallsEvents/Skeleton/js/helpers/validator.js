define([], function () {
    "use strict";
    return (function () {
        var CONSTANTS = {
            BOOLEAN: 'boolean',
            STRING: 'string',
            TITLE: 'title',
            NAME: 'name',
            DATE: 'date',
            TYPE: 'type',
            DURATION: 'duration',
            NUMBER: 'number'
        };

        function validateString(title, name) {
            if (typeof title !== 'string' || !/^[a-zA-Z ]+$/g.test(title)) {
                throw new Error('Invalid ' + name);
            }
        }

        function validateBoolean(bool, name) {
            if (typeof bool !== 'boolean') {
                throw new Error('Invalid ' + name);
            }
        }

        function validateDate(date, name) {
            if (!(date instanceof Date)) {
                throw new Error('Invalid ' + name);
            }
        }

        function validateNumber(n, name) {
            if (typeof n !== 'number') {
                throw new Error('Invalid ' + name);
            }
        }

        return {
            validateBoolean: function (bool) {
                validateBoolean(bool, CONSTANTS.BOOLEAN);
            },
            validateTitle: function (title) {
                validateString(title, CONSTANTS.TITLE);
            },
            validateName: function (name) {
                validateString(name, CONSTANTS.NAME);
            },
            validateDate: function (date) {
                validateDate(date, CONSTANTS.DATE);
            },
            validateType: function (type) {
                validateString(type, CONSTANTS.TYPE);
            },
            validateDuration: function (duration) {
                validateNumber(duration, CONSTANTS.DURATION);
            },
            validateNumber: function (count) {
                validateNumber(count, CONSTANTS.NUMBER);
            },
            validateInstance: function (obj, instance) {
                if (!(obj instanceof instance)) {
                    throw new Error('Invalid ' + instance.name);
                }
            }
        };
    }());
});