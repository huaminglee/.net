function PreviewImg1(imgFile) {
    var newPreview1 = document.getElementById("newPreview1");
    newPreview1.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;

}
function PreviewImg2(imgFile) {
    var newPreview2 = document.getElementById("newPreview2");
    newPreview2.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;

}
function PreviewImg3(imgFile) {
    var newPreview3 = document.getElementById("newPreview3");
    newPreview3.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;

}
