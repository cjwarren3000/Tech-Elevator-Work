import axios from 'axios';

// Create our Axios instance used to communicate with the server and set the baseURL
const http = axios.create({
    baseURL: 'https://sallythesquirrelservice.azurewebsites.net'
});

export default {
    /**
     * Gets a promise containing all questions from the server
     * @returns {Promise} a promise containing all question data
     */
    getQuestions() {
        return http.get('/questions');
    },

    /**
     * Deletes a question from the server because it's a bad question
     * @param {Object} question the question to delete
     * @returns {Promise} a promise representing the request to delete the question
     */
    deleteQuestion(question) {
        return http.delete('/questions/' + question.id);
    },

    /**
     * Creates a new question on the server
     * @param {Object} question the question to add
     * @returns {Promise} a promise representing the request to add a new question
     */
    createQuestion(question) {
        return http.post('/questions', question);
    },

    /**
     * Updates an existing question with new values
     * @param {Object} question the question to update
     * @returns {Promise} a promise representing the request to update a question
     */
    updateQuestion(question) {
        return http.put('/questions/' + question.id, question);
    },
}