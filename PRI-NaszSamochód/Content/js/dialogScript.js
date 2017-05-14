
    document.getElementById('userProfilePhoto').addEventListener("click", showDialog);
    function showDialog() {
        $("#dialog").dialog();
        document.getElementById("my-awesome-dropzone").style.display = "flex";
    };
