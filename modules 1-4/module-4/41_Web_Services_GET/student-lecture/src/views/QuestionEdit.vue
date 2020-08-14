<template>
    <div>
        <main>
            <section id="opening">
                <h1>Edit Question</h1>
                <question-card v-bind:cardData="question" />
            </section>
            <section id="editForm">
                <form id="editQuestion" v-on:submit.prevent="saveQuestion()">
                    <div class="form-group">
                    <label>Question</label>
                    <input type="text" required id="newQuestion" 
                           v-model.trim="question.question">
                    </div>
                    <div class="form-group">
                    <label>Answer</label>
                    <textarea id="newAnswer" 
                            v-model.trim="question.answer">
                    </textarea>
                    </div>
                    <div class="form-group">
                    <label for="newDifficulty">Difficulty</label>
                    <!-- Ideally this should be a select instead of an input, but this lets us demo modifiers -->
                    <input type="number" min="1" max="3" 
                            id="newDifficulty"
                            v-model.number="question.difficulty">
                    </div>
                    <input type="submit" value="Save">
                </form>   
            </section>
        </main>
    </div>
</template>

<script>
import QuestionCard from '../components/QuestionCard.vue';

export default {
    components: {
        QuestionCard
    },
    data() {
        return {
            question: null
        }
    },
    methods: {
        saveQuestion() {
            // TODO: Call to the server instead
            this.$store.commit('QUESTION_UPDATED', this.question);
            this.$router.push({name: 'QuestionDetails', params: {questionId: this.question.id}});
        }
    },
    // Created is called when a component is created. It's a good place to load data.
    created() {
        const id = this.$route.params.questionId; // Maps to :questionId in the route path

        const storeQuestion = this.$store.state.questions.find(q => q.id === id);

        // Redirect to NotFound if the question ID is not found
        if (!storeQuestion) {
            this.$router.push({name: 'NotFound'});
        } else {
            // Object.assign lets us effectively clone an object so it's not tied to
            // the existing one in the store. This way we don't actually save until
            // the user clicks save
            this.question = Object.assign({}, storeQuestion);
        }
    },
}
</script>

<style scoped>
    #editForm {
        margin-top: 2rem;
    }
</style>