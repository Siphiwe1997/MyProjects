fetch('..\\shared\\navbar.html')
    .then(response => response.text())
    .then(data => {
    document.getElementById('navbar-placeholder').innerHTML = data;
    });