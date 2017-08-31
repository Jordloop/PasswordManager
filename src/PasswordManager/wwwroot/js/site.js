$(document).ready(function () {

    $(".siteEdit").hide();
    $(".apiEdit").hide();
    $(".hiddenDelete").hide();

    $(".editSite").click(function () {
        $(".siteEdit").toggle();
    })

    $(".editApi").click(function () {
        $(".apiEdit").toggle();
    })

    $(".showDelete").click(function () {
        console.log("Ding!")
        $(".hiddenDelete").toggle();
    })  
});

function copyPasswordToClipboard(element, url) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(element).text()).select();
    document.execCommand("copy");
    $temp.remove();
    window.location.href = url;
}
function copyKeyToClipboard(element) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(element).text()).select();
    document.execCommand("copy");
    $temp.remove();
}