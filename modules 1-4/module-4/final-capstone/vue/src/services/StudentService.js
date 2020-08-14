import axios from 'axios';

export default {

    getAllStudents() {
        return axios.get('/students');
    },

    getStudent(id) {
        return axios.get('/students/' + id);
    },

    create(student) {
        return axios.post('/students', student);
    },

    update(student) {
        return axios.put('/students', student);
    },

    delete(student) {
        return axios.delete('/students/' + student.id);
    }
}