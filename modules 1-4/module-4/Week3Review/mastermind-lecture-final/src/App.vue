<template>
  <div id="app">
    <h1 v-bind:id="someId">Mastermind</h1>
    <app-header headerMessage="This is how I pass a prop to a component" 
                url="https://www.techelevator.com" />
                <!--
    <app-header v-bind:headerMessage="someComputedProp" 
                v-bind:url="someUrl" />

    <div>
      <input type="checkbox" id="isDisabledCheckbox" v-model="isDisabled" />
      <label for="isDisabledCheckbox">Is Disabled</label>
    </div>

    <h2>Doggos</h2>
    <ul>
      <div v-for="someDog in dogs" v-bind:key="someDog">
        <input type="checkbox" v-bind:value="someDog" v-model="favoriteDogs" 
               v-on:change="doggoChecked($event)" >
        <label>{{someDog}}</label>
      </div>
    </ul>

    <button v-bind:disabled="isDisabled">Hello</button>
    -->

    <history-list />
    <p v-if="message" class="message">{{ message }}</p>
    <p v-else>This shows up if message is falsy</p>

    <div v-if="!isGameOver">
      <h2>Your Guess</h2>
      <enter-guess />
      <p>You have taken {{turnsTaken}} move(s)</p>
    </div>
    <div class="restart">
      <a @click="reset()" href="#">Restart Game</a>
    </div>
  </div>
</template>

<script>
import HistoryList from './components/HistoryList.vue'
import EnterGuess from './components/EnterGuess.vue'
import AppHeader from './components/AppHeader.vue'

export default {
  name: 'Mastermind',

  components: {
    HistoryList,
    EnterGuess,
    AppHeader
  },

  data() {
    return {
      someData: 'This is data defined on a parent component',
      someUrl: 'https://johnfulton.org',
      someId: 1,
      isDisabled: false,
      dogs: ['Walter', 'Charlie', 'Honey', 'Jester'],
      favoriteDogs: [],
    }
  },

  methods: {
    reset() {
      this.$store.commit("RESTART_GAME");
    },
    doggoChecked(event) {
      console.log('Checkbox was checked. It is now set to checked = ' + event.target.checked, event);
    }
  },

  computed: {
    isGameOver() {
      return this.$store.state.isGameOver;
    },
    message() {
      return this.$store.state.message;
    },
    turnsTaken() {
      return 10 - this.$store.state.movesLeft;
    },
    someComputedProp() {
      return 'Hi Computed';
    },
  },

  // Created is a special method that fires when the component initially loads
  created() {
    this.$store.commit("RESTART_GAME");
  },
}
</script>

<style lang="scss">
$FOREGROUND_COLOR: #2c3e50;
$DEFAULT_MARGIN: 2rem;

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;

  color: $FOREGROUND_COLOR;
  margin-top: $DEFAULT_MARGIN;
  margin-left: $DEFAULT_MARGIN;
}
.message {
  font-weight: bold;
  margin-top: $DEFAULT_MARGIN;
  margin-bottom: $DEFAULT_MARGIN;
}
.restart {
  margin-top: $DEFAULT_MARGIN;
}
</style>
