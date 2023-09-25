const contacts = {
    student: [],
    lecturer: [],
    tutor: [],
};

document.addEventListener("DOMContentLoaded", () => {
    const studentCheckbox = document.getElementById("student");
    const lecturerCheckbox = document.getElementById("lecturer");
    const tutorCheckbox = document.getElementById("tutor");
    const messageTextarea = document.getElementById("message");
    const sendButton = document.getElementById("send");
    const viewHistoryButton = document.getElementById("viewHistory");
    const historyList = document.getElementById("historyList");
    const deleteSelectedButton = document.getElementById("deleteSelected");
    const deleteAllButton = document.getElementById("deleteAll");

    let selectedContact = null; // Store the selected contact for reply

    // Function to send a message
    sendButton.addEventListener("click", () => {
        const message = messageTextarea.value;
        if (message) {
            if (selectedContact) {
                contacts[selectedContact].push(`You: ${message}`);
                selectedContact = null;
            } else {
                if (studentCheckbox.checked) contacts.student.push(`You: ${message}`);
                if (lecturerCheckbox.checked) contacts.lecturer.push(`You: ${message}`);
                if (tutorCheckbox.checked) contacts.tutor.push(`You: ${message}`);
            }

            messageTextarea.value = "";

            // Update message history immediately
            viewHistoryButton.click(); // Simulate a click on the view history button
        }
    });

    // Function to view message history
    viewHistoryButton.addEventListener("click", () => {
        historyList.innerHTML = "";

        let hasMessages = false; // Track if any messages exist

        for (const contact in contacts) {
            if (contacts[contact].length > 0) {
                hasMessages = true; // Messages exist
                const contactHeader = document.createElement("h3");
                contactHeader.textContent = contact.charAt(0).toUpperCase() + contact.slice(1);

                const ul = document.createElement("ul");

                contacts[contact].forEach((message, index) => {
                    const li = document.createElement("li");
                    li.textContent = message;
                    const checkbox = document.createElement("input");
                    checkbox.type = "checkbox";
                    checkbox.value = index;
                    li.prepend(checkbox);

                    // Add reply button to each message with a margin to the right
                    const replyButton = document.createElement("button");
                    replyButton.textContent = "Reply";
                    replyButton.style.marginRight = "0px"; 
                    replyButton.addEventListener("click", () => {
                        selectedContact = contact;
                        messageTextarea.value = ""; // Clear the message box
                        messageTextarea.placeholder = `Reply to ${contact}`;
                        messageTextarea.focus(); // Automatically focus on the message box
                    });
                    li.appendChild(replyButton);

                    ul.appendChild(li);
                });

                historyList.appendChild(contactHeader);
                historyList.appendChild(ul);
            }
        }

        if (!hasMessages) {
            const noMessagesText = document.createElement("p");
            noMessagesText.textContent = "No message(s)";
            historyList.appendChild(noMessagesText);
        }
    });

    // Function to delete selected messages
    deleteSelectedButton.addEventListener("click", () => {
        for (const contact in contacts) {
            const checkboxes = Array.from(historyList.querySelectorAll(`input[type="checkbox"]`));
            checkboxes.forEach((checkbox, index) => {
                if (checkbox.checked) {
                    contacts[contact].splice(index, 1);
                }
            });
        }
        viewHistoryButton.click(); // Refresh the history list
    });

    // Function to delete all messages
    deleteAllButton.addEventListener("click", () => {
        for (const contact in contacts) {
            contacts[contact] = [];
        }
        historyList.innerHTML = "";
    });
});