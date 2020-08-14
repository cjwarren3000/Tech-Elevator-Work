<!-- Template defines the way the component renders on the web page -->
<template>
  <header>
    <a href="index.html">
      <img src="../assets/images/LogoGold.png" alt="Sally the Squirrel Logo" />
    </a>
    <nav>
      <a href="questions.html" class="active">Questions</a>
      <a href="askaquestion.html">Ask a Question</a>
      <a href="services.html">Services</a>
      <a href="about.html">About</a>
      <a href="contact.html">Contact</a>
    </nav>
  </header>
</template>

<!-- Script is the core data and logic associated with the component. It is required -->
<script>
export default {
  name: "AppHeader",
  data() {
    return {};
  }
};
</script>


<style scoped>
header {
  background-color: #3b3e42;
  color: #999999;
}

header {
  grid-area: navBar;
  text-align: center;
  border-bottom: 5px solid #ffcb48;
}

header > a {
  margin: 0;
  display: inline-block;
}

@media screen and (min-width: 707px) {
  header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    justify-items: stretch;
  }

  header > a {
    margin: 0.5rem 0 0 0.5rem;
    flex-grow: 0;
  }

  header nav {
    display: flex;
    justify-content: space-evenly;
    flex-grow: 1;
  }
}
</style>