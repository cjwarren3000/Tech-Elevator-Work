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
      <img
        src="../assets/images/SquirrelStone.jpg"
        title="A squirrel looking confused in a crowd of people"
      />
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
          <!-- TODO: Filter on search text -->
          <input type="search" id="search" placeholder="Search questions or tags" />
        </div>
      </div>
      <div class="form-group">
        <label for="difficulty">Difficulty</label>
        <!-- TODO: Filter on difficulty -->
        <select id="difficulty">
          <option value selected>Show All</option>
          <option value="1">Easy</option>
          <option value="2">Medium</option>
          <option value="3">Hard</option>
        </select>
      </div>

      <div class="questionContainer" id="divQuestions">
        <!-- TODO: Cards go here -->
        <!-- TODO: Bind classes. Always include blur, but only include hard if difficulty == 3 -->
        <article class="blur">
          <div class="question">Question Goes Here</div>
          <div class="answer">Answer Goes Here</div>
        </article>
      </div>
    </section>
    <section id="closing">
      <h2>Not Enough?</h2>
      <p>
        Think we're missing something?
        <a href="askaquestion.html">Submit a Question</a> and help us out!
      </p>
      <p>
        Don't like something you see?
        <a href="contact.html">Contact us</a> and let us know!
      </p>
    </section>
  </main>
</template>

<!-- Script is the core data and logic associated with the component. It is required -->
<script>
export default {
  // Name is optional, but usually a good idea. This shows up in dev tools
  name: "QuestionsPage",
  // Data contains information specific to our application
  data() {
    return {
      filter: {
        searchText: "",
        difficulty: 0
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
          answer:
            "The virtual keyword allows a method to be overridden in an inheriting class.",
          difficulty: 1
        },
        {
          id: 3,
          question: "What do you need to do to override a method in C#?",
          answer:
            "Mark the method as virtual, inherit from the class, and use the overrides keyword to override it in the inheriting class.",
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
          answer:
            "The test runner discovers and calls each test method. If an exception occurs and is unhandled, the test fails. Asserts throw exceptions when they fail.",
          difficulty: 3
        },
        {
          id: 6,
          question: "What is the purpose of semantic HTML?",
          answer:
            "Semantic HTML helps tools understand the structure of a web page",
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

      // TODO: If the user typed in some search parameters, filter via search

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

<!-- Style contains the styling data for this component. 
     Scoped means that classes should affect only this component and not others on the page -->
<style scoped>
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

aside {
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

.question-header {
  color: #f6931d;
}

/* List item styling */

article {
  border: #3b3e42 solid 1px;
  border-radius: 0.5rem;
  background-color: #ffcb48;
  overflow: none;
  color: #ffffff;
  text-shadow: 2px 2px #999999;
  padding: 0;
  margin: 0.5rem;
  box-shadow: 0.25rem 0.25rem #999999;
}

article:hover {
  background-color: #f6931d;
}

/* Styling areas of the list items */

.answer {
  padding: 0.5rem;
  background-color: #3b3e42;
  text-shadow: none;
  height: 8rem;
  overflow: auto;
  font-size: small;
}

.question {
  height: 2rem;
  padding: 0.5rem;
  font-weight: bold;
  min-height: 37px;
}

article.blur {
  background-color: #00adee;
}
article.hard {
  background-color: #c63f3f;
}

article.blur:hover {
  background-color: #f6931d;
}

article.blur:hover .answer {
  color: #ffffff;
  text-shadow: none;
}

/* Blur the answer text by default */
article.blur .answer {
  color: transparent;
  text-shadow: 0 0 5px #ffffff;
}

main aside {
  margin-top: 1rem;
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