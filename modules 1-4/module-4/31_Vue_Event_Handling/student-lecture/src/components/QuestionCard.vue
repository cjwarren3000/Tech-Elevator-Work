<!-- Template defines the way the component renders on the web page -->
<template>
    <!-- We want to use the .blur if the answer is hidden, .correct if it was 
         graded as correct, and .incorrect if it was graded as incorrect -->
    <article v-bind:class="{blur: !isAnswerVisible,
                            correct: isCorrect == true,
                            incorrect: isCorrect == false}">
        <div class="question">{{item.question}}</div>
        <div class="answer">{{item.answer}}</div>
        <div class="questionFooter">
            <div>
                <!-- TODO: hide this if the answer is visible -->
                <!-- TODO: when clicked, make the answer visible -->
                <a class="showAnswer" title="Show Answer">
                    <i class="fas fa-eye fa-2x"></i>
                </a>
                <!-- TODO: hide this if the answer is hidden -->
                <!-- TODO: when clicked, make the answer hidden -->
                <a class="hideAnswer" title="Hide Answer" >
                    <i class="fas fa-eye-slash fa-2x"></i>
                </a>
            </div>
            <div>
                <!-- TODO: hide this if the answer is correct -->
                <!-- TODO: when clicked, mark the question as correct and the answer visible -->
                <a class="markCorrect" title="Mark Correct">
                    <i class="fas fa-thumbs-up fa-2x"></i>
                </a>
                <!-- TODO: hide this if the answer is incorrect -->
                <!-- TODO: when clicked, mark the question as incorrect and the answer visible -->
                <a class="markIncorrect" title="Mark Incorrect">
                    <i class="fas fa-thumbs-down fa-2x"></i>
                </a>
            </div>
        </div>
    </article>
</template>

<!-- Script is the core data and logic associated with the component. It is required -->
<script>
export default {
  // Name is optional, but usually a good idea. This shows up in dev tools
  name: "QuestionCard",
  // Props contains an array of things that can be passed in to a component.
  // These can be bound to just like anything in data can.
  // More advanced props usage can be found at https://vuejs.org/v2/api/#props
  props: ['item'], // TODO: Discuss if time allows
  // Methods contain functions which can be invoked from event handlers or other code
  methods: {
      // TODO: We'll probably want a method here for grading
  },
  // Data contains information specific to our application
  data() {
    return {
        isAnswerVisible: false,
        isCorrect: undefined // We have to explicitly declare this so that change detection works
    };
  },
  // Computed contains the Vue.js equivalent of getters that rely on other data to compute results.
  // Think of computed as computed or auto-calculated properties that are bound to from the template.
  computed: {
      showAnswerVisible() {
          return !this.isAnswerVisible;
      },
      hideAnswerVisible() {
          return this.isAnswerVisible;
      },    
      editAnswerVisible() {
          return false; // Not supported until we have routing in place
      },    
      markCorrectVisible() {
          return this.isCorrect !== true;
      },    
      markIncorrectVisible() {
          return this.isCorrect !== false;
      },    
  }
};
</script>

<style>
.question-header {
  color: #f6931d;
}

/* Question Card Footer Styling */
.questionFooter {
    display: flex;
    padding: 0.5rem;
    align-content: center;
    justify-content: space-between;
}

.questionFooter>div {
    display: inline-block;
}

.questionFooter a {
    color: #ffffff;
    margin: 0 0.25rem;
}

.questionFooter a:hover {
    color: #FFCB48;
}

.questionFooter a.markCorrect:hover {
    color: #8CC63F;
}

.questionFooter a.markIncorrect:hover {
    color: #c63f3f;
}

/* Correct / Incorrect Styling */
article.correct {
    background-color: #8CC63F;
}

article.incorrect {
    background-color: #c63f3f;
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

article.blur:hover {
  background-color: #f6931d;
}

/* Blur the answer text by default */
article.blur .answer {
  color: transparent;
  text-shadow: 0 0 5px #ffffff;
}
</style>