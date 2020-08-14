<template>
    <div>
        <main>
            <section id="opening">
                <question-card v-bind:cardData="question" />
            </section>            
            <section id="editSection" v-if="showEdit">
                <p>
                    <router-link :to="{name: 'EditQuestion', 
                                       params: {questionId: question.id}}">
                        Edit this Question
                    </router-link>
                </p>
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
            showEdit: true,
            question: null
        }
    },
    computed: {
    },
    // Created is called when a component is created. It's a good place to load data.
    created() {
        console.log('Component created!');

        console.log('Parameters to this component are:', this.$route.params);

        const id = this.$route.params.questionId; // Maps to :questionId in the route path

        this.question = this.$store.state.questions.find(q => q.id === id);

        // Redirect to NotFound if the question ID is not found
        if (!this.question) {
            this.$router.push({name: 'NotFound'});
        }
    },
}
</script>