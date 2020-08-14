function respondToBlur(event) {
    console.log('A blur occurred. The last value was ' + event.target.value);
}

document.addEventListener('DOMContentLoaded', () => {
    // Submit Button has an id of btnSubmit
    // Form has an id of formContact
    // TODO: Try to react to the user submitting the form

    // TODO: Display a message to the user

    // TODO: Stop the browser from navigating

    // Get all form elements and test what happens when we do blurs
    const allInputs = document.querySelectorAll('input');
    allInputs.forEach(element => {
        // TODO: Add listeners to blur events
    });

});
