
// Load the navbar partial view into the placeholder
fetch('../shared/navlogout.html')
    .then(response => response.text())
    .then(data => {
        document.getElementById('navbar-placeholder').innerHTML = data;
        // Call the function to generate the initial navigation links
        generateNavigationLinks();
    })
    .catch(error => {
        console.error('Fetch error:', error);
    });
