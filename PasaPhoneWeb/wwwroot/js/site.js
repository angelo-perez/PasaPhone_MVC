// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    joinMeetupPreferences("create");
    joinMeetupPreferences("edit");

});


$(".phone-price").on('input', function () {
    var inputValue = $(this).val(); // Get the user's input value
    var formattedValue = formatPrice(inputValue); // Apply the formatNumber function
    $(this).val(formattedValue); // Update the input field with the formatted value
    // You can also call other functions or perform additional actions here
});

$(".meetup-pref-group").click(function () {
    $(this).toggleClass("active inactive")
        .find(".meetup-checkbox").prop("checked", $(this).hasClass("active"))
})
function formatPrice(input, fractionSeparator, thousandsSeparator, fractionSize) {

    fractionSeparator = fractionSeparator || '.';
    thousandsSeparator = thousandsSeparator || ',';
    fractionSize = fractionSize || 2;

    // Remove any existing thousands separators
    input = input.replace(new RegExp(thousandsSeparator, 'g'), '');

    // Use a regular expression to validate the input
    var isValidInput = /^[0-9]*\.?[0-9]*$/.test(input);

    if (!isValidInput) {
        // Invalid input (contains characters other than digits and a single dot)
        return ''; // You can handle this case as needed
    }

    var output = '',
        parts = [];

    input = input.toString();
    parts = input.split(".");
    output = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, thousandsSeparator).trim();

    if (parts.length > 1) {
        output += fractionSeparator;
        output += parts[1].substring(0, fractionSize);
    }

    return output;
};

function joinMeetupPreferences(action) {
    $("#" + action + "_form").submit(function () {

        var checkedPref = $("." + action + "-meetup-box:checked").map(function () {
            return $(this).val().trim();
        }).get().join(",");

        $("#" + action + "_combined_meetup_pref").val(checkedPref);
    });
}
