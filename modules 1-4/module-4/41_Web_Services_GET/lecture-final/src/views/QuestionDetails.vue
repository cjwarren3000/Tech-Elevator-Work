<template>
    <div>
        <main>
            <section id="opening">
                <question-card v-bind:cardData="question" />
            </section>            
            <section id="editSection">
                <p>
                    <router-link :to="{name: 'EditQuestion', 
                                       params: {questionId: question.id}}">
                        Edit this Question
                    </router-link>
                </p>
                <p>
                    <a href="#" v-on:click.prevent="deleteQuestion()">Delete</a>
                </p>
            </section>
        </main>
    </div>
</template>

<script>
import QuestionCard from '../components/QuestionCard.vue';
import QuestionService from '../services/QuestionService.js';

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
        deleteQuestion() {
            const confirmed = confirm('Are you sure you want to delete this question? This cannot be undone');

            if (confirmed) {
                // Call out to our web service and have it make the delete
                QuestionService.deleteQuestion(this.question)
                    .then(response => {
                        this.$store.commit('QUESTION_DELETED', this.question);
                        this.$router.push({name: 'Questions'});

                        console.log('Deleted question successfully', response);
                    })
                    .catch(error => {
                        // TODO: Not alert
                        alert('Could not delete the question: ' + error.message);
                    });
            }
        }
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