<template>
    <div>
        <aside>
            <img src="../assets/images/Contact.jpg" alt="A squirrel standing and staring attentively" />
            <cite><span>Photo by Alexey Savchenko on Unsplash</span></cite>
            <blockquote>
                What? We didn't have enough questions already? <cite>- Sally the Squirrel</cite>
            </blockquote>
        </aside>
        <main>
            <section id="opening">
                <h1>Ask a Question</h1>
                <p>At Sally's we realize we can't have every question ever asked, but we sure can try! If you find something
                    we missed, use this form to add a new entry so others can learn from your experience.</p>
                <p>Questions submitted will be reviewed in a timely manner. Or not. We don't know. I'm mostly just
                    interested in acorns. But still submit them!</p>
            </section>
            <section>
                <h2>Add Question</h2>
                <add-question-form />
            </section>
        </main>
    </div>
</template>

<script>
import AddQuestionForm from "../components/AddQuestionForm";

export default {
    components: {
        AddQuestionForm
    }
}
</script>