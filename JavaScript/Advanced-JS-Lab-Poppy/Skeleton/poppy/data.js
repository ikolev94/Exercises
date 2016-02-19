Function.prototype.extends = function (parent) {
    "use strict";
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};
var data = data || {};

data = (function () {
    "use strict";
    var Popup = (function () {
            function Popup(title, message, type, position, autoHide, timeOut, closeButton, callback) {
                this.popupData = {
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
        }()),

        SuccessPop = (function () {
            function SuccessPop(title, message) {
                Popup.call(this, title, message, 'success', 'bottomLeft', true, 3000);
            }

            SuccessPop.extends(Popup);
            return SuccessPop;
        }()),

        InfoPop = (function () {
            function InfoPop(title, message) {
                Popup.call(this, title, message, 'info', 'topLeft', false, 1000, true);
            }

            InfoPop.extends(Popup);
            return InfoPop;
        }()),

        ErrorPop = (function () {
            function ErrorPop(title, message) {
                Popup.call(this, title, message, 'error', 'topRight', false, 1000, false, false);
                this.popupData.fadeOutOnClick = true;
            }

            ErrorPop.extends(Popup);
            return ErrorPop;
        }()),

        WarningPop = (function () {
            function WarningPop(title, message, callback) {
                Popup.call(this, title, message, 'warning', 'bottomRight', false, 0, false, callback);
            }

            WarningPop.extends(Popup);
            return WarningPop;
        }());

    return {
        SuccessPop: SuccessPop,
        InfoPop: InfoPop,
        ErrorPop: ErrorPop,
        WarningPop: WarningPop
    };
}());