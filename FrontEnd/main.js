const baseUrl = 'https://localhost:7018/api/Persons';

document.addEventListener("DOMContentLoaded", () => {
    fetchPersons();
});

function fetchPersons() {
    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            const personTable = document.getElementById('person-table');
            personTable.innerHTML = '';

            data.forEach((person, index) => {
                const row = document.createElement('tr');

                row.innerHTML = `
                    <td>${index + 1}</td>
                    <td>${person.name}</td>
                    <td>${person.phone}, ${person.email}, ${person.role}, ${person.address}</td>
                    <td>
                        <button class="edit-btn" onclick="editPerson(${person.id})">Sửa</button>
                        <button class="delete-btn" onclick="showDeleteConfirmation(${person.id}, '${person.name}')">Xóa</button>
                    </td>
                `;

                personTable.appendChild(row);
            });
        })
        .catch(error => console.error('Error fetching persons:', error));
}

function showAddForm() {
    document.getElementById('form-container').style.display = 'block';
}

function savePerson() {
    const name = document.getElementById('name').value;
    const phone = document.getElementById('phone').value;
    const role = document.getElementById('role').value;

    const person = { name, phone, role };

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(person)
    })
    .then(response => response.json())
    .then(() => {
        fetchPersons();
        document.getElementById('form-container').style.display = 'none';
    })
    .catch(error => console.error('Error saving person:', error));
}

function editPerson(id) {
    fetch(`${baseUrl}/${id}`)
        .then(response => response.json())
        .then(person => {
            document.getElementById('name').value = person.name;
            document.getElementById('phone').value = person.phone;
            document.getElementById('role').value = person.role;

            document.querySelector('.save-btn').setAttribute('onclick', `updatePerson(${id})`);
            document.getElementById('form-container').style.display = 'block';
        })
        .catch(error => console.error('Error fetching person:', error));
}

function updatePerson(id) {
    const name = document.getElementById('name').value;
    const phone = document.getElementById('phone').value;
    const role = document.getElementById('role').value;

    const person = { id, name, phone, role };

    fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(person)
    })
    .then(() => {
        fetchPersons();
        document.getElementById('form-container').style.display = 'none';
    })
    .catch(error => console.error('Error updating person:', error));
}

function showDeleteConfirmation(id, name) {
    document.getElementById('delete-confirmation').style.display = 'block';
    document.getElementById('delete-person-name').textContent = name;
    document.querySelector('.delete-confirm-btn').setAttribute('onclick', `deletePerson(${id})`);
}

function deletePerson(id) {
    fetch(`${baseUrl}/${id}`, {
        method: 'DELETE'
    })
    .then(() => {
        fetchPersons();
        document.getElementById('delete-confirmation').style.display = 'none';
    })
    .catch(error => console.error('Error deleting person:', error));
}
