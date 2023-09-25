document.addEventListener("DOMContentLoaded", function () {
    // Find the "Year" link by its ID
    var secondYearLink = document.getElementById("secondYearLink");
    var thirdYearLink = document.getElementById("thirdYearLink");
    var fourthYearLink = document.getElementById("fourthYearLink");


    if (secondYearLink) {
        secondYearLink.addEventListener("click", function (e) {
            // Prevent the default link behavior
            e.preventDefault();

            // Modify the URL to include the _FYear parameter
            var newUrl = secondYearLink.getAttribute("href") + "?_FYear=2021";

            // Navigate to the new URL
            window.location.href = newUrl;
        });
    }

    if (thirdYearLink) {
        thirdYearLink.addEventListener("click", function (e) {
            // Prevent the default link behavior
            e.preventDefault();

            // Modify the URL to include the _FYear parameter
            var newUrl = thirdYearLink.getAttribute("href") + "?_FYear=2022";

            // Navigate to the new URL
            window.location.href = newUrl;
        });
    }

    if (fourthYearLink) {
        fourthYearLink.addEventListener("click", function (e) {
            // Prevent the default link behavior
            e.preventDefault();

            // Modify the URL to include the _FYear parameter
            var newUrl = fourthYearLink.getAttribute("href") + "?_FYear=2023";

            // Navigate to the new URL
            window.location.href = newUrl;
        });
    }
});