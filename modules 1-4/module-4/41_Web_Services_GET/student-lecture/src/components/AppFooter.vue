<!-- Template defines the way the component renders on the web page -->
<template>
  <footer>
    <nav>
      <!-- Add link to Home -->
      <router-link v-bind:to="{name: 'Home'}" exact>Home</router-link>
      <!-- Add link to Questions -->
      <router-link v-bind:to="{name: 'Questions'}" exact>Question</router-link>
      <!-- Add link to Ask a Question -->
      <router-link v-bind:to="{name: 'AskQuestion'}">Ask a Question</router-link>
      <!-- Add link to Services -->
      <router-link v-bind:to="{name: 'Services'}">Services</router-link>
      <!-- Add link to About -->
      <router-link v-bind:to="{name: 'About'}">About</router-link>
      <!-- Add link to Contact -->
      <router-link v-bind:to="{name: 'Contact'}">Contact</router-link>
    </nav>
    <!-- Bind these to data -->
    <small>Copyright &copy; {{year}}, {{companyName}}</small>
  </footer>
</template>

<!-- Script is the core data and logic associated with the component. It is required -->
<script>
export default {
  // Name is optional, but usually a good idea. This shows up in dev tools
  name: "AppFooter",
  // Data contains information specific to our application
  data() {
    return {
      // Add the company here
      companyName: 'Tech Elevator, LLC'
    };
  },
  // Computed contains the Vue.js equivalent of getters that rely on other data to compute results.
  // Think of computed as computed or auto-calculated properties that are bound to from the template.
  computed: {
    /**
     * Calculates the current year and returns it as a number.
     * @returns {number} the current year in numerical format. E.G. 1980.
     */
    year() {
      const d = new Date();
      return d.getFullYear();
    }
  }
};
</script>

<!-- Style is optional and can be completely omitted if custom styles are not needed -->
<style scoped>
footer {
  background-color: #3b3e42;
  color: #999999;
}

footer {
  border-top: 5px solid #ffcb48;
  text-align: center;
  padding: 1rem;
  grid-area: footer;
}

footer nav {
  margin-bottom: 1rem;
}

@media screen and (min-width: 707px) {
  footer nav {
    display: flex;
    align-items: center;
    justify-content: space-around;
  }
}
</style>