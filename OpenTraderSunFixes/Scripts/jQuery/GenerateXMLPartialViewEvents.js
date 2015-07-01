$(document).ready(function () {
    $("#generateXML").click(function () {

        $("#img_LoadGenerateXMl").removeAttr("hidden");
        var url = 'GenerateXMLFromScript';//'@Url.Action("GenerateXMLFromScript","SUN")';
        var dataScript = $("[data-GeneratedFix='']").val();
        //var dataScript = $("#GeneratedFix").val();
        var appendChar = $("#AppendChar").val();

        $.post(url, { scriptToBeExecuted: dataScript, AppendChar: appendChar }, function (data) {
            $("#renderedOutput").removeAttr("hidden");
            $("#test").val(data);
            $("#img_LoadGenerateXMl").attr("hidden", "");
            $("[data-GeneratedXMLFix='']").val(data);
        });
        
        
    });

    $("#imgSaveXML").click(function(event){
        var url = 'Download';
        var generatedFix = $("#test").val();
        var ppreference = $("#PPReference").val();
        var transactiontype = $("#transactionType").val();

        $.post(url, { GeneratedFix: generatedFix, PPReference: ppreference, transactionType: transactiontype }, function (data) {

            var x = 5;

        });

    
    });

    

});