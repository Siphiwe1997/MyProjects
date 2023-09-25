document.addEventListener("DOMContentLoaded", () => {
    const sun = document.querySelector(".sun");
    const earth = document.querySelector(".earth");
    const gravitationalWaves = document.querySelector(".gravitational-waves");

    let waveRadius = 50;

    function updateGravitationalWaves() {
        waveRadius += 1;
        gravitationalWaves.style.width = `${waveRadius * 2}px`;
        gravitationalWaves.style.height = `${waveRadius * 2}px`;
        gravitationalWaves.style.transform = `translate(-50%, -50%) scale(${waveRadius / 50})`;

        requestAnimationFrame(updateGravitationalWaves);
    }

    function updateEarthPosition() {
        const currentTime = Date.now();
        const orbitRadius = 150;
        const earthAngle = (currentTime * 0.001) % 360; // Adjust the speed of Earth's orbit

        const x = Math.cos(degreesToRadians(earthAngle)) * orbitRadius;
        const y = Math.sin(degreesToRadians(earthAngle)) * orbitRadius;

        earth.style.transform = `translate(${x}px, ${y}px`;

        requestAnimationFrame(updateEarthPosition);
    }

    function degreesToRadians(degrees) {
        return (degrees * Math.PI) / 180;
    }

    updateGravitationalWaves();
    updateEarthPosition();
});
