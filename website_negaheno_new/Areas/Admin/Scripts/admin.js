/// <reference path="D:\Git_repos\ArtGallery_Website\website_negaheno_new\Scripts/jquery-3.1.0.intellisense.js" />

$(document).on('click', '#btn-add-new', function () {

    $.ajax({
        url: '/Admin/ArtGallery/Insert_New_Gallery',
        type: 'Get',
        success: function (result) {
            $("#modal_container").find(".modal-content").html(result);
            $("#modal_container").modal('show');
            reparseform();
            config_addNewGallery_Modal();

        }
    });
});

var reparseform = function () {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");

};

$(document).on('click', "#btn_fromDate", function (event) {
    event.preventDefault();
    $("#fromDate").focus();
});

$(document).on('click', "#btn_toDate", function (event) {
    event.preventDefault();
    $("#toDate").focus();
});

function config_addNewGallery_Modal(){


    $("#fromDate").datepicker({
        changeMonth: true,
        changeYear: true
    });
    $("#toDate").datepicker({
        changeMonth: true,
        changeYear: true
    });

    $('#fromHour').timepicker({
        template: false,
        showInputs: false,
        minuteStep: 1,
        showMeridian: false
    });
    $('#toHour').timepicker({
        template: false,
        showInputs: false,
        minuteStep: 1,
        showMeridian: false
    });
}

function Success_add_gallery(result) {
   
    if (result.msg) {
        $("#alert_success").html(result.msg);
        $("#div_alert").slideDown(500);
    }
}

$(document).on("click", "#close_alert", function () {
    $("#div_alert").slideUp(500);
    return false;
});