// REST PARAMETERS DEMO

/**
 * This function is a demonstration of the "rest" operator in JavaScript.
 * The rest operator (...) must be the last parameter passed in and represents
 * any additional parameters passed to the method. It is a replacement for arguments.
 * 
 * @param {number} firstNumber the first number to add
 * @param  {...number} otherNumbers any additional numbers to add. This will be an array
 * @returns {number} the total of all numbers provided
 */
function sumUsingRestParameters(firstNumber, ...otherNumbers) {
    console.log('Rest Operator', firstNumber, otherNumbers); 
    console.log('Arguments', arguments);

    // Add everything together
    return otherNumbers.reduce((total, num) => total + num, firstNumber);
 } 

function sum(...numbers) {
    let total = 0;

    numbers.forEach(num => total += num);

    return total;
}

// SHADOWING DEMO

let clickCounter = 0;

function handleClick(clickCounter){
  clickCounter++;
  button.addEventListener('click', () => {});
}

document.addEventListener('DOMContentLoadedNope', () => {
  const button = document.getElementById('doAwesomeThings');
  button.addEventListener('click', () => button.classList.toggle('someClass'));
  const allSpans = button.querySelectorAll('span');

  button.classList.add('someClassIWantToAdd');
  button.classList.remove('someClassWhichMayormaynotbepresent');
  handleClick();
});

