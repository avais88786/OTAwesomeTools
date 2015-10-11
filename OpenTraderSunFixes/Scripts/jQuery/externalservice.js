$(document).ready(function () {
    CollapseSubTables();

    $('.table th').not('th:first-child').hide();
    $('.table td').not('td:first-child').hide();

    //$('input[name="iamlazy"]:radio').change(function () {
    //    var isChecked = $(this).val();
        
    //    if (isChecked == "True") {
    //        $('#confessionArea').slideUp();
    //        $('#whatyoudoinghere').hide();
    //        $('#scriptingArea').slideDown();
    //    }
    //    else {
    //        $('#whatyoudoinghere').slideDown();
    //    }
    //});



    $('input[type="checkbox"]').click(function () {
        var isChecked = $(this).prop('checked');
        if (isChecked)
        {
            $('.table th').show();
            var index = $(this).attr('data-index');
            index = parseInt(index) + 2;
            $('.table tr:nth-child(' + index + ') td').show();
        }
        else {
            var index = $(this).attr('data-index');
            index = parseInt(index) + 2;
            $('.table tr:nth-child(' + index + ') td').not('td:first-child').hide();
        }
        
    });

    $("#SchemeId").blur(function () {

        var datas = "SchemeId=" + $(this).val();
        $('#loadingImage').removeAttr('hidden');

        $.ajax({
            url: 'ExternalServiceScriptGenerator/GetSchemeName',
            data: datas,
            cache: false,
            success: function (result) {
                $('#SchemeNameLabel').text(result.SchemeName);
                $('#SchemeName').val(result.SchemeName);
                $('#ratingengineplaceholder').html('');
                $('#ratingengineplaceholder').append(result.OpenRatingEnginesView);
            },
            error: function () {
                $('#schemeplaceholder').text("No Scheme Found");
                $('#ratingengineplaceholder').html('');
            },
            complete: function () {
                $('#loadingImage').attr('hidden','hidden');
            }
        })
    });

    $("body").on('change', ".updateORETypeId", function () {
        var index = $(this).attr('data-index');
        $('.ORETypeId' + index).prop('checked', true);
    });


    $("#changeConnection").click(function () {
        if ($(this).val() == "Change") {
            $("[name$='DataSource']").removeAttr("readonly");
            $("[name$='InitialCatalog']").removeAttr("readonly");
            $("[name$='UserName']").removeAttr("hidden");
            $("[name$='Password']").removeAttr("hidden");
            $("[name$='HasConnectionChanged']").val("True");
            $("#changeConnectionConfirm").removeAttr("hidden");

            $(this).val("Cancel")
        }
        else {
            $("[name$='DataSource']").attr("readonly","readonly");
            $("[name$='InitialCatalog']").attr("readonly", "readonly");
            $("[name$='UserName']").attr("hidden", "hidden");
            $("[name$='Password']").attr("hidden", "hidden");
            $("#changeConnectionConfirm").attr("hidden", "hidden");
            $("[name$='HasConnectionChanged']").val("False");
            $(this).val("Change")
        }
    });

    $("[data-onclickScheme]").click(function () {
        $(this).next('div').slideToggle();
    });


    $("[data-onclickBusinessLine]").click(function () {
        $(this).nextUntil('[data-onclickBusinessLine]').each(function (index, element) {
            $(this).slideToggle();
        });
    });


    function CollapseSubTables(){
        $.each($("[data-onclickScheme]"), function () {
            $(this).next('div').slideUp();
        });

        $.each($("[data-onclickBusinessLine]"), function () {
            $(this).nextUntil('[data-onclickBusinessLine]').each(function (index, element) {
                $(this).slideUp();
            })
        });

    }
});