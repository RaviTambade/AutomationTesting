
var handler=require('./handler.js');

handler.onAction();//

//callback function
function show()
{
    console.log("Hello World");
}


setInterval(handler.onAction,2000);