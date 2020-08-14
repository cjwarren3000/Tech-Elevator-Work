<template>
  <div class="jumbotron">
    <h1>Home</h1>
    <p class="lead">Welcome to the Student Portal</p>
    <router-link v-bind:to="{name: 'Students'}" class="btn btn-primary btn-lg">
      Students
    </router-link>
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>

<style scoped>


</style>