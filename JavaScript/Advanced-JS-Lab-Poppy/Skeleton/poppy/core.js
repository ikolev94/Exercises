var poppy = (function () {
    function pop(type, title, message, callback) {
        "use strict";
        var popup, view;
        switch (type) {
            case 'success':
                popup = new data.SuccessPop(title, message);
                break;
            case 'info':
                popup = new data.InfoPop(title, message);
                break;
            case 'warning':
                popup = new data.WarningPop(title, message, callback);
                break;
            case 'error':
                popup = new data.ErrorPop(title, message);
                break;
        }

        view = createPopupView(popup);
        processPopup(view, popup);
    }

    function fadeIn(el) {
        el.style.transition = "opacity 1000ms";
        el.style.opacity = 0;
        document.body.appendChild(el);
        setTimeout(function () {
            el.style.opacity = 1;
        }, 500);
    }

    function fadeOut(domView) {
        var timeoutID = setTimeout(function () {
            domView.style.opacity = 0;
            clearTimeout(timeoutID);
        }, 500);

        setTimeout(function () {
            document.body.removeChild(domView);
        }, 800);
    }

    function processPopup(domView, popup) {
        "use strict";

        fadeIn(domView);
        if (popup.popupData.closeButton) {
            var button = document.getElementsByClassName('poppy-close-button')[0];
            button.addEventListener('click', function () {
                fadeOut(domView, popup.popupData.timeOut);
            });
        }
        if (popup.popupData.fadeOutOnClick) {
            domView.addEventListener('click', function () {
                fadeOut(domView, popup.popupData.timeOut);
            });
        }
        if (popup.popupData.autoHide) {
            setTimeout(function () {
                fadeOut(domView);
            }, popup.popupData.timeOut);
        }
        if (popup.popupData.callback) {
            domView.addEventListener('click', popup.popupData.callback);
        }
    }

    return {
        pop: pop
    };
}());