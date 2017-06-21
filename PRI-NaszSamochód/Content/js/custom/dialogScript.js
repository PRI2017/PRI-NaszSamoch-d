function showDialog() {
    $('head').append($('<link>').attr('href', 'https://rawgit.com/enyo/dropzone/master/dist/dropzone.css')); 
    $.getScript("/Content/js/lib/dropzone.js",
        function (data, textStatus, jqxhr) {

            Dropzone.autoDiscover = false;
            $("#dialog").dialog().addClass("dropzone").dropzone(
            {
                url: "/ProfPhoto/Upload",
                autoProcessQueue: false,
                maxFiles: 1,
                init: function () {
                    myDropzone = this;
                    this.on("addedfile", function (file) {
                        $("#dialog").append("<button id='sub'class='btn-success'>Zatwierdź</button>").display = "block";

                        $("#sub").click(function () {
                            myDropzone.processQueue()
                        });
                    });
                }
            });
            $("#dialog").on('dialogclose', function (event) {
                location.reload();
            });

            document.getElementById("my-awesome-dropzone").style.display = "none";
        }
    );
};

document.getElementById('userProfilePhoto').addEventListener("click", showDialog);
