const quizzes = {
    'math-quiz': {
        title: 'Math Quiz',
        description: 'Test your mathematical knowledge with this university-level math quiz.',
        questions: [
            {
                question: "What is the derivative of f(x) = 2x^3 - 4x^2 + 5x - 1?",
                options: [
                    "6x^2 - 8x + 5",
                    "6x^2 - 8x + 5",
                    "6x^4 - 8x^3 + 5x^2 - 1",
                ],
            },
            {
                question: "What is the integral of ∫(3x^2 + 2x) dx?",
                options: [
                    "2x^3 + 2x^2 + C",
                    "x^3 + x^2 + C",
                    "2x^3 + C",
                ],
            },
        ],
    },
    'physics-quiz': {
        title: 'Physics Quiz',
        description: 'Explore the world of physics with this challenging university-level physics quiz.',
        questions: [
            {
                question: "What is the equation for the Schrödinger wave function in quantum mechanics?",
                options: [
                    "E=mc^2",
                    "F=ma",
                    "Ψ(x,t)",
                ],
            },
            {
                question: "What is the concept of the Heisenberg Uncertainty Principle?",
                options: [
                    "The speed of light is constant.",
                    "It's impossible to know both the position and momentum of a particle with absolute certainty.",
                    "Electrons are negatively charged particles.",
                ],
            },
        ],
    },
    'csharp-quiz': {
        title: 'C# Programming Quiz',
        description: 'Put your programming skills to the test with this university-level C# programming quiz.',
        questions: [
            {
                question: "What is the purpose of the `yield` keyword in C#?",
                options: [
                    "It defines a variable.",
                    "It creates a new class.",
                    "It is used to create an iterator.",
                ],
            },
            {
                question: "What is the difference between `StringBuilder` and `String` in C#?",
                options: [
                    "There is no difference.",
                    "`StringBuilder` is mutable, while `String` is immutable.",
                    "`String` can hold multiple values simultaneously.",
                ],
            },
        ],
    },
};

let currentQuizId = null;
let currentQuestionIndex = 0;
let answers = [];
let timerInterval;
let timerTimeout;

function openQuiz(quizId) {
    currentQuizId = quizId;
    currentQuestionIndex = 0;
    answers = [];
    showNextQuestion();
    document.getElementById('quiz-modal').style.display = 'block';

    // Set a 10-minute timer (600 seconds)
    let timeRemaining = 600;
    updateTimerDisplay(timeRemaining);

    timerInterval = setInterval(() => {
        timeRemaining--;
        updateTimerDisplay(timeRemaining);
        if (timeRemaining === 0) {
            clearInterval(timerInterval);
            submitQuiz();
        }
    }, 1000);

    // Set a timeout to automatically close the quiz after 10 minutes
    timerTimeout = setTimeout(() => {
        closeQuiz();
    }, 600000); // 600,000 milliseconds (10 minutes)
}

function closeQuiz() {
    currentQuizId = null;
    clearInterval(timerInterval); // Stop the timer interval
    clearTimeout(timerTimeout); // Clear the timer timeout
    document.getElementById('quiz-modal').style.display = 'none';
    document.getElementById('quiz-container').innerHTML = '';
    document.getElementById('next-btn').classList.remove('hidden');
    document.getElementById('submit-btn').classList.add('hidden');
    document.getElementById('quiz-success').classList.add('hidden');
    document.getElementById('timer').textContent = ''; // Clear the timer display
}

function showNextQuestion() {
    const quiz = quizzes[currentQuizId];
    const question = quiz.questions[currentQuestionIndex];
    if (!question) {
        // All questions have been shown
        document.getElementById('next-btn').classList.add('hidden');
        document.getElementById('submit-btn').classList.remove('hidden');
        return;
    }

    const quizContainer = document.getElementById('quiz-container');
    quizContainer.innerHTML = '';

    const questionText = document.createElement('p');
    questionText.textContent = question.question;
    quizContainer.appendChild(questionText);

    const options = question.options;
    options.forEach((option, index) => {
        const optionLabel = document.createElement('label');
        optionLabel.textContent = option;
        const optionInput = document.createElement('input');
        optionInput.type = 'checkbox'; // Change to checkbox
        optionInput.name = 'quiz-option';
        optionInput.value = index;
        quizContainer.appendChild(optionInput);
        quizContainer.appendChild(optionLabel);
        quizContainer.appendChild(document.createElement('br'));
    });

    currentQuestionIndex++;
}

function submitQuiz() {
    const selectedOptions = document.querySelectorAll('input[name="quiz-option"]:checked');
    if (selectedOptions.length === 0) {
        alert("Please select at least one answer.");
        return;
    }

    document.getElementById('quiz-container').innerHTML = '';
    document.getElementById('next-btn').classList.add('hidden');
    document.getElementById('submit-btn').classList.add('hidden');
    document.getElementById('quiz-success').classList.remove('hidden');
}

function updateTimerDisplay(seconds) {
    const minutes = Math.floor(seconds / 60);
    const remainingSeconds = seconds % 60;
    const timerDisplay = `${minutes}:${remainingSeconds < 10 ? '0' : ''}${remainingSeconds}`;
    document.getElementById('timer').textContent = `Time Remaining: ${timerDisplay}`;
}

// Close the quiz modal when the user clicks the close button
document.querySelector('.close').addEventListener('click', closeQuiz);

// Close the quiz modal when the user clicks outside of it
window.onclick = function(event) {
    const modal = document.getElementById('quiz-modal');
    if (event.target === modal) {
        closeQuiz();
    }
};

