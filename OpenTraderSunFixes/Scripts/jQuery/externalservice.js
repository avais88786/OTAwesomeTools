$(document).ready(function () {


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


});