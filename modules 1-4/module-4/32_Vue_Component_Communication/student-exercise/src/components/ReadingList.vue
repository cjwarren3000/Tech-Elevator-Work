<template>
  <div class="book-container">
      <reading-list v-bind:key="book.title" v-for="book in ReadingList">
        <book-card v-bind="title" />
      </reading-list>
      
  </div>
</template>

<script>
import ReadingList from '../store/index';
import BookCard from '../components/BookCard'

export default {
    name: 'reading-list',
    components: {
      ReadingList,
      BookCard
    }
}
</script>

<style>
.book-container {
    display:flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
}
</style>