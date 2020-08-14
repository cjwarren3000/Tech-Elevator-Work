import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  // TODO: Add a route for Questions
  // TODO: Add a route for AskQuestion
  // TODO: Add a route for Services
  // TODO: Add a route for About
  // TODO: Add a route for Contact

  // TODO: Talk about case sensitivity on Name / Components

  // TODO: Add a wildcard route for NotFound
  // TODO: This will require a new view that displays the NotFoundMessage component

  // TODO: Add a route for question details and question edit
];

const router = new VueRouter({
  // TODO: Talk about Hash vs History
  base: process.env.BASE_URL,
  routes
});

export default router;