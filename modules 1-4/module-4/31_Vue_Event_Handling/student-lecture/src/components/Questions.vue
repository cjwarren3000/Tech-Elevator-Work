<!-- Template defines the way the component renders on the web page -->
<template>
  <main>
    <section id="opening">
      <h1>A Friendly Note</h1>
      <p>
        Don't worry if you can't give great answers to all or even most of these. Aim for being able to
        successfully answer around 70% or less of the questions asked of you.
      </p>
      <p>Focus on conveying a good impression as someone responsible, competent, and able to learn and grow.</p>
      <p>Remember that people are looking for someone who is:</p>
      <ul>
        <li>
          <em>Professional</em>,
          <em>Responsible</em>, and
          <em>Reliable</em>
        </li>
        <li>
          Knows how to program enough to work without
          <em>constant</em> help (regular check-ins are normal and
          expected)
        </li>
        <li>Able and willing to continue to learn and grow</li>
      </ul>
    </section>
    <aside>
      <img src="../assets/images/SquirrelStone.jpg" title="A squirrel looking confused in a crowd of people" />
      <cite>
        <span>Photo by Bram Naus on Unsplash</span>
      </cite>
      <blockquote>
        Remember; just try to represent yourself well. You don't have to know everything.
        <cite>- Sally the Squirrel</cite>
      </blockquote>
    </aside>
    <section id="questionList">
      <h2>Questions</h2>
      <p>Use the form below to search questions. Hover over a question to reveal the answer.</p>
      <div class="form-group">
        <div>
          <label for="search">Search</label>
          <input type="search" 
                 id="search" 
                 v-model="filter.searchText"
                 placeholder="Search questions or tags" />
        </div>
      </div>
      <div class="form-group">
        <label for="difficulty">Difficulty</label>
        <select id="difficulty" v-model="filter.difficulty">
          <option>Show All</option>
          <option value="1">Easy</option>
          <option value="2">Medium</option>
          <option value="3">Hard</option>
        </select>
      </div>
      <div class="questionContainer" id="divQuestions">
        <!-- NOTE: Questions have been moved into a QuestionCard component -->
        <question-card v-for="item of filteredItems" 
                       v-bind:key="item.id"
                       v-bind:item="item" />
      </div>
    </section>
    <section id="closing">
      <h2>Not Enough?</h2>
      <p>
        Think we're missing something?
        <!-- TODO: show the form when this is clicked -->
        <a>Submit a Question</a> 
        and help us out!
      </p>
      <!-- TODO: Only show this form sometimes -->
      <!-- TODO: handle the submit and discuss preventDefault -->
      <form id="addQuestion">
        <div class="form-group">
          <label>Question</label>
          <!-- TODO: Add a key handler and log the $event via the recordKey method -->
          <input type="text" required id="newQuestion" 
                 v-model="newQuestion.question">
        </div>
        <div class="form-group">
          <label>Answer</label>
          <textarea id="newAnswer" 
                 v-model="newQuestion.answer">
          </textarea>
        </div>
        <div class="form-group">
          <label for="newDifficulty">Difficulty</label>
          <!-- Ideally this should be a select instead of an input, but this lets us demo modifiers -->
          <!-- TODO: This should convert the value typed in to a number -->
          <input type="number" min="1" max="3" 
                 id="newDifficulty"
                 v-model="newQuestion.difficulty">
        </div>

        <!-- We could add a click handler here, but a click on a type="submit" will submit
             the form, so it's better to handle the form's submit event instead -->
        <input type="submit" value="Add Question">

        <!-- TODO: Add click handler here -->
        <input type="button" value="Cancel">
      </form>
    </section>
  </main>
</template>

<!-- Script is the core data and logic associated with the component. It is required -->
<script>
// Import allows us to reference other files. "export default" defines what we import
// and the name immediately after import is what we call it. In the case of components,
// this also defines what tag we use for them in our template.
import QuestionCard from './QuestionCard.vue';

export default {
  // Name is optional, but usually a good idea. This shows up in dev tools
  name: "QuestionsPage",
  // Components declares the list of child components which will be referenced in the template
  components: {
    QuestionCard
  },
  // Methods contain functions which can be invoked from event handlers or other code
  methods: {    
    /**
     * Calculates and returns the next available question id. This should be 1 greater than
     * the maximum current question id.
     * @returns {number} the next available question id
     */
    calculateNextAvailableId() {
      return this.questions.reduce((prev, question) => Math.max(prev, question.id + 1), 1);
    },
    /**
     * Adds the contents of data's newQuestion object to the questions array
     */
    addQuestion() {
      // Build out an object representing the new question we'll be adding
      const toAdd = {
        question: this.newQuestion.question,
        answer: this.newQuestion.answer,
        difficulty: this.newQuestion.difficulty,
        id: this.calculateNextAvailableId()
      };

      // Add the question to our list
      this.questions.push(toAdd);

      // Default us to good values for the next time we show the form
      this.newQuestion.question = '';
      this.newQuestion.answer = '';
      this.newQuestion.difficulty = 2;

      // Hide the form since we've just added our question
      this.setAddVisibility(false);
    },

    // TODO: We'll want something to change the visibility. We called it setAddVisibility elsewhere

    // TODO: Add a key logging method
  },

  // Data contains information specific to our application
  data() {
    return {
      filter: {
        searchText: "",
        difficulty: ""
      },
      showAddQuestion: false,
      lastKeyEvent: null,
      newQuestion: {
        question: '',
        answer: '',
        difficulty: 2
      },
      questions: [
        {
          id: 1,
          question: "What is the Sealed Keyword?",
          answer: "The sealed keyword prevents a class from being inherited.",
          difficulty: 2
        },
        {
          id: 2,
          question: "What is the Virtual Keyword?",
          answer: "The virtual keyword allows a method to be overridden in an inheriting class.",
          difficulty: 1
        },
        {
          id: 3,
          question: "What do you need to do to override a method in C#?",
          answer: "Mark the method as virtual, inherit from the class, and use the overrides keyword to override it in the inheriting class.",
          difficulty: 2
        },
        {
          id: 4,
          question: "What are the major unit test frameworks for .NET?",
          answer: "MSTest, XUnit, and NUnit",
          difficulty: 2
        },
        {
          id: 5,
          question: "How does a Unit Test Work?",
          answer: "The test runner discovers and calls each test method. If an exception occurs and is unhandled, the test fails. Asserts throw exceptions when they fail.",
          difficulty: 3
        },
        {
          id: 6,
          question: "What is the purpose of semantic HTML?",
          answer: "Semantic HTML helps tools understand the structure of a web page",
          difficulty: 1
        }
      ]
    };
  },
  // Computed contains the Vue.js equivalent of getters that rely on other data to compute results.
  // Think of computed as computed or auto-calculated properties that are bound to from the template.
  computed: {
    /**
     * Calculates the question items that should be visible given the data set and the current search
     * (if any is applied). This will be an array of questions.
     * @returns {object[]} an array of questions
     */
    filteredItems() {
      // NOTE: The 'this' keyword is very important to refer to things inside of your data
      let results = this.questions;

      // If the user typed in some search parameters, filter via search
      if (this.filter.searchText) {
        const lowerCaseSearch = this.filter.searchText.toLowerCase();
        results = results.filter(item => {
          return item.question.toLowerCase().includes(lowerCaseSearch);
        });
      }

      // If the user selected a difficulty, filter down to that difficulty only
      if (this.filter.difficulty) {
        results = results.filter(item => {
          return item.difficulty == this.filter.difficulty;
        });
      }

      return results;
    }
  }
};
</script>

<style>
/* Styling for the list container */

html body {
  grid-template-columns: 1fr;
  grid-template-areas:
    "navBar"
    "mainBody"
    "footer";
}

main {
  display: grid;
  grid-template-areas:
    "aFriendlyNote"
    "yet-another-squirrel"
    "questionsList"
    "notEnough";
}

#opening {
  grid-area: aFriendlyNote;
}

main aside {
  grid-area: yet-another-squirrel;
}

#questionList {
  grid-area: questionsList;
}

#closing {
  grid-area: notEnough;
}

.questionContainer {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
}

main aside {
  margin-top: 1rem;
}

input[type="button"] {
  margin-left: 0.5rem;
}

/* Responsive Layout Rules */
@media screen and (min-width: 768px) {
  main {
    grid-template-areas:
      "aFriendlyNote yet-another-squirrel"
      "questionsList questionsList"
      "notEnough notEnough";
  }
}
</style>