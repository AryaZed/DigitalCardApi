document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('cardForm');
    const cardsContainer = document.getElementById('cardsContainer');

    // Include the base URL from config.js
    const API_BASE_URL = 'http://localhost:8746';

    const userId = Number(localStorage.getItem('userId'));

    // Function to get the authorization header with the token
    const getAuthHeaders = () => {
        const token = localStorage.getItem('token');
        return token ? { 'Authorization': `Bearer ${token}` } : {};
    };

    form.addEventListener('submit', async (event) => {
        event.preventDefault();
        debugger;
        var token = getAuthHeaders();
        const cardData = {
            firstName: form.firstName.value,
            lastName: form.lastName.value,
            title: form.title.value,
            company: form.company.value,
            phoneNumber: form.phoneNumber.value,
            email: form.email.value,
            address: form.address.value,
            website: form.website.value,
            profileImageUrl: form.profileImageUrl.value,
            userId: userId,
            socialMediaLinks: [],
            contactOptions: [],
            customFields: [],
        };

        try {
            const response = await fetch(`${API_BASE_URL}/api/v1/User/CreateNewCard`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    ...getAuthHeaders()
                },
                body: JSON.stringify(cardData),
            });

            if (response.ok) {
                alert('Card created successfully!');
                loadCards();
                form.reset();
            } else {
                alert('Failed to create card.');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    });

    async function loadCards() {
        try {
            const userId = localStorage.getItem('userId'); // Assuming userId is stored in localStorage
            const response = await fetch(`${API_BASE_URL}/api/v1/User/GetUserCards?userId=${userId}`, {
                headers: getAuthHeaders()
            });
            debugger;
            const res = await response.json();
            const cards = res.data;

            cardsContainer.innerHTML = '';
            cards.forEach(card => {
                const cardElement = document.createElement('div');
                cardElement.className = 'card';
                cardElement.innerHTML = `
                    <h3>${card.firstName} ${card.lastName}</h3>
                    <p>${card.title}</p>
                    <p>${card.company}</p>
                    <p>${card.phoneNumber}</p>
                    <p>${card.email}</p>
                    <p>${card.address}</p>
                    <p>${card.website}</p>
                `;
                cardsContainer.appendChild(cardElement);
            });
        } catch (error) {
            console.error('Error:', error);
        }
    }

    loadCards();
});
