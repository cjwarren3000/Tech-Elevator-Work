<!-- Template defines the way the component renders on the web page -->
<template>
    <div class="questionContainer" id="divQuestions">
        <question-card v-for="item of filteredItems" v-bind:key="item.id"                       
                       v-bind:cardData="item" />
    </div>
</template>

<!-- Script is the core data and logic associated with the component. It is required -->
<script>
import QuestionCard from './QuestionCard.vue';

export default {
  // Name is optional, but usually a good idea. This shows up in dev tools
  name: "QuestionList",
  // Contains a list of components which must be included in the template
  components: {
    QuestionCard
  },
  // Contains properties which are like data, but the value is passed in from another component
  props: [],
  // Methods contain functions which can be invoked from event handlers or other code
  methods: {
  },
  // Data contains information specific to our application
  data() {
    return {
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
      let results = this.$store.state.questions;

      const filter = this.$store.state.filter;

      // If the user typed in some search parameters, filter via search
      if (filter.searchText) {
        const lowerCaseSearch = filter.searchText.toLowerCase();
        results = results.filter(item => {
          return item.question.toLowerCase().includes(lowerCaseSearch);
        });
      }

      // If the user selected a difficulty, filter down to that difficulty only
      if (filter.difficulty) {
        results = results.filter(item => {
          return item.difficulty == filter.difficulty;
        });
      }

      return results;
    }
  }
};
</script>

<style>
#questionList {
  grid-area: questionsList;
}

.questionContainer {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
}
</style>