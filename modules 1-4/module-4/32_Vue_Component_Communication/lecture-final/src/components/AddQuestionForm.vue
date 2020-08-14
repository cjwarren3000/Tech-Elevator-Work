<template>
      <form id="addQuestion" 
            v-on:submit.prevent="addQuestion()"> <!-- Same thing as v-if="showAddQuestion == true" -->
        <div class="form-group">
          <label>Question</label>
          <input type="text" required id="newQuestion" 
                 v-model.trim="newQuestion.question">
        </div>
        <div class="form-group">
          <label>Answer</label>
          <textarea id="newAnswer" 
                 v-model.trim.lazy="newQuestion.answer">
          </textarea>
        </div>
        <div class="form-group">
          <label for="newDifficulty">Difficulty</label>
          <!-- Ideally this should be a select instead of an input, but this lets us demo modifiers -->
          <input type="number" min="1" max="3" 
                 id="newDifficulty"
                 v-model.number="newQuestion.difficulty">
        </div>
        <input type="submit" value="Add Question">
        <input type="button" value="Cancel" v-on:click="hideForm()">
      </form>    
</template>

<script>
export default {
    name: 'AddQuestionForm',
    data() {
        return {
            newQuestion: {
                question: '',
                answer: '',
                difficulty: 2
            }
        }
    },
    methods: {
        /**
         * Calculates and returns the next available question id. This should be 1 greater than
         * the maximum current question id.
         * @returns {number} the next available question id
         */
        calculateNextAvailableId() {
            const questions = this.$store.state.questions;
            return questions.reduce((prev, question) => Math.max(prev, question.id + 1), 1);
        },
        clearForm() {
            this.newQuestion.question = '';
            this.newQuestion.answer = '';
            this.newQuestion.difficulty = 2;
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
            //this.$store.state.questions.push(toAdd); // Don't do this. This is bad
            this.$store.commit('ADD_QUESTION', toAdd);

            // Default us to good values for the next time we show the form
            this.clearForm();
        }, 
        /**
         * Hides the add question form
         */
        hideForm() {
            this.$store.commit('HIDE_ADD_QUESTION');
        } 
    }      
}
</script>

<style>

</style>