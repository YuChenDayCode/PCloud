// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    $('.inputfile').each((index, input) => {
        console.log(input);
        var $label = $(input).next('label'),
            labelVal = $label.html();
        $(input).on('change', function (e) {
            var fileName = "";
            console.log(this.files);
            $(input).blur();
            fileName = e.target.value.split('\\').pop();
            if (fileName) {
                $label.find('span').html(fileName);
            }
            else {
                $label.html(labelVal);
            }
        });
        $(input).on('focus', function () { $(input).addClass('has-focus'); });
        $(input).on('blur', function () { $(input).removeClass('has-focus'); });
    });
});