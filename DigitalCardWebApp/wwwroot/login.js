document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('loginForm');

    // Include the base URL from config.js
    const API_BASE_URL = 'http://localhost:8746';

    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        const loginData = {
            username: form.username.value,
            password: form.password.value,
        };

        try {
            const response = await fetch(`${API_BASE_URL}/api/v1/AdminManager/Login`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(loginData),
            });

            if (response.ok) {
                const result = await response.json();
                debugger;
                // Handle the token, save it to localStorage
                localStorage.setItem('token', result.data.access_token);
                localStorage.setItem('userId', result.data.user_id);
                console.log('Token stored in localStorage:', localStorage.getItem('token')); // Debugging line
                alert('Login successful!');
                // Redirect to a protected page or admin dashboard
                window.location.href = 'cards/index.html';
            } else {
                alert('Login failed.');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    });
});
