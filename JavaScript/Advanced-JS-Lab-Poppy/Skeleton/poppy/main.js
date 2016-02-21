poppy.pop('error', 'This is error pop', 'Hi we have a problem');
poppy.pop('success', 'success yes!', 'you made it!');
poppy.pop('info', 'info this is info', 'same info');

function redirect() {
    window.location = 'https://www.youtube.com/watch?v=HMUDVMiITOU';
}

poppy.pop('warning', 'Warning! (CLICK ME!)', 'warning message', redirect);