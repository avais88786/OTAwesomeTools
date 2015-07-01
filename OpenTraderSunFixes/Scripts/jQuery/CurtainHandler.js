$(document).ready(function () {
   

        var loadingBoxFunction = function () {
            $(this).css('display', 'none');
            $(this).attr('hidden', '');
            //$('#screen').css('display', 'none');
            $('#screen').attr("hidden", "");

        }

   
        $('#SearchForm').submit(function (event) {

            $('#screen').css({'width': $(document).width(), 'height': $(document).height()});//, 'background': 'rgba(0,0,0,1)' });
            $('#screen').removeAttr('hidden');
            //$('body').css({'overflow':'hidden'});
            $('#loadingBox').removeAttr('hidden');
            $('#loadingBox').css({ 'display': 'block' });
            //event.preventDefault();
            $('#loadingBox').css({ 'display': 'block' }).click(loadingBoxFunction);

        });

        //only way to check if page has been loaded (first load or submit result)
        if ($("#table").length) {
            $('#loadingBox').css('display', 'none');
            $('#loadingBox').attr('hidden', '');
            $('#screen').attr("hidden", "");
        }
});