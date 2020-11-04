(function () {
    const alertElement = document.querySelector("#success-alert");
    const formElement = document.forms[0];

    const addNewItem = async () => {
        const Name = document.querySelector('#Name').value;
        const Description = document.querySelector('#Description').value;
        const IsVisible = document.querySelector('#IsVisible').value;

        const requestData = {
            Name,
            Description,
            IsVisible
        }
        console.log(requestData);

        const response = await fetch('api/Adding', {
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
    };

    window.addEventListener('load', () => {
        formElement.addEventListener('submit', e => {
            e.preventDefault();

            addNewItem().then((res) => console.log(res));
        })
    })

})();