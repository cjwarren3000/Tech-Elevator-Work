<template>
    <div>
        <h2>Questions</h2>
        <p>Use the form below to search questions. Hover over a question to reveal the answer.</p>
        <div class="form-group">
            <div>
                <label for="search">Search</label>
                <input type="search" id="search" 
                       v-on:change="filterChanged()"
                       v-model.lazy.trim="filter.searchText"
                       placeholder="Search questions or tags" />
            </div>
        </div>
        <div class="form-group">
            <label for="difficulty">Difficulty</label>
            <select id="difficulty"
                    v-on:change="filterChanged()"
                    v-model.number="filter.difficulty">
                <option value>Show All</option>
                <option value="1">Easy</option>
                <option value="2">Medium</option>
                <option value="3">Hard</option>
            </select>
        </div>
        <!--<input type="button" value="Search" v-on:click="filterChanged()">-->
    </div>
</template>

<script>
export default {
    name: "QuestionSearch",
    methods: {
        filterChanged() {
            console.log('Filter has changed', this.filter);

            this.$store.commit('SET_SEARCH', this.filter);
        }
    },
    data() {
        return {
            filter: {
                searchText: "",
                difficulty: ""
            },                
        };
    }
}
</script>

<style>
input[type="button"] {
  margin-left: 0.5rem;
}
</style>