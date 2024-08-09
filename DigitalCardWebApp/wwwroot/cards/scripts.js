document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('cardForm');
    const cardsContainer = document.getElementById('cardsContainer');

    const API_BASE_URL = 'http://localhost:8746';
    const userId = Number(localStorage.getItem('userId'));

    // Function to get the authorization header with the token
    const getAuthHeaders = () => {
        const token = localStorage.getItem('token');
        return token ? { 'Authorization': `Bearer ${token}` } : {};
    };

    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        // Extract custom fields
        const customFields = [];
        const fieldNames = form.querySelectorAll('input[name="customFieldName[]"]');
        const fieldValues = form.querySelectorAll('input[name="customFieldValue[]"]');
        for (let i = 0; i < fieldNames.length; i++) {
            if (fieldNames[i].value && fieldValues[i].value) {
                customFields.push({
                    fieldName: fieldNames[i].value,
                    fieldValue: fieldValues[i].value,
                });
            }
        }

        // Extract social media links
        const socialMediaLinks = [{
            linkedIn: form.linkedIn.value,
            twitter: form.twitter.value,
            facebook: form.facebook.value,
            instagram: form.instagram.value,
            github: form.github.value
        }];

        // Extract contact options
        const contactOptions = [{
            phone: form.contactPhone.checked,
            email: form.contactEmail.checked,
            address: form.contactAddress.checked,
        }];

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
            socialMediaLinks: socialMediaLinks,
            contactOptions: contactOptions,
            customFields: customFields
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
            debugger
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
            const response = await fetch(`${API_BASE_URL}/api/v1/User/GetUserCards?userId=${userId}`, {
                headers: getAuthHeaders()
            });
            debugger

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }

            const res = await response.json();
            const cards = res.data;
         
            cardsContainer.innerHTML = '';
            cards.forEach(card => {
                const cardElement = document.createElement('div');
                cardElement.className = 'card';
                cardElement.innerHTML = `
                    <img src="${card.profileImageUrl}" alt="Profile Image" class="img-thumbnail">
                    <h3>${card.firstName} ${card.lastName}</h3>
                    <p>${card.title} at ${card.company}</p>
                    <p><strong>Phone:</strong> ${card.phoneNumber}</p>
                    <p><strong>Email:</strong> ${card.email}</p>
                    <p><strong>Address:</strong> ${card.address}</p>
                    <p><strong>Website:</strong> <a href="${card.website}" target="_blank">${card.website}</a></p>
                    <div class="social-media-links">
                        ${card.socialMediaLinks[0].linkedIn ? `<p><strong>LinkedIn:</strong> <a href="${card.socialMediaLinks[0].linkedIn}" target="_blank">${card.socialMediaLinks[0].linkedIn}</a></p>` : ''}
                        ${card.socialMediaLinks[0].twitter ? `<p><strong>Twitter:</strong> <a href="${card.socialMediaLinks[0].twitter}" target="_blank">${card.socialMediaLinks[0].twitter}</a></p>` : ''}
                        ${card.socialMediaLinks[0].facebook ? `<p><strong>Facebook:</strong> <a href="${card.socialMediaLinks[0].facebook}" target="_blank">${card.socialMediaLinks[0].facebook}</a></p>` : ''}
                        ${card.socialMediaLinks[0].instagram ? `<p><strong>Instagram:</strong> <a href="${card.socialMediaLinks[0].instagram}" target="_blank">${card.socialMediaLinks[0].instagram}</a></p>` : ''}
                        ${card.socialMediaLinks[0].github ? `<p><strong>GitHub:</strong> <a href="${card.socialMediaLinks[0].github}" target="_blank">${card.socialMediaLinks[0].github}</a></p>` : ''}
                    </div>
                    <div class="contact-options">
                        <p><strong>Contact Options:</strong></p>
                        ${card.contactOptions[0].phone ? '<p>Phone</p>' : ''}
                        ${card.contactOptions[0].email ? '<p>Email</p>' : ''}
                        ${card.contactOptions[0].address ? '<p>Address</p>' : ''}
                    </div>
                    <div class="custom-fields">
                        ${card.customFields.length > 0 ? '<p><strong>Custom Fields:</strong></p>' : ''}
                        ${card.customFields.map(field => `<p>${field.fieldName}: ${field.fieldValue}</p>`).join('')}
                    </div>
                `;
                cardsContainer.appendChild(cardElement);
            });
        } catch (error) {
            console.error('Error:', error);
        }
    }

    loadCards();
});
