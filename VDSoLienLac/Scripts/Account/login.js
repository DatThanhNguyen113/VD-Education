$(document).ready(function () {
    if (MessageSignIn !== undefined && MessageSignIn !== "") {
        $('#main-message').html(String.format(`<i class="fas fa-exclamation-circle"></i> {0}`, MessageSignIn));
        $('#main-message').addClass('d-block');
    } else {
        $('#main-message').addClass('d-none');
    }
});
