//var data = data || {};
Object.prototype.extends = function (parent) {
    "use strict";
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

data = (function () {
    var Popup = (function () {
        function Popup(title, message, type, position, autoHide, timeOut, closeButton, callback) {
            this._popupData = {
                title: title,
                message: message,
                type: type,
                position: position,
                autoHide: autoHide,
                timeOut: timeOut,
                closeButton: closeButton,
                callback: callback
            };
        }

        return Popup;
    })();

    var SuccessPop = (function () {
        function SuccessPop(title, message) {
            Popup.call(this, title, message, 'success', 'bottomLeft', true, 200);
        }

        return SuccessPop;
    })();

    var InfoPop = (function () {
        function InfoPop(title, message) {
            Popup.call(this, title, message, 'info', 'topLeft', false, false, true);
        }

        return InfoPop;
    })();

    var ErrorPop = (function () {
        function ErrorPop(title, message) {
            Popup.call(this, title, message, 'error', 'topRight');
        }

        return ErrorPop;
    })();

    var WarningPop = (function () {
        function WarningPop(title, message, callback) {
            Popup.call(this, title, message, 'warning', 'bottomRight', false, 0, false, callback);
        }

        return WarningPop;
    })();

    return {
        SuccessPop: SuccessPop,
        InfoPop: InfoPop,
        ErrorPop: ErrorPop,
        WarningPop: WarningPop
    };
})();