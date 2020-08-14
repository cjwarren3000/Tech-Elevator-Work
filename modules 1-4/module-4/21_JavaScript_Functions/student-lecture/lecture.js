/**
 * Write a function called multiplyTogether that multiplies two numbers together. But 
 * what happens if we don't pass a value in? What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */
// TODO: Write me

/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=0] the second parameter to multiply
 */
// TODO: Write me
 
/**
 * Functions can return earlier before the end of the function. This could be useful
 * in circumstances where you may not need to perform additional instructions or have to
 * handle a particular situation.
 * In this example, if the firstParameter is equal to 0, we return secondParameter times 2.
 * Observe what's printed to the console in both situations.
 */
function returnBeforeEnd(firstParameter, secondParameter) {
  console.log("This will always fire.");

  if (firstParameter == 0) {
    console.log("Returning secondParameter times two.");
    return secondParameter * 2; // NOTE: We do not need to return the same data type here! We could return anything
  }

  //this only runs if firstParameter is NOT 0
  console.log("Returning firstParameter + secondParameter.");
  return firstParameter + secondParameter;
}

/**
 * Create and return a new object representing a car
 * @returns {Object} the new car
 */
function buildMyCar() {
  return {
    make: 'Honda',
    model: 'Civic',
    year: 2017,
    color: 'Blue',

    // Functions are just a data type, so any property can hold a function.
    honk: function honkHorn() { // honkHorn here is essentially meaningless, but may show up in a stack trace
      console.warn('Beep beep!');
    },
  };
}

/**
 * Scope is defined as where a variable is available to be used.
 *
 * If a variable is declare inside of a block, it will only exist in
 * that block and any block underneath it. Once the block that the
 * variable was defined in ends, the variable disappears.
 */
function scopeTest() {
  // This variable will always be in scope in this function
  let inScopeInScopeTest = true;

  {
    // this variable lives inside this block and doesn't
    // exist outside of the block
    let scopedToBlock = true;
  }

  // scopedToBlock doesn't exist here so an error will be thrown
  if (inScopeInScopeTest && scopedToBlock) {
    console.log("This won't print!");
  }
}

// ARRAY FUNCTIONS BELOW

const allEmployees = [
  {
    first: 'Matt',
    last: 'Eland',
    cohortsTaught: 2,
    salary: 'Crate of burritos via airdrop',
    writeCode: function() { console.log('Matt is coding');}
  },
  {
    first: 'John',
    last: 'Fulton',
    cohortsTaught: 11,
    salary: 'Immense satisfaction from watching you all succeed',
    writeCode: function() { console.log('John is coding');}
  }
];

/**
 * Has each instructor write code by calling their writeCode function via foreach
 *
 * @param {Object[]} employees the employees who should code
 */
function everyoneCodes(employees) {
  // TODO
}

/**
 * Takes an array of employees and returns a new array containing instructors who have taught at least the specified number of cohorts
 *
 * @param {Object[]} employees the employees
 * @param {number} [minimumCohorts=1] the minimum number of cohorts an instructor has been around
 * @returns {Object[]} the employees matching the requirements
 */
function getEliteInstructors(employees, minimumCohorts = 1) {
  // TODO
}

/**
 * Takes an array of employees and returns a new array of their salaries
 * @param {Object[]} employees the employees to map to salary values
 * @returns {string[]} the salary of each employee
 */
function getEmployeeSalaries(employees) {
  // TODO
}

/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {Object[]} employees the employees
 * @returns {number} sum of the total cohorts taught
 */
function getTotalCohortsTaught(employees) {
  // TODO
}

// TODO: Rewrite the writeCode methods as expression syntax

// TODO: Illustrate some of these functions with named functions instead of expressions