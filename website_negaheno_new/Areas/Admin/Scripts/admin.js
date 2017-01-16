/// <reference path="D:\Git_repos\ArtGallery_Website\website_negaheno_new\Scripts/jquery-3.1.0.intellisense.js" />

$(document).ready(function(){
    if (localStorage.getItem("msg")) {
        $("#alert_success").html(localStorage.getItem("msg"));
        $("#div_alert").slideDown(500);
        localStorage.clear();
    }
    
    

});
var reparseform = function () {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");

};

$(document).on("click", "#close_alert", function () {
    $("#div_alert").slideUp(500);
    return false;
});



$(document).on('click', '#btn-add-new', function () {
    add_new_Gallery();   
});

$(document).on('click', '#btn-edit-gallery', function () {
    var gallery_id = $(this).closest('tr').data('id');
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
        dateFormat: "yy/mm/dd DD",
        changeMonth: true,
        changeYear: true
    });
    $("#toDate").datepicker({
        dateFormat: "yy/mm/dd DD",
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
    {
        localStorage.setItem("msg", "Gallery Added Successfully!");
        location.href = "/Admin/ArtGallery/Index?page=" + result.page_index + "&filter=" + result.filter;
    }
}

$(document).on('click', '#btn-delete-gallery', function () {
  
    var galleryId = $(this).closest('tr').data('id');

    var get_url = '/Admin/ArtGallery/Delete_Gallery/' + galleryId;

    $.get(get_url, function (result) {
        $("#modal_container").find('.modal-content').html(result);
        $("#modal_container").modal('show');
    });
});

function Success_DeleteGallery(result) {
    if (result) {
        localStorage.setItem("msg", 'Gallery Deleted Successfully!');
        location.href="/Admin/ArtGallery/Index?page="+result.page_index+"&filter="+result.filter;
    }
}

$(document).on('click', '#btn-add-poster', function () {

    var galleryId = $(this).closest('tr').data('id');
    
    $.get("/Admin/ArtGallery/Get_PosterModal/" + galleryId, function (result) {
        $("#modal_container").find(".modal-content").html(result);
        $("#modal_container").modal('show');

        //SetUp_AddImages
        $("#inputimages").fileinput({
            uploadAsync: false,
            uploadUrl: '/Admin/ArtGallery/AddPoster/',
            maxFilePreviewSize: 10240,
            dropZoneEnabled: false,
            uploadExtraData: {
                GalleryId: $('#hd_gallery_id').val(),
                GalleryName: $('#hd_gallery_name').val(),
                filter: $('#hd_filter').val(),
                page: $('#hd_page_index').val()
            },
            browseClass: "btn btn-sm btn-success",
            uploadClass: "btn btn-sm btn-upload",
            removeClass: "btn btn-sm btn-remove",
            removeIcon: '<i class="glyphicon glyphicon-remove"></i>',
            showZoom: false,
            initialPreview: ["<img src='" + $('#image_path').val() + "' alt='poster' style='width:220px; height:220px'>"],
            fileActionSettings: {
            showDrag: false,
            showRemove: false,
            showZoom: false,
            }
        }).on('filebatchuploadsuccess', function (event, data) {
            var response = data.response;
             localStorage.setItem("msg", response.msg);
             location.href = "/Admin/ArtGallery/Index?page=" + response.page_index + "&filter=" + response.filter

        });

      

    });

});

$(document).on('click', '#btn-detail-gallery', function () {

    var galleryId = $(this).closest('tr').data('id');

    $.get("/Admin/ArtGallery/Get_GalleryDetail/" + galleryId, function (result) {
        $("#modal_container").find(".modal-content").html(result);
        $("#modal_container").modal('show');
    });
});