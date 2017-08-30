$(document).ready(function () {

});

function copyToClipboard(element, url) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(element).text()).select();
    document.execCommand("copy");
    $temp.remove();
    window.location.href = url;
}



