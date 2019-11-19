// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    var $input = $('#file-upload');
    var $label = $input.next('label'),
        labelVal = $label.html();
    $input.on('change', function (e) {
        $(this).blur();
        var fileName = e.target.value.split('\\').pop();
        if (fileName) $label.find('span').html(fileName);
        else $label.html(labelVal);
        console.log(this.files);
        var tt = 0;
        $label.css({ "background-color": "#FFB800" });
        $('.pr-container').css({ "background-color": "white" });
        var it = setInterval(() => {
            tt += 2;
            if (tt > 100) clearInterval(it);
            progress(tt, $label);
        }, 100);
    });
});


function progress(t, $label) {
    if (t <= 100) {
        var percent = t * 100 / 100;
        $('#progress').css({ "width": percent.toFixed(2) + '%' });
    }
    else {
        //$('.pr-container').css({ "background-color": "" });
        //$('#progress').css({ "width": "" });
        $label.css({ "background-color": "#64c896" });
    }
}