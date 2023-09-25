// Mock-up user database
const users = [
    { username: 'student1', password: 'pass1', role: 'student' },
    { username: 'student2', password: 'pass2', role: 'student' },
    { username: 'lecturer1', password: 'pass3', role: 'lecturer' },
    { username: 'tutor1', password: 'pass4', role: 'tutor' },
];

// Function to handle login
function handleLogin(event) {
    event.preventDefault();
    
    // Get the entered username and password
    const username = document.querySelector('input[type="text"]').value;
    const password = document.querySelector('input[type="password"]').value;

    // Find the user in the database
    const user = users.find(u => u.username === username && u.password === password);

    if (user) {
        // Check the user's role and redirect accordingly
        switch (user.role) {
            case 'student':
                window.location.href = '../dashboards/student.html'; // Redirect to the student dashboard
                break;
            case 'lecturer':
                window.location.href = '../dashboards/lecturer.html'; // Redirect to the lecturer dashboard
                break;
            case 'tutor':
                window.location.href = '../dashboards/tutor.html'; // Redirect to the tutor dashboard
                break;
            default:
                alert('Invalid role');
        }
    } else {
        alert('Invalid username or password');
    }
}

// Attach the login form submit event handler
const loginForm = document.querySelector('.login-form');
loginForm.addEventListener('submit', handleLogin);
