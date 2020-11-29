(function () {
    const alertElement = document.querySelector("#success-alert");
    const formElement = document.forms[0];
    //const getAllButton = document.querySelector('.exchanges__get-button');

    const addNewItem = async () => {
        const Name = document.querySelector('#Name').value;
        const Description = document.querySelector('#Description').value;
        const IsVisible = document.querySelector('#IsVisible').checked;

        const requestData = {
            Name,
            Description,
            IsVisible
        }

        const response = await fetch('/api/adding', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(requestData),
        });

        const responseJson = await response.json();

        if (responseJson.success) {
            alertElement.style.display = 'block'
        }

        return responseJson;
    };

    const goToAllEntities = () => window.location.replace('/ItemsList');

    window.addEventListener('load', () => {
        formElement.addEventListener('submit', e => {
            e.preventDefault();

            addNewItem().then((res) => console.log(res));
        })

        document.querySelector('.exchanges__get-button').addEventListener('click', goToAllEntities);

    })


})();