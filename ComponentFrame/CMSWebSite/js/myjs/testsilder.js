/*
    µ¼ÈëÄ£¿é
*/
var link = $('link[rel=import]');
for (var i = 0; i < link.length; i++) {
    var content = link[i].import.querySelector('#myTemplate');
    $("html").prepend(content.innerHTML);
}