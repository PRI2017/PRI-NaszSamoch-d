
    document.getElementById('userProfilePhoto').addEventListener("click", showDialog);
function showDialog() {
    $('head').append($('<link>').attr('href', 'https://rawgit.com/enyo/dropzone/master/dist/dropzone.css')); 
    $.getScript("/Content/js/dropzone.js",
        function (data, textStatus, jqxhr) {
            $("#dialog").dialog().addClass("dropzone").dropzone({ url: "/ProfPhoto/Upload" });
            document.getElementById("my-awesome-dropzone").style.display = "flex";
            console.log("Created dropzone");
        }
    );
   
        //console.log("Drop zone script!!!");
   
    
};
//angular.module('myApp', [])
//.directive('myDraggable', ['$document', function ($document) {
//    return {
//        transclude: true,
//        link: function (scope, element, attr) {
//            var startX = 0, startY = 0, x = 0, y = 0;

//            element.css({
//                position: 'relative',
//                border: '1px solid red',
//                backgroundColor: 'lightgrey',
//                cursor: 'pointer'
//            });

//            element.on('mousedown', function (event) {
//                // Prevent default dragging of selected content
//                event.preventDefault();
//                startX = event.pageX - x;
//                startY = event.pageY - y;
//                $document.on('mousemove', mousemove);
//                $document.on('mouseup', mouseup);
//            });

//            function mousemove(event) {
//                y = event.pageY - startY;
//                x = event.pageX - startX;
//                element.css({
//                    top: y + 'px',
//                    left: x + 'px'
//                });
//            }

//            function mouseup() {
//                $document.off('mousemove', mousemove);
//                $document.off('mouseup', mouseup);
//            }
//        }
//    };
//}]);