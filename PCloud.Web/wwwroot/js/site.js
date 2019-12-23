
$(function () {
    var $input = $('#file-upload');
    var $label = $input.next('label'),
        labelVal = $label.html();
    $input.on('change', function (e) {
        $(this).blur();
        var fileName = e.target.value.split('\\').pop();
        if (fileName) $label.find('span').html(fileName);
        else $label.html(labelVal);

        $label.css({ "background-color": "#FFB800" });
        $('.pr-container').css({ "background-color": "white" });
        console.log(this.files[0].name + " : " + (this.files[0].size / 1024 / 1024).toFixed(2) + "M   " + this.files[0].size + "k");


        var formdata = new FormData();
        formdata.append('upload', this.files[0]);
        var xhr = new XMLHttpRequest();
        
        xhr.onload = function (e) {
            console.log(xhr.response);
            //文件id
            $('#fileId').val(xhr.response);
        };
        xhr.onprogress = function (e) {
            console.log(xhr.response);
            console.log(e.target.response);
            /*if (e.lengthComputable) {
                var percent = (e.loaded / e.total) * 100;
                $('#progress').css({ "width": percent.toFixed(2) + '%' });
                if (e.loaded === e.total) {
                    var st = setTimeout(() => {
                        $label.css({ "background-color": "#64c896" });
                        $('.pr-container').css({ "background-color": "" });
                        $('#progress').css({ "width": "" });
                        $label.find('span').fadeOut(1000).html("上传成功").fadeIn(1000);
                        $('#f_title').val(fileName);

                        clearTimeout(st);
                    }, 1000);
                }
            }*/
        };
        xhr.upload.onprogress = function (e) {
            //console.log(2);
            //console.log(e);
            if (e.lengthComputable) {
                var percent = (e.loaded / e.total) * 100;
                $('#progress').css({ "width": percent.toFixed(2) + '%' });
                if (e.loaded === e.total) {
                    var st = setTimeout(() => {
                        $label.css({ "background-color": "#64c896" });
                        $('.pr-container').css({ "background-color": "" });
                        $('#progress').css({ "width": "" });
                        $label.find('span').fadeOut(1000).html("上传成功").fadeIn(1000);
                        $('#f_title').val(fileName);

                        clearTimeout(st);
                    }, 1000);
                }
            }
        };
        xhr.open('POST', '/FileOperate/FileUpload', true); //true,false指异步/同步上传
        xhr.send(formdata);

        /* $.ajax({
             url: '/FileOperate/FileUpload',
             type: 'post',
             data: formdata,
             async: true,
             dataType: 'JSON',
             cache: false,
             processData: false,
             contentType: false,
             success: function(data) {
                 console.log(data);
             },
             error: function(err) {
                 console.log(err);
             }
         });*/

    });



});



