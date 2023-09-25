document.addEventListener("DOMContentLoaded", () => {
    const container = document.querySelector(".container");
    const speedInput = document.getElementById("speed");
    const sizeInput = document.getElementById("size");
    const temperatureInput = document.getElementById("temperature");
    const factorInput = document.getElementById("factor");

    let particleSpeed = 5;
    let particleSize = 20;
    let temperature = 50;
    let particleFactor = 5;

    speedInput.addEventListener("input", () => {
        particleSpeed = parseFloat(speedInput.value);
    });

    sizeInput.addEventListener("input", () => {
        particleSize = parseFloat(sizeInput.value);
    });

    temperatureInput.addEventListener("input", () => {
        temperature = parseFloat(temperatureInput.value);
    });

    factorInput.addEventListener("input", () => {
        particleFactor = parseFloat(factorInput.value);
    });

    // Empty array to store particle velocities
    const velocities = [];

    // Get the canvas element and create a chart
    const chartCanvas = document.getElementById("velocity-chart");
    const ctx = chartCanvas.getContext("2d");

    const chart = new Chart(ctx, {
        type: "bar",
        data: {
            labels: [],
            datasets: [{
                label: "Velocity Histogram",
                data: [],
                backgroundColor: "rgba(0, 123, 255, 0.5)",
            }],
        },
        options: {
            responsive: false,
            scales: {
                x: {
                    title: {
                        display: true,
                        text: "Velocity",
                    },
                    type: "linear",
                    position: "bottom",
                },
                y: {
                    title: {
                        display: true,
                        text: "Count",
                    },
                },
            },
        },
    });

    // Function to update the velocity histogram
    function updateVelocityHistogram(velocity) {
        velocities.push(velocity);

        // Update the chart data
        const counts = {};
        for (const v of velocities) {
            counts[v] = (counts[v] || 0) + 1;
        }

        chart.data.labels = Object.keys(counts).map(Number);
        chart.data.datasets[0].data = Object.values(counts);
        chart.update();
    }

    // Function to create and move particles
    function createAndMoveParticle() {
        const particle = document.createElement("div");
        particle.className = "particle";
        particle.style.width = `${particleSize}px`;
        particle.style.height = `${particleSize}px`;

        const x = Math.random() * container.offsetWidth;
        const y = Math.random() * container.offsetHeight;

        particle.style.left = `${x}px`;
        particle.style.top = `${y}px`;
        particle.style.animationDuration = `${100 / particleSpeed}s`;

        container.appendChild(particle);

        const velocity = randomSpeed(); // Calculate the velocity
        updateVelocityHistogram(velocity); // Update the velocity histogram

        // Remove the particle after animation completes
        particle.addEventListener("animationiteration", () => {
            container.removeChild(particle);
        });
    }

    // Helper function to generate random direction
    function randomDirection() {
        return Math.random() < 0.5 ? -1 : 1;
    }

    // Helper function to generate random speed
    function randomSpeed() {
        const minSpeed = particleSpeed - 2;
        const maxSpeed = particleSpeed + 2;
        return Math.random() * (maxSpeed - minSpeed) + minSpeed;
    }

    // Function to initialize particles
    function initializeParticles() {
        const interval = (100 / (particleSpeed * particleFactor)) * 1000;
        setInterval(createAndMoveParticle, interval);
    }

    initializeParticles();
});
