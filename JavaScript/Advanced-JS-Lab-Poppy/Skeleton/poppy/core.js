function pop(type, title, message) {
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
            popup = new data.WarningPop(title, message, arguments[3]);
            break;
        case 'error':
            popup = new data.ErrorPop(title, message);
            break;
    }

    view = createPopupView(popup);
    processPopup(view, popup);
}

function fadeIn(el) {
    var body = document.body;
    body.appendChild(el);
    el.style.transition = "opacity 1000ms";
    el.style.opacity = 0;

    setTimeout(function () {
        el.style.opacity = 1;
    }, 500);
}

function fadeOut(domView, time) {
    "use strict";
    domView.style.opacity = 0;
    setTimeout(function () {
        var patent = domView.parentNode;
        patent.removeChild(domView);
    }, time);
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
        fadeOut(domView, popup.popupData.timeOut);
    }
    if (popup.popupData.callback) {
        domView.addEventListener('click', popup.popupData.callback);
    }
}


pop('error', 'This is error pop', 'Hi we have a problem');
pop('success', 'success yes!', 'you made it!');
pop('info', 'info this is info', 'same info');

function redirect() {
    window.location = 'https://www.youtube.com/watch?v=HMUDVMiITOU';
}

pop('warning', 'Warning! (CLICK ME!)', 'warning message', redirect);


