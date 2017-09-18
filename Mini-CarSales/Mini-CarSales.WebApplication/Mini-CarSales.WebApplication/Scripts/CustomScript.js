
    $(document).ready(function () {
        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [label]);
        });

        $('.btn-file :file').on('fileselect', function (event, label) {

            var input = $(this).parents('.input-group').find(':text'),
		        log = label;
            document.getElementById("imgId").value = label;

            if (input.length) {
                input.val(log);
            } else {
                if (log) alert(log);
            }

        });
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#img-upload').attr('src', e.target.result);
                }

               
                alert("Hi");
                reader.readAsDataURL(input.files[0]);
                uploadFile(input.files[0]);

            }
        }

        $("#imgInp").change(function () {
            readURL(this);
        });
    });


    uploadFile = function (file) {
        var fd = new FormData();
        fd.append('file', file);
        alert(file.name);
        $.ajax({
            url: '~/Images',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fd,
            success: function (result) { alert("Success") },
            error: function (err) { }
        });
    }