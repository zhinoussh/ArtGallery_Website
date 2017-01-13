/// <reference path="D:\Git_repos\ArtGallery_Website\website_negaheno_new\Scripts/jquery-3.1.0.intellisense.js" />

$(document).on('click', '#btn-add-new', function () {
    add_new_Gallery();   
});

$(document).on('click', '#btn-edit-gallery', function () {
   var gallery_id= $(this).closest('tr').data('id');
   add_new_Gallery(gallery_id);
});

function add_new_Gallery(galleryID)
{
    var get_url = '/Admin/ArtGallery/Insert_New_Gallery';
    if (galleryID != '')
        get_url = get_url + "/" + galleryID;

    $.ajax({
        url: get_url,
        type: 'Get',
        success: function (result) {
            $("#modal_container").find(".modal-content").html(result);
            $("#modal_container").modal('show');
            reparseform();
            config_addNewGallery_Modal();
        }
    });
}
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
   
    if (result) {
        $("#alert_success").html("Gallery Added Successfully!");
        $("#div_alert").slideDown(500);
        $("#gallery_table").html(result);

        $("#modal_container").modal('hide');
    }
}

$(document).on("click", "#close_alert", function () {
    $("#div_alert").slideUp(500);
    return false;
});