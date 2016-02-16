function pop(type, title, message) {
    var popup;
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

    var view = createPopupView(popup);
    var body = document.getElementsByTagName('body')[0];
    body.appendChild(view);
    processPopup(view, popup);
}

function processPopup(domView, popup) {
    var button = document.getElementsByClassName('poppy-close-button')[0];
    if (button) {
        button.addEventListener('click', function (ev) {
            var op = 1;  // initial opacity
            var timer = setInterval(function () {
                if (op <= 0.1) {
                    clearInterval(timer);
                    domView.style.display = 'none';
                }
                domView.style.opacity = op;
                domView.style.filter = 'alpha(opacity=' + op * 100 + ")";
                op -= op * 0.1;
            }, 100);
            if (op === 0) {
                var pop = ev.target.parentNode.parentNode;
                pop.parentNode.removeChild(pop);
            }
        })
    }
    if (popup._popupData.autoHide) {
        var op = 1;  // initial opacity
        var timer = setInterval(function () {
            if (op <= 0.1) {
                clearInterval(timer);
                domView.style.display = 'none';
            }
            domView.style.opacity = op;
            domView.style.filter = 'alpha(opacity=' + op * 100 + ")";
            op -= op * 0.05;
        }, popup._popupData.timeOut);

    }
    if (popup._popupData.callback) {
        domView.addEventListener('click', popup._popupData.callback);
    }
}

pop('error', 'This is error pop', 'Hi we have a problem');
pop('success', 'success yes!', 'you made it!');
pop('warning', 'Warning! (CLICK ME!)', 'warning message', redirect);
pop('info', 'info this is info', 'same info');


function redirect() {
    window.location = 'https://www.youtube.com/watch?v=HMUDVMiITOU';
}