import Vue from 'vue'
import VueRouter from 'vue-router'

import Home from '../views/Home.vue'
import Questions from '../views/Questions.vue'
import AskQuestion from '../views/AskQuestion.vue'
import Services from '../views/Services.vue'
import About from '../views/About.vue'
import Contact from '../views/Contact.vue'
import NotFound from '../views/NotFound.vue'
import QuestionDetails from '../views/QuestionDetails.vue'
import QuestionEdit from '../views/QuestionEdit.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',        // The relative path of the page based on the URL (Required)
    name: 'Home',     // An internal name of the route
    component: Home   // What we actually display to the user (replaces router-view)
  },
  // Add a route for Questions
  {
    path: '/Questions',
    name: 'Questions',
    component: Questions
  },
  // Dynamic Routes let you take in variables in the form of route parameters
  // These can be accessed via this.$route.params.parameterName
  {
    path: '/Questions/:questionId', // This reads :questionId from the params passed in
    name: 'QuestionDetails',
    component: QuestionDetails,
  },
  {
    path: '/Questions/:questionId/Edit', // [HttpGet("Questions/{questionId}/Edit")]
    name: 'EditQuestion',
    component: QuestionEdit,
  },
  // Add a route for AskQuestion
  {
    path: '/Questions/Ask',
    name: 'AskQuestion',
    component: AskQuestion,
  },
  // Add a route for Services
  {
    path: '/Services',
    name: 'Services',
    component: Services,
  },
  // Add a route for About
  {
    path: '/About',
    name: 'About',
    component: About,
  },
  // Add a route for Contact
  {
    path: '/Contact',
    name: 'Contact',
    component: Contact,
  },

  // Add a wildcard route for NotFound
  // This will require a new view that displays the NotFoundMessage component
  {
    path: '*',
    name: 'NotFound',
    component: NotFound
  },

  // Talk about case sensitivity on Name / Components

  // TODO: Add a route for question details and question edit
];

const router = new VueRouter({
  // Talk about Hash vs History
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;