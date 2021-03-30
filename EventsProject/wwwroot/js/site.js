// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.accordion-toggle').on('click', function (event) {
        event.preventDefault();

        let accordion = $(this);
        let accordionContent = accordion.next('.accordion-content');

        accordion.toggleClass("open");

        accordionContent.slideToggle(250);

    });
});