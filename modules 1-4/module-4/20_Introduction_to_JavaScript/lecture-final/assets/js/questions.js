'use strict'; // Forces JavaScript into "safe / strict" mode

// --------------------------------------------------------------------
// TODO: Code below is for our ZEROTH coding session
// --------------------------------------------------------------------

/*
    Example of a multi-line comment just like in C#/Java
*/

// Single line comment - WHICH I CAN EDIT!!!
function logStuff() {
  console.debug("Debug message from our JavaScript file!");
  console.log("Log message from our JavaScript file!");
  console.info("Info message from our JavaScript file!");
  console.warn("Warning message from our JavaScript file!");
  console.error("Error message from our JavaScript file!");
}

function someCode() {
  // var oldVariable is hoisted here

  if (true) {
    let myVariable = 42;
    var oldVariable = 21;
    const iAmUnchanging = 35;
  }

  // myVariable does not exist here
}

// --------------------------------------------------------------------
// TODO: Code below is for our FIRST coding session
// --------------------------------------------------------------------

/**
 * Functions start with the word function.
 * They don't have a return type and the naming convention is camel-case.
 */
function variables() {
  // TODO: Declares a variable where the value cannot be changed
  const zebRules = true;

  // TODO: Declares a variable those value can be changed
  let numberOfTearsShedProgrammingJavaScript = 0;

  // TODO: Declares a variable that will always be an array
  const someArray = [];
  someArray[0] = 'Zeroth';
  someArray.push('Hello');
  someArray.push('Arrays');

  // TODO: Demonstrate console logging
  console.log('Hello Arrays contents', someArray);
  console.table(someArray);
}

/**
 * Functions can also accept parameters.
 * Notice the parameters do not have types.
 * @param {Number} param1 The first number to display
 * @param {Number} param2 The second number to display
 */
function printParameters(param1, param2) {
  // TODO: Discuss this
  console.log('The value of param1 is ' + param1);
  console.log(`The value of param1 is ${param1}`);
  console.log(`The value of param2 is ${param2}`);
}

// --------------------------------------------------------------------
// TODO: Code below is for our SECOND coding session
// --------------------------------------------------------------------

/**
 * Compares two values x and y.
 * == is loose equality
 * === is strict equality
 * @param {Object} x
 * @param {Object} y
 */
function equality(x, y) {
  if (typeof x == 'boolean' || typeof y == "number") {
    // do something specific to this case
  }

  // TODO: Discuss this
  console.log(`x is ${typeof x}`);
  console.log(`y is ${typeof y}`);

  console.log(`x == y : ${x == y}`); // true
  console.log(`x === y : ${x === y}`); // false
}

/**
 * Each value is inherently truthy or falsy.
 * false, 0, '', null, undefined, and NaN are always falsy
 * everything else is always truthy
 * @param {Object} x The object to check for truthy or falsy,
 */
function falsy(x) {
  // TODO: Discuss this
  if (x) {
    console.log(`${x} is truthy`);
    return true;
  } else {
    console.log(`${x} is falsy`);
    return false;
  }
}

function buildMyCar() {
  return {make: 'Honda', model: 'Civic'};
}

/*
########################
Function Overloading
########################

Function Overloading is not available in Javascript. If you declare a
function with the same name, more than one time in a script file, the
earlier ones are overriden and the most recent one will be used.

TODO: Discuss this
*/

function Add(num1, num2) {
  return num1 + num2;
}

function Add(num1, num2, num3) {
  return num1 + num2 + num3;
}

// --------------------------------------------------------------------
// TODO: Code below is for our THIRD coding session
// --------------------------------------------------------------------

/**
 *  Objects are simple key-value pairs
    - values can be primitive data types
    - values can be arrays
    - or they can be functions
*/
function objects() {
  const person = {
    firstName: "Bill",
    lastName: "Lumbergh",
    age: 42,
    employees: [
      "Peter Gibbons",
      "Milton Waddams",
      "Samir Nagheenanajar",
      "Michael Bolton",
    ],
  };

  // TODO: Log the object
  console.WriteLine = console.log;
  console.log(person);

  // TODO: Log the first and last name
  console.log(`${person.firstName} ${person.lastName}`);

  // TODO: Log each employee
  for (let emp of person.employees) { // Foreach
    console.log(emp);
  }
  for (let i = 0; i < person.employees.length; i++) { // For loop
    console.log(person.employees[i]);
  }
}

// --------------------------------------------------------------------
// TODO: Code below is for our FOURTH coding session
// --------------------------------------------------------------------

/*
########################
Math Library
########################

A built-in `Math` object has properties and methods for mathematical constants and functions.
*/

function mathFunctions() {
  // TODO: Discuss this
  console.log("Math.PI : " + Math.PI);
  console.log("Math.LOG10E : " + Math.LOG10E);
  console.log("Math.abs(-10) : " + Math.abs(-10));
  console.log("Math.floor(1.99) : " + Math.floor(1.99));
  console.log("Math.ceil(1.01) : " + Math.ceil(1.01));
  console.log("Math.random() : " + Math.random());
}

/*
########################
String Methods
########################

The string data type has a lot of properties and methods similar to strings in Java/C#
*/

function stringFunctions(value) {
  // TODO: Discuss this
  console.log(`.length -  ${value.length}`);
  console.log(`.endsWith('World') - ${value.endsWith("World")}`);
  console.log(`.startsWith('Hello') - ${value.startsWith("Hello")}`);
  console.log(`.indexOf('Hello') - ${value.indexOf("Hello")}`);

  /*
    Other Methods
        - split(string)
        - substr(number, number)
        - substring(number, number)
        - toLowerCase()
        - trim()
        - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    */
}

// --------------------------------------------------------------------
// TODO: Code below is for our FIFTH coding session
// --------------------------------------------------------------------

// TODO: Add a function to filter out a specific value from an array
// TODO: Cover Array indexers
// TODO: Cover Array.Push
// TODO: Cover Array.Splice
// TODO: Cover Array.Slice
// TODO: Cover Array.Concat

function noFours(someArray) {
  const newArray = [];

  for (let element of someArray) { // Loop over all elements in someArray
    if (element !== 4) { // Don't allow 4
      newArray.push(element); // Add it to the array to return
    }
  }

  return newArray;
}

const someOtherArray = [1, 2, 3];

function noSecondElement(someArray) {
  const newArray = someArray.slice(); // Get a copy of someArray

  if (newArray.length > 1) {
    newArray.splice(1, 1); // Remove 1 element starting at index 1
  }

  return newArray;
}