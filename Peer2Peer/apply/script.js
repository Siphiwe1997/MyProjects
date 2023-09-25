document.addEventListener("DOMContentLoaded", () => {
    const tutorApplicationForm = document.getElementById("tutorApplicationForm");

    tutorApplicationForm.addEventListener("submit", (e) => {
        e.preventDefault(); // Prevent form submission for now

        const yearOfStudy = document.getElementById("yearOfStudy").value;

        // Check if the year of study is at least the second year
        if (parseInt(yearOfStudy) < 2) {
            alert("You can only apply from the second year of study or higher.");
        } else {
            // If the year of study is valid, you can submit the form here
            // Assuming successful submission, show a success message
            alert("Application submitted successfully. We will get back to you with the outcome.");
            //redirect to a home page after a delay
            setTimeout(() => {
                window.location.href = "../dashboards/student.html"; // Redirect to home page
            }, 100); // Redirect after 1 seconds
        }
    });
});
