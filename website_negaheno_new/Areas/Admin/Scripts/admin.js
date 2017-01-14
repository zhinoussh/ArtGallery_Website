/// <reference path="D:\Git_repos\ArtGallery_Website\website_negaheno_new\Scripts/jquery-3.1.0.intellisense.js" />

var reparseform = function () {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");

};

$(document).on("click", "#close_alert", function () {
    $("#div_alert").slideUp(500);
    return false;
});

function AjaxReturn(msg,partial)
{
    $("#alert_success").html(msg);
    $("#div_alert").slideDown(500);
    $("#gallery_table").html(partial);

    $("#modal_container").modal('hide');
}

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
   
    if (result) 
        AjaxReturn("Gallery Added Successfully!", result);
}

$(document).on('click', '#btn-delete-gallery', function () {
  
    var galleryId = $(this).closest('tr').data('id');
    var get_url = '/Admin/ArtGallery/Delete_Gallery/' + galleryId;

    $.get(get_url, function (result) {
        $("#modal_container").find('.modal-content').html(result);
        $("#modal_container").modal('show');
    });
});

function Success_DeleteGallery(result){
    if (result)
        AjaxReturn('Gallery Deleted Successfully!', result);
}