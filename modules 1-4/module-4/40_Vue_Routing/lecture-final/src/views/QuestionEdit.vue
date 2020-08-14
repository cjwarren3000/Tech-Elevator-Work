<template>
    <div>
        <main>
            <section id="opening">
                <h1>Edit Question</h1>
                <question-card v-bind:cardData="question" />
            </section>
            <section id="editForm">
                <form id="editQuestion" v-on:submit.prevent="addQuestion()">
                    <div class="form-group">
                    <label>Question</label>
                    <input type="text" required id="newQuestion" 
                           v-model.trim="question.question">
                    </div>
                    <div class="form-group">
                    <label>Answer</label>
                    <textarea id="newAnswer" 
                            v-model.trim.lazy="question.answer">
                    </textarea>
                    </div>
                    <div class="form-group">
                    <label for="newDifficulty">Difficulty</label>
                    <!-- Ideally this should be a select instead of an input, but this lets us demo modifiers -->
                    <input type="number" min="1" max="3" 
                            id="newDifficulty"
                            v-model.number="question.difficulty">
                    </div>
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
    computed: {
    },
    // Created is called when a component is created. It's a good place to load data.
    created() {
        const id = this.$route.params.questionId; // Maps to :questionId in the route path

        this.question = this.$store.state.questions.find(q => q.id === id);

        // Redirect to NotFound if the question ID is not found
        if (!this.question) {
            this.$router.push({name: 'NotFound'});
        }
    },
}
</script>

<style scoped>
    #editForm {
        margin-top: 2rem;
    }
</style>