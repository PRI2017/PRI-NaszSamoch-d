
    document.getElementById('userProfilePhoto').addEventListener("click", showDialog);
function showDialog() {
    $('head').append($('<link>').attr('href', 'https://rawgit.com/enyo/dropzone/master/dist/dropzone.css')); 
    $.getScript("/Content/js/lib/dropzone.js",
        function (data, textStatus, jqxhr) {
            $("#dialog").dialog().addClass("dropzone").dropzone({ url: "/ProfPhoto/Upload" });
            document.getElementById("my-awesome-dropzone").style.display = "flex";
            console.log("Created dropzone");
        }
    );
   
        //console.log("Drop zone script!!!");
   
    
};