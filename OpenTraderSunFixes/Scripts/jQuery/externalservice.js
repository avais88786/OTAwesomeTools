$(document).ready(function () {

    $("#SchemeId").blur(function () {

        var datas = "SchemeId=" + $(this).val();


        $.ajax({
            url: 'ExternalServiceScriptGenerator/GetSchemeName',
            data: datas,
            cache: false,
            success: function (result) {
                $('#schemeplaceholder').text(result.SchemeName);
                alert(result.OpenRatingEngines);
            },
            error: function () {
                $('#schemeplaceholder').text("No Scheme Found");
            }

        })
    });

});