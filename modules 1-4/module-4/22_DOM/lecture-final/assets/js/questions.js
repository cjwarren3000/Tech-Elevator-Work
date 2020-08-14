'use strict'; // Forces JavaScript into "safe / strict" mode

const questions = [
  {
      question: 'What is the Sealed Keyword?',
      answer: 'The sealed keyword prevents a class from being inherited.',
  },
  {
      question: 'What is the Virtual Keyword?',
      answer: 'The virtual keyword allows a method to be overriden in an inheriting class.',
  },
  {
      question: 'What do you need to do to override a method in C#?',
      answer: 'Mark the method as virtual, inherit from the class, and use the overrides keyword to override it in the inheriting class.',
  },
  {
      question: 'What is the Purpose of a Using Statement in a Method?',
      answer: 'A using statement creates something that implements the IDisposable interface and invokes Dispose on it when the using block ends. This ensures that database connections, file handles, and other critical resources are always properly disposed - even if an Exception occurs.',
  },
  {
      question: 'What is the difference between C# and Java?',
      answer: 'C# is awesome. Java isn\'t.',
  },
  {
      question: 'What structure should a unit test follow within a test method?',
      answer: 'Arrange / Act / Assert',
  },
  {
      question: 'What are the major unit test frameworks for .NET?',
      answer: 'MSTest, XUnit, and NUnit',
  },
  {
      question: 'How does a Unit Test Work?',
      answer: 'The test runner discovers and calls each test method. If an exception occurs and is unhandled, the test fails. Asserts throw exceptions when they fail.',
  },
  {
    question: 'What is my adult beverage of choice?',
    answer: 'Diet Doctor Pepper',
},
{
      question: 'What is the purpose of semantic HTML?',
      answer: 'Semantic HTML helps tools understand the structure of a web page',
  }
];

// This function is called when the DOM is ready to interact with
// Don't worry about this syntax for today, but this will be relevant tomorrow. 
document.addEventListener('DOMContentLoaded', () => {

  console.log('Hello from Questions.js');

  // (PART 1 - Querying the DOM)
  // Find the question container (questionContainer class or divQuestions id)
  const container = document.getElementById('divQuestions');
  // container = document.querySelector('.questionContainer');
  
  // Log the question container to the console
  console.log(container);

  // (PART 2 - DOM Manipulation)

  // Set the InnerHTML and InnerText of the question container
  container.innerText = '';

  // Add the 'ugly' class to the question container
  container.classList.add('ugly');
  container.classList.remove('ugly');
  container.classList.remove('java-programmer');
  //container.style.border = '50rem solid red'; // Nobody will sit with you at lunch if you do this

  // (PART 3 - Adding to the DOM)
  // Loop over the questions array
  questions.forEach((quest) => {

    /*
    // Create a new h1 element
    let h1 = document.createElement('h1');
    h1.innerText = quest.question;
    h1.classList.add('question-header');

    // Append this element as a child element to the document
    // container.appendChild(h1);
    container.insertAdjacentElement('beforeend', h1); // same as appendChild(h1)
    */

    // (PART 4 - Templates)

    // TODO: Get a reference to the template in the document (ideally, this should be done once outside the loop)
    const template = document.getElementById('cardTemplate');
    // console.log(template);

    // Clone the template and get its content
    const includeChildren = true;
    const clonedTemplate = template.content.cloneNode(includeChildren);

    const article = clonedTemplate.querySelector('article');

    const questionHeader = article.querySelector('.question');
    questionHeader.innerText = quest.question;

    const answerArea = article.querySelector('.answer');
    answerArea.innerText = quest.answer;

    // Using insertAdjacentElement, add the template to the container
    container.insertAdjacentElement('beforeend', article);
  });

  // TODO: Using document.querySelectorAll, query all articles that were created 
  const allArticles = document.querySelectorAll('article');
  allArticles.forEach((article) => {
    article.classList.add('blur');
  });
  
  // TODO: Add the "blur" class to each element that is created
  // (NOTE: we should do this when creating them earlier, not after the fact via a query - this is just for teaching querySelectorAll)

});

function multiplyByTwo(input) {
  return input * 2;
}

function reviewFunctions() {
  const numbers = [1,2,3];

  const output = numbers.map((num) => multiplyByTwo(num));

  return output;
}

/**
 * Write a function called useParameterToFilterArray that takes an anonymous
 * function and uses that in the `unfilteredArray` filter function. Return the result.
 *
 * @param {function} filterFunction the function to filter with
 * @returns {number[]} the filtered array
 */
let unfilteredArray = [1, 2, 3, 4, 5, 6];
function useParameterToFilterArray(filterFunction) {
	return unfilteredArray.find(filterFunction);
}

useParameterToFilterArray((num) => num === 4);