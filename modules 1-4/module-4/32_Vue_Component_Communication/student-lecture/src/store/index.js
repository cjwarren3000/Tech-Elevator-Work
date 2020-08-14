import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  // When strict is set to true, state can ONLY be mutated from the store. This should be true.
  strict: true,

  // State contains the global application state. Think of it as app-wide data
  state: {
    filter: {
      searchText: "",
      difficulty: ""
    },    
    isAddQuestionVisible: false,
    questions: [
      {
        id: 1,
        question: "What is the Sealed Keyword?",
        answer: "The sealed keyword prevents a class from being inherited.",
        difficulty: 2,
        isAnswerVisible: false,
        isCorrect: null,
      },
      {
        id: 2,
        question: "What is the Virtual Keyword?",
        answer: "The virtual keyword allows a method to be overridden in an inheriting class.",
        difficulty: 1,
        isAnswerVisible: false,
        isCorrect: null,
      },
      {
        id: 3,
        question: "What do you need to do to override a method in C#?",
        answer: "Mark the method as virtual, inherit from the class, and use the overrides keyword to override it in the inheriting class.",
        difficulty: 2,
        isAnswerVisible: false,
        isCorrect: null,
      },
      {
        id: 4,
        question: "What are the major unit test frameworks for .NET?",
        answer: "MSTest, XUnit, and NUnit",
        difficulty: 2,
        isAnswerVisible: false,
        isCorrect: null,
      },
      {
        id: 5,
        question: "How does a Unit Test Work?",
        answer: "The test runner discovers and calls each test method. If an exception occurs and is unhandled, the test fails. Asserts throw exceptions when they fail.",
        difficulty: 3,
        isAnswerVisible: false,
        isCorrect: null,
      },
      {
        id: 6,
        question: "What is the purpose of semantic HTML?",
        answer: "Semantic HTML helps tools understand the structure of a web page",
        difficulty: 1,
        isAnswerVisible: false,
        isCorrect: null,
      }
    ],
  },

  // Mutations are used to make discrete changes to state from a central place
  mutations: {
    // Search-related mutations
    SET_SEARCH(state, search) {
      state.filter = search;
    },

    // Question List State
    SHOW_ADD_QUESTION(state) {
      state.isAddQuestionVisible = true;
    },
    HIDE_ADD_QUESTION(state) {
      state.isAddQuestionVisible = false;
    },
    
    // Add a method to add a question to the list of questions
    ADD_QUESTION(state, payload) {
      state.questions.push(payload);
    },

    // Add methods for Grading questions and setting answer visibility
    TOGGLE_ANSWER_VISIBILITY(state, id) {
      const question = state.questions.find(q => q.id === id);
      question.isAnswerVisible = !question.isAnswerVisible;
    },
    GRADE_QUESTION(state, payload) {
      const question = state.questions.find(q => q.id === payload.id);
      question.isCorrect = payload.isCorrect;
      question.isAnswerVisible = true;
    },
  },

  // The items below are not covered by TE's curriculum, but recommended for larger apps

  // Getters provide encapsulation around application state by providing computed properties
  getters: {
  },
  // Actions typically commit one or more mutation and can be used to coordinate complex operations
  actions: {
  },
  // Modules are used to group together groups of complex state
  modules: {
  }
})
