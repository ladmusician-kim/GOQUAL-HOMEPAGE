function makalu_toast(message, position, type) {
    $().toastmessage('showToast', {
        text: message,
        sticky: false,
        position: position,
        type: type,
    });
}
