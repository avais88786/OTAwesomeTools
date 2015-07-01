$(document).ready(function () {
    $("#upload").hide();
    HideFileUploadButton()
    HideDownLoadFileButton();
    var formData;

    function ShowFileUploadButton() {
        $("#btnFileUpload").show();
    }

    function HideFileUploadButton() {
        $("#btnFileUpload").hide();
    }

    function HideDownLoadFileButton() {
        $("#lnkDownloadFile").hide();
    }

    function ShowDownloadFileButton() {
        $("#lnkDownloadFile").show();
    }

    function OutputFileName(fileName,fileSize) {
        var content = "<strong>" + fileName + "</strong> -- " + Math.round(parseFloat(fileSize / 1024)) + "KB<br/>"
        var existingHtml = $("#fileNames").html();
        $("#fileNames").html(existingHtml + content);
    };

    $("#testToLiveToggle").click(function () {
        $("#upload").slideToggle();
    });


    $("#filedrag").on("dragover", function (e) {
        e.preventDefault();
        $(this).addClass("hover");
    });
    
    $("#filedrag").on("dragenter", function (e) {
        e.preventDefault();
    })

    $("#filedrag").on("dragleave", function (e) {
        $(this).removeClass("hover");
    })

    $("#fileselect").change(function (event) {

        if (event.currentTarget.files.length == 0)
        { HideFileUploadButton(); return; }

        ParseFiles(event.currentTarget.files);

    });



    $("#filedrag").on("drop", function (e) {
        e.preventDefault();
        
        $(this).removeClass("hover");
        ParseFiles(e.originalEvent.dataTransfer.files);
    });

    function ParseFiles(files) {
        HideDownLoadFileButton();
        var x = files;
        formData = new FormData();
        $("#fileNames").html("");
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            //var xhr = new XMLHttpRequest();
            //xhr.open("POST", "AccountsFix/Upload", true);
            //xhr.setRequestHeader("X-File-Name", "file");
            //xhr.setRequestHeader("X-File-Size", file.size);
            //xhr.send(file);
            formData.append("files[]", file, file.name);
            OutputFileName(file.name,file.size);
            
            
        }
        //var xhr = new XMLHttpRequest();
        //xhr.open("POST", "AccountsFix/Upload2", true);
        //xhr.send(formData);

        ShowFileUploadButton();

    }


    $("#btnFileUpload").click(function (e) {
       
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "AccountsFix/Upload2",
            contentType: false,
            processData: false,
            data:formData

        });

        ajaxRequest.error(function (xml, status, error) {
            alert(error);
        });

        ajaxRequest.success(function (resultFileName, status) {
            HideFileUploadButton();
            
            //alert(status);
            $("#lnkDownloadFile").text(resultFileName);
            $("#lnkDownloadFile").attr("filename", resultFileName);
            ShowDownloadFileButton();
        });

    });

    $("#lnkDownloadFile").click(function (event) {
        
        var url = "AccountsFix/Download";
        var fileName = $(this).attr("filename");
        var href = $(this).attr('href');
        $(this).attr("href", href + "?filename=" + fileName);
        //$.post(url, { filename: fileName }, function (data) { var y = 2;});
        

    });
    


    });