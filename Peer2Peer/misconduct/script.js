document.addEventListener('DOMContentLoaded', function() {
    const reportForm = document.getElementById('report-form');

    reportForm.addEventListener('submit', function(event) {
        event.preventDefault(); // Prevent the default form submission

        alert('Form sent successfully.');
        window.location.href = '../dashboards/student.html'; // Redirect to the home page
    });
});
