$(document).ready(function () {

    $('textarea').on('input', function () {

        var contents = $(this).val();
        var contentLen = contents.length;
        if (contentLen <= 0) {
            return;
        }
        var ht = this.scrollHeight;
        $(this).height(ht + "px");
    });

    $('textarea').trigger('input');

    
});