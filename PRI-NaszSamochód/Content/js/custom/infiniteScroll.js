$('head').append($('<script>').attr('src', '/Content/node_modules/jquery/dist/jquery.min.js'));
$.getScript("/Content/node_modules/jscroll/jquery.jscroll.js", function (data, textStatus, jqxhr) {
    //console.log(data); // Data returned
    //console.log(textStatus); // Success
    //console.log(jqxhr.status); // 200
    //console.log("Load was performed.");

    $(document).ready(function () {
        $('#scrollIt').jscroll({
            autoTrigger: true,
            loadingHtml: '<img src="../src/loading.gif" />',
        });
    });
});