// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showPleaseWait(message) {
    if (message == null) {
        message = "Please wait...";
    }
    if ($("#pleaseWaitDialog").length > 0) {
        $("#pleaseWaitDialog").modal("show");
        $("#pleaseWaitDialogOverlay").show();
    }
    else {
        var modalLoading =
            `<div class="loading__wrap" id="pleaseWaitDialog">
                <div class="admin-loading loading--large"></div>
                <div class="admin-loading__text"></div>
            </div>
            <div id="pleaseWaitDialogOverlay" class="loading__overlay"></div>`;
        $(".container-fluid").append(modalLoading);
        $("#pleaseWaitDialog").modal({
            backdrop: false
        });
    }
    $(".admin-loading__text").text(message);
}

function hidePleaseWait() {
    $("#pleaseWaitDialog").modal("hide");
    $("#pleaseWaitDialogOverlay").hide();
}

function showSuccessOverlay(message, callBack) {
    if (message == null) {
        message = "Success!";
    }

    if ($("#successDialog").length > 0) {
        $("#successDialog").modal("show");
        $("#successDialogOverlay").show();
    } else {
        var successModal =
            `<div class="loading__wrap" id="successDialog">
                <div class="admin-success"></div>
                <div class="admin-loading__text"></div>
            </div>
            <div id="successDialogOverlay" class="loading__overlay"></div>`;
        $(".container-fluid").append(successModal);
        $("#successDialog").modal({
            backdrop: false
        });
    }
    $(".admin-loading__text").text(message);

    setTimeout(callBack, 2000);
}

function hideSuccessOverlay() {
    if ($("#successDialog").length > 0) {
        $("#successDialog").modal("hide");
        $("#successDialogOverlay").hide();
    }
}