class AudioRecorder {
    constructor() {
        this.mediaStream = null;
        this.mediaRecorder = null;
        this.audioChunks = [];
        this.onDataAvailable = null;
    }

    initialize() {
        navigator.mediaDevices
            .getUserMedia({ audio: true })
            .then((stream) => {
                this.mediaStream = stream;
                this.mediaRecorder = new MediaRecorder(stream);
                this.mediaRecorder.ondataavailable = (event) => {
                    if (event.data.size > 0) {
                        this.audioChunks.push(event.data);
                        if (this.onDataAvailable) {
                            this.onDataAvailable(new Blob(this.audioChunks));
                        }
                    }
                };
            })
            .catch((error) => {
                console.error("Error accessing microphone:", error);
            });
    }

    startRecording() {
        this.audioChunks = [];
        if (this.mediaRecorder) {
            this.mediaRecorder.start();
        }
    }

    stopRecording() {
        if (this.mediaRecorder && this.mediaRecorder.state === "recording") {
            this.mediaRecorder.stop();
            this.mediaStream.getTracks().forEach((track) => track.stop());
        }
    }

    isRecording() {
        return this.mediaRecorder && this.mediaRecorder.state === "recording";
    }
}
