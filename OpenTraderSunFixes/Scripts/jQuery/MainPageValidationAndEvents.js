function ToggleRows(rowId) {
    $("#table" + rowId).slideToggle(0);

    //// Set the effect type
    //var effect = 'slide';

    //// Set the options for the effect type chosen
    //var options = { direction: "right" };

    //// Set the duration (default: 400 milliseconds)
    //var duration = 500;

    //y.toggle(effect, options, duration);
}


$(document).ready(function () {
    var premiumsChangedCCTransId;

    $("#divFixHelp").hide();
    $("#divSunFixesHelp").hide();
    $("#divTraderFixesHelp").hide();
    $("#divSunFixesHelpContainer2").hide();
    CollapseRows();

   

    function CollapseRows() {
        var tables = $("[data-table-rowid=name]");//.val($(this).val());
        //for (var i = 0; i < tables.length ; i++) {
        //    tables[i].hide();
        //}
        $("[data-table-rowid=name]").hide();
    }

    $("select").change(function () {
        
        var currentValue = $(this).val();
        var rowId = $(this).attr("data-rowid");
        if (currentValue == "Trader") {
            $("#table" + rowId + " #transactiontype").hide();
            $("#table" + rowId + " #businessunit").hide();
            $("#table" + rowId + " #postingdate").hide();
            $("#table" + rowId + " #charappend").hide();
        } else {
            $("#table" + rowId + " #transactiontype").show();//.hide();
            $("#table" + rowId + " #businessunit").show();
            $("#table" + rowId + " #postingdate").show();
            $("#table" + rowId + " #charappend").show();

        }
        
        
        
    });


    $(":button[data-button-changepremiums]").click(function () {
        var txtValue = $(this).val();
        var rowId = $(this).attr("data-rowid");
        var x = $(this).attr("id");
        //if ($(this).attr("id") == "btnFileUpload" || $(this).attr("id") == "btnfileDownload" || $(this).attr("value") == "Select") {
        //    return;
        //}

        if (txtValue == "Change Premiums") {
            premiumsChangedCCTransId = rowId;
            $("[data-sun=" + rowId + "]").removeAttr("readonly");
            $("[data-sun=" + rowId + "]").addClass("editable");
            $("[data-sun-premiumedited=" + rowId + "]").val(true);

            $(document).delegate("#txtBoxMemoAmount" + rowId, "change", function () {
                $("[data-sun-MemoAmountNewId=" + rowId + "]").val($(this).val());
            })

            $(document).delegate("#txtBoxCCAmountNew" + rowId, "change", function () {
                $("[data-sun-CCAmountNewNewId=" + rowId + "]").val($(this).val());
            })

            $(document).delegate("#txtBoxBrokerCommRate" + rowId, "change", function () {
                $("[data-sun-BrokerCommRateId=" + rowId + "]").val($(this).val());
                var ppCommRate = $("#txtBoxPowerplaceCommRate" + rowId).val();
                $("#txtBoxTotalCommRate" + rowId).val(parseFloat($(this).val()) + parseFloat(ppCommRate));

            })

            $(document).delegate("#txtBoxPowerplaceCommRate" + rowId, "change", function () {
                $("[data-sun-PowerplaceCommRateId=" + rowId + "]").val($(this).val());
                var brokerCommRate = $("#txtBoxBrokerCommRate" + rowId).val();
                $("#txtBoxTotalCommRate" + rowId).val(parseFloat($(this).val()) + parseFloat(brokerCommRate));

            })


            $(document).delegate("#txtBoxTotalCommValue" + rowId, "change", function () {
                $("[data-sun-TotalCommNewId=" + rowId + "]").val($(this).val());
            })

            $(document).delegate("#txtBoxPPCommValue" + rowId, "change", function () {
                $("[data-sun-PowerplaceCommNewId=" + rowId + "]").val($(this).val());
                var brokerCommValue = $("#txtBoxBrokerCommValue" + rowId).val();
                $("#txtBoxTotalCommValue" + rowId).val(parseFloat($(this).val()) + parseFloat(brokerCommValue));

            })

            $(document).delegate("#txtBoxBrokerCommValue" + rowId, "change", function () {
                $("[data-sun-BrokerCommNewId=" + rowId + "]").val($(this).val());
                var ppCommValue = $("#txtBoxPPCommValue" + rowId).val();
                $("#txtBoxTotalCommValue" + rowId).val(parseFloat($(this).val()) + parseFloat(ppCommValue));

            })

            $(document).delegate("#txtBoxIPTValue" + rowId, "change", function () {
                $("[data-sun-IPTNewId=" + rowId + "]").val($(this).val());
            })

            $("[data-transactionType-rowId=" + rowId + "]").hide();

            $(this).val("Cancel");
        }
        else {
            $("[data-sun=" + rowId + "]").attr("readonly", "");
            $("[data-sun-premiumedited=" + rowId + "]").val(false);
            $("[data-sun=" + rowId + "]").removeClass("editable");
            $("#txtBoxMemoAmount" + rowId).val($("#txtBoxMemoAmount" + rowId).attr("data-sun-orignalamount"))

            $("#txtBoxTotalCommRate" + rowId).val($("#txtBoxTotalCommRate" + rowId).attr("data-sun-orignalamount"))
            $("#txtBoxBrokerCommRate" + rowId).val($("#txtBoxBrokerCommRate" + rowId).attr("data-sun-orignalamount"))
            $("#txtBoxPowerplaceCommRate" + rowId).val($("#txtBoxPowerplaceCommRate" + rowId).attr("data-sun-orignalamount"))


            $("#txtBoxTotalCommValue" + rowId).val($("#txtBoxTotalCommValue" + rowId).attr("data-sun-orignalamount"))
            $("#txtBoxPPCommValue" + rowId).val($("#txtBoxPPCommValue" + rowId).attr("data-sun-orignalamount"))
            $("#txtBoxBrokerCommValue" + rowId).val($("#txtBoxBrokerCommValue" + rowId).attr("data-sun-orignalamount"))
            $("#txtBoxIPTValue" + rowId).val($("#txtBoxIPTValue" + rowId).attr("data-sun-orignalamount"))
            $("[data-transactionType-rowId=" + rowId + "]").show();
            $(this).val("Change Premiums");
            premiumsChangedCCTransId = 0;
                    
        }
    });

    $("table form").submit(function (event) {

        var rowId = $(this).attr("cctransactionid");
        // Validate Form if required:
        //var formValidated = SubmitValidate(rowId);

        //if (!formValidated) {
        //    event.preventDefault();
        //    $("fieldset").append("@Html.Raw(<label>*TotalCommissionValue should be equal to sum of PowerplaceCommissionValue + BrokerCommissionValue </Label>)").addClass("text-danger");
        //}

        $("#img_LoadGenerateXMl-" + rowId).removeAttr("hidden");
    });

    function SubmitValidate(rowId) {
        //Check if TotalCommission is Equal to Broker + Powerplace commission
        if (parseFloat($("#txtBoxTotalCommValue" + rowId).val()) == (parseFloat($("#txtBoxPPCommValue" + rowId).val()) + parseFloat($("#txtBoxBrokerCommValue" + rowId).val())))
            return true;
        else
            return false;
    }


    $("#imgDropDownCheckList").click(function () {

        $("#divFixHelp").slideToggle();

    });

    $("#imgDropDownCheckList").hover(function () {
        $(this).css("cursor", "pointer");
    },  function () {
        $(this).css("cursor", "default");
    });

    function UpdateHelpContainerData(data) {
        $("#divSunFixesHelpContainer2").slideToggle(300, function () {
            $(this).html(data);
        });
    }

    $("#help_fixtype").click(function () {
        var text = $.parseHTML(helpDataArray[0]);
        
        UpdateHelpContainerData(text);
    });

    $("#help_changepremiums").click(function () {
        var text = $.parseHTML(helpDataArray[1]);

        UpdateHelpContainerData(text);
    });

    $("#help_transactiontype").click(function () {
        var text = $.parseHTML(helpDataArray[2]);

        UpdateHelpContainerData(text);
    });


    $("#help_businessunit").click(function () {
        var text = $.parseHTML(helpDataArray[3]);

        UpdateHelpContainerData(text);
    });

    $("#help_postingdate").click(function () {
        var text = $.parseHTML(helpDataArray[4]);

        UpdateHelpContainerData(text);
    });

    $("#help_charappend").click(function () {
        var text = $.parseHTML(helpDataArray[5]);

        UpdateHelpContainerData(text);
    });

});