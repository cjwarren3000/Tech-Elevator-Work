function respondToBlur(event) {
    console.log('A blur occurred. The last value was ' + event.target.value);
}

document.addEventListener('DOMContentLoaded', () => {
    // Submit Button has an id of btnSubmit
    // Form has an id of formContact
    // TODO: Try to react to the user submitting the form
    const form = document.getElementById('formContact');
    form.addEventListener('submit', (event) => {
        console.log(event);
        alert("Seriously? Don't actually submit confidential information to untrusted sources!");

        event.preventDefault();
    });

    // TODO: Display a message to the user

    // TODO: Stop the browser from navigating

    // Get all form elements
    const allInputs = document.querySelectorAll('input');
    allInputs.forEach(element => {
        // TODO: Add listeners to blur events
        element.addEventListener('blur', respondToBlur);

        element.removeEventListener('blur', respondToBlur);
    });

});
