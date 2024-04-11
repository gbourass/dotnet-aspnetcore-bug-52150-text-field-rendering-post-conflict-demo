// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function disablePasswordManager() {
    $("input")
        .attr("autocomplete", "off") // Browser
        .attr("data-lpignore", "true") // Lastpass
        .attr("data-form-type", "other"); // Dashlane
}

$(document).ready(function () {
    disablePasswordManager();
});