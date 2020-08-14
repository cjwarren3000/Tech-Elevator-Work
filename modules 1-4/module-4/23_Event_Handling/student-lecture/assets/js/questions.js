'use strict'; // Forces JavaScript into "safe / strict" mode

// These will be set when the DOM is loaded
let template = null;
let container = null;

const questions = [
  {
      question: 'What is the Sealed Keyword?',
      answer: 'The sealed keyword prevents a class from being inherited.',
      isCorrect: false,
  },
  {
      question: 'What is the Virtual Keyword?',
      answer: 'The virtual keyword allows a method to be overridden in an inheriting class.',
      isCorrect: false,
  },
  {
      question: 'What do you need to do to override a method in C#?',
      answer: 'Mark the method as virtual, inherit from the class, and use the overrides keyword to override it in the inheriting class.',
      isCorrect: false,
  },
  {
      question: 'What is the Purpose of a Using Statement in a Method?',
      answer: 'A using statement creates something that implements the IDisposable interface and invokes Dispose on it when the using block ends. This ensures that database connections, file handles, and other critical resources are always properly disposed - even if an Exception occurs.',
      isCorrect: false,
  },
  {
      question: 'What structure should a unit test follow within a test method?',
      answer: 'Arrange / Act / Assert',
      isCorrect: false,
  },
  {
      question: 'What are the major unit test frameworks for .NET?',
      answer: 'MSTest, XUnit, and NUnit',
      isCorrect: false,
  },
  {
      question: 'How does a Unit Test Work?',
      answer: 'The test runner discovers and calls each test method. If an exception occurs and is unhandled, the test fails. Asserts throw exceptions when they fail.',
      isCorrect: false,
  },
  {
      question: 'What is the purpose of semantic HTML?',
      answer: 'Semantic HTML helps tools understand the structure of a web page',
      isCorrect: false,
  }
];

// This function is called when the DOM is ready to interact with
// If we tried to interact with it before this, DOM interaction would fail
document.addEventListener('DOMContentLoaded', () => {

    // Get one time references to things we'll use later on
    container = document.getElementById('divQuestions');
    template = document.getElementById('cardTemplate');

    // Populate the initial list of questions
    updateCardList(questions);

    const searchButton = document.getElementById('btnSearch');
    const searchBox = document.getElementById('search');

    // TODO: Subscribe to the search button click and call searchCards with searchBox's value when that occurs
});

/**
 * Adds a card for the specified question to the DOM
 * @param {object} quest the question to generate a card for
 */
function addCardForQuestion(quest) {
    // Clone the template and get its content
    const clonedTemplate = template.content.cloneNode(true);
    const article = clonedTemplate.querySelector('article');

    // Set the question and answer of the element we're about to add to the DOM
    article.querySelector('.question').innerText = quest.question;
    article.querySelector('.answer').innerText = quest.answer;

    // If we previously marked the question correct, apply the 'correct' class to it
    if (quest.isCorrect) {
        article.classList.add('correct');
    }

    // TODO: We need to subscribe to the double click event to add or remove the blur class

    // TODO: If time allows, show other event handler code (commented out below)
    
    // Add the new element to the DOM
    container.appendChild(article);
}

/* For later
    // Respond to clicks on the show / hide answer buttons by toggling the blur class which styles the answer visibility
    article.querySelector('.showAnswer').addEventListener('click', () => article.classList.remove('blur'));
    article.querySelector('.hideAnswer').addEventListener('click', () => article.classList.add('blur'));

    // Respond to clicks on grading buttons by marking the answer as correct or incorrect
    article.querySelector('.markCorrect').addEventListener('click', () => gradeAnswer(article, quest, true));
    article.querySelector('.markIncorrect').addEventListener('click', () => gradeAnswer(article, quest, false));
*/

/**
 * Searches the questions array for questions matching the specified searchText and 
 * then updates the displayed questions
 * @param {string} searchText the text to search for
 */
function searchCards(searchText) {
    const filteredQuestions = questions.filter((q) => doesQuestionMatchSearch(q, searchText));
  
    console.log(`Searching for ${searchText} resulted in`, filteredQuestions);
  
    updateCardList(filteredQuestions);
}

/**
 * Updated the questions list in the DOM with question cards based on the specified questions.
 * @param {Object[]} questionData the questions to display
 */
function updateCardList(questionData) {
    // Find the question container (questionContainer class or divQuestions id)
    container.innerHTML = ''; // Clear anything that was in there previously
  
    // Loop over the questions array and add one card per question
    questionData.forEach((quest) => addCardForQuestion(quest, template, container));  
}

/**
 * Determines whether or not the question matches the search
 * @param {Object} q the question
 * @param {string} search the text to search for
 * @returns {boolean} whether or not the question matches the search
 */
function doesQuestionMatchSearch(q, search) {
    if (!search) return true;
    
    return q.question.toLowerCase().includes(search.toLowerCase());
  }

  /**
 * Grades a specific question by marking it on the question object and updating the DOM element provided
 * @param {Node} questionElement the DOM element representing the question
 * @param {object} question the object representing the question's data
 * @param {boolean} isCorrect whether or not the question is correctly answered
 */
function gradeAnswer(questionElement, question, isCorrect) {
    if (isCorrect) {
        questionElement.classList.remove('incorrect');
        questionElement.classList.add('correct');
    } else {
        questionElement.classList.remove('correct');
        questionElement.classList.add('incorrect');
    }

    question.isCorrect = isCorrect;
}