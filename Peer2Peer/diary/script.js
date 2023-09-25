document.addEventListener("DOMContentLoaded", () => {
    const tutorApplicationForm = document.getElementById("tutorApplicationForm");
    const viewEntriesSection = document.getElementById("view-entries");
    const audioEntry = document.getElementById("audio-entry");
    const recordAudioButton = document.getElementById("record-audio-button");
    const audioPreview = document.getElementById("audio-preview");
    const textEntry = document.getElementById("text-entry");
    const entryContentTextarea = document.getElementById("entry-content");
    const entryTypeSelect = document.getElementById("entry-type");
    const submitButton = document.getElementById("submit-button");

    // Form submission logic
    tutorApplicationForm.addEventListener("submit", (e) => {
        e.preventDefault(); // Prevent the form from submitting

        // Get user inputs
        const entryType = entryTypeSelect.value;
        const entryContent = entryContentTextarea.value;
        const entryTitle = document.getElementById("entry-title").value;
        const entryDate = document.getElementById("entry-date").value;
        const entryFiles = document.getElementById("entry-files").files;

        // Create a new entry object 
        const newEntry = {
            type: entryType,
            content: entryContent,
            title: entryTitle,
            date: entryDate,
            files: entryFiles,
        };
        console.log(newEntry);

        // Display the new entry in the "View Entries" section
        displayEntry(newEntry);

        // Clear the form fields after submission
        entryTypeSelect.value = "text";
        entryContentTextarea.value = "";
        document.getElementById("entry-title").value = "";
        document.getElementById("entry-date").value = "";
        document.getElementById("entry-files").value = "";

        // Hide audio recording tool after submission
        audioEntry.style.display = "none";
        recordAudioButton.textContent = "Start Recording";
        audioPreview.src = "";

        // Show text entry
        textEntry.style.display = "block";
    });

    // Function to display an entry
    function displayEntry(entry) {
        const entryDiv = document.createElement("div");
        entryDiv.className = "entry";

        const entryHTML = `
            <input type="checkbox" class="entry-checkbox">
            <h3>${entry.title}</h3>
            <p>Date: ${entry.date}</p>
            <p>Type: ${entry.type}</p>
            <p>Content: ${entry.content}</p>
            <p>Files: ${entry.files.length}</p>
            <button class="delete-entry">Delete</button>
        `;

        entryDiv.innerHTML = entryHTML;
        viewEntriesSection.appendChild(entryDiv);

        // Add a click event listener to the delete button
        entryDiv.querySelector(".delete-entry").addEventListener("click", () => {
            deleteEntry(entryDiv);
        });
    }

    // Function to delete an entry
    function deleteEntry(entryDiv) {
        viewEntriesSection.removeChild(entryDiv);
    }

    // Add a click event listener to select/deselect entries
    viewEntriesSection.addEventListener("click", (event) => {
        if (event.target.classList.contains("entry-checkbox")) {
            // Toggle the "selected" class on the parent entry div
            event.target.parentElement.classList.toggle("selected");
        }
    });

    // Function to delete selected entries
    document.getElementById("delete-selected").addEventListener("click", () => {
        const selectedEntries = Array.from(
            viewEntriesSection.querySelectorAll(".entry.selected")
        );

        if (selectedEntries.length === 0) {
            alert("No entries selected for deletion.");
        } else {
            selectedEntries.forEach((entryDiv) => {
                deleteEntry(entryDiv);
            });
        }
    });

    // Show/hide audio recording tool based on the entry type
    entryTypeSelect.addEventListener("change", () => {
        const selectedOption = entryTypeSelect.value;
        if (selectedOption === "audio") {
            audioEntry.style.display = "block";
            textEntry.style.display = "none"; // Hide text entry
        } else {
            audioEntry.style.display = "none";
            textEntry.style.display = "block"; // Show text entry
        }
    });

    // Audio recording logic (audio-recorder.js)
    const audioRecorder = new AudioRecorder();
    audioRecorder.initialize();

    recordAudioButton.addEventListener("click", () => {
        if (audioRecorder.isRecording()) {
            audioRecorder.stopRecording();
            recordAudioButton.textContent = "Start Recording";
        } else {
            audioRecorder.startRecording();
            recordAudioButton.textContent = "Save Recording";
        }
    });

    audioRecorder.onDataAvailable = (audioBlob) => {
        audioPreview.src = URL.createObjectURL(audioBlob);
    };
});
