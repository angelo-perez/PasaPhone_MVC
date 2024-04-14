// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Multiform JS Codes

var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
    // This function will display the specified tab of the form ...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    // ... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").style.display = "none";
        document.getElementById("submitBtn").style.display = "inline";
    } 
    // ... and run a function that displays the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !formClientValidation()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // Otherwise, display the correct tab:
    showTab(currentTab);
}


function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class to the current step:
    x[n].className += " active";
}

function formClientValidation() {
    var $form = $("#multi_step_form");

    $.validator.unobtrusive.parse($form);

    $form.validate();

    if ($form.valid()) {
        $(".step")[currentTab].className += " finish";
    }

    return $form.valid() ;
        
}
///////////////////////////////////////////////////////////////////////////

$(document).ready(function () {

    $(".phone-price").on('input', function () {
        var inputValue = $(this).val(); // Get the user's input value
        var formattedValue = formatPrice(inputValue); // Apply the formatNumber function
        $(this).val(formattedValue); // Update the input field with the formatted value
        // You can also call other functions or perform additional actions here
    });

    $('#meetup_pref').select2({
        placeholder: "--Select Meetup Preference(s)--",
        data: [
            { id: 0, text: "Public Meetup" },
            { id: 1, text: "Door Pickup" },
            { id: 2, text: "Door Dropoff" },
        ],
        multiple: true,
        height: "100px"
    });

    $('#meetup_pref').change(function () {
        var selections = $('#meetup_pref').select2('data').map(function (option) {
            return option.text;
        }).join(',');
        var meetupPrefJoined = selections;
        console.log(meetupPrefJoined);
        $('#meetup_pref').val(meetupPrefJoined);
    });
});

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


