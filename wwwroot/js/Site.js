// Write your Javascript code.
$(document).ready(() => {
    $(".button-collapse").sideNav({
        closeOnClick: true
    });
    var el = document.querySelector('.custom-scrollbar');
    Ps.initialize(el);
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
});

