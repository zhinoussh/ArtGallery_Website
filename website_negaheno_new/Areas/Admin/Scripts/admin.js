/// <reference path="D:\Git_repos\ArtGallery_Website\website_negaheno_new\Scripts/jquery-3.1.0.intellisense.js" />

$(document).on('click', '#btn-add-new', function () {

    $.ajax({
        url: '/Admin/ArtGallery/Insert_New_Gallery',
        type: 'Get',
        success: function (result) {
            $("#modal_container").find(".modal-content").html(result);
            $("#modal_container").modal('show');
        }
    });
});