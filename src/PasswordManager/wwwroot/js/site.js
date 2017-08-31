$(document).ready(function () {

    $(document).ready(function () {
        $(".siteEdit").hide();
        $(".apiEdit").hide();

        $(".editSite").click(function () {
            console.log("edit");
            $(".siteEdit").toggle();
        })
    });

    $(".editApi").click(function () {
        console.log("edit");
        $(".apiEdit").toggle();
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