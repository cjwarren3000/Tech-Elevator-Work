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
      question: 'What is the purpose of semantic HTML?',
      answer: 'Semantic HTML helps tools understand the structure of a web page',
  }
];

// This function is called when the DOM is ready to interact with
// Don't worry about this syntax for today, but this will be relevant tomorrow. 
document.addEventListener('DOMContentLoaded', () => {

  console.log('Hello from Questions.js');

  // (PART 1 - Querying the DOM)
  // TODO: Find the question container (questionContainer class or divQuestions id)
  
  // TODO: Log the question container to the console

  // (PART 2 - DOM Manipulation)

  // TODO: Set the InnerHTML and InnerText of the question container

  // TODO: Add the 'ugly' class to the question container

  // (PART 3 - Adding to the DOM)
  // TODO: Loop over the questions array
  {
    // TODO: Create a new h1 element

    // TODO: Append this element as a child element to the document

    // TODO: Add a class of 'question-header' to each element we create

    // (PART 4 - Templates)

    // TODO: Get a reference to the template in the document (ideally, this should be done once outside the loop)

    // TODO: Clone the template and get its content

    // TODO: Using insertAdjacentElement, add the template to the container
  }

  // TODO: Using document.querySelectorAll, query all articles that were created 
  
  // TODO: Add the "blur" class to each element that is created
  // (NOTE: we should do this when creating them earlier, not after the fact via a query - this is just for teaching querySelectorAll)

});