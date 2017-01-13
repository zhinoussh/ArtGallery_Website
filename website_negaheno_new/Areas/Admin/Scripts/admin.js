/// <reference path="D:\Git_repos\ArtGallery_Website\website_negaheno_new\Scripts/jquery-3.1.0.intellisense.js" />

$(document).on('click', '#btn-add-new', function () {

    $.ajax({
        url: '/Admin/ArtGallery/Insert_New_Gallery',
        type: 'Get',
        success: function (result) {
            $("#modal_container").find(".modal-content").html(result);
            $("#modal_container").modal('show');
            config_addNewGallery_Modal();

        }
    });
});

$(document).on('click', "#btn_fromDate", function (event) {
    event.preventDefault();
    $("#fromDate").focus();
});

$(document).on('click', "#btn_toDate", function (event) {
    event.preventDefault();
    $("#toDate").focus();
});

function config_addNewGallery_Modal(){


    $("#datepicker1").datepicker();
    $("#datepicker1btn").click(function (event) {
        event.preventDefault();
        $("#datepicker1").focus();
    })

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
        minuteStep: 1
    });
    $('#toHour').timepicker({
        template: false,
        showInputs: false,
        minuteStep: 1
    });
}