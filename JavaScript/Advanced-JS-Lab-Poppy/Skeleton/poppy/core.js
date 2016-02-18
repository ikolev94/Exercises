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
    document.body.appendChild(view);
    processPopup(view, popup);
}

function fadeOut(domView, time, ev) {
    "use strict";
    var op = 1, timer;  // initial opacity
    timer = setInterval(function () {
        if (op <= 0) {
            clearInterval(timer);
            domView.style.display = 'none';
            if (ev) {
                pop = ev.target.parentNode.parentNode;
                pop.parentNode.removeChild(pop);
            }
        }
        domView.style.opacity = op;
        domView.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op -= 0.05;
    }, time);
}

function processPopup(domView, popup) {
    "use strict";
    if (popup.popupData.closeButton) {
        var button = document.getElementsByClassName('poppy-close-button')[0];
        button.addEventListener('click', function (ev) {
            fadeOut(domView, popup.popupData.timeOut, ev);
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


