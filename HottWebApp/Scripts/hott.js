//PlayBill page////////////////////////////////////////

$(function () {
    var selectedEventId;

    $(".events-dropdown").on('click', 'li a', function () {
        selectedEventId = $(this).data("event-id");
        $(".events-dropdown button").text($(this).text());

        $(".event-details").find("div.in").collapse("hide");

        $(".event-details").find("[data-event-id='" + selectedEventId + "']").collapse("show");
        $("#btn-order").removeClass('disabled');
    });

    $(".rows-dropdown").on('click', 'li a', function () {
        $(".event-details").find("[data-event-id='" + selectedEventId + "']").find(".rows-dropdown button").text($(this).text());
        $(".event-details").find("[data-event-id='" + selectedEventId + "']").find(".rows-dropdown button").val($(this).val());
    });

    $(".seats-dropdown").on('click', 'li a', function () {
        $(".event-details").find("[data-event-id='" + selectedEventId + "']").find(".seats-dropdown button").text($(this).text());
        $(".event-details").find("[data-event-id='" + selectedEventId + "']").find(".seats-dropdown button").val($(this).val());
    });

});
//////////////////////////////////////////////////