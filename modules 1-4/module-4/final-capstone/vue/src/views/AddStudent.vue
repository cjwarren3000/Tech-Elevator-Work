<template>
    <div>
        <h1>Add Student</h1>

        <div class="alert alert-info" role="alert">Enter information about the new student and click Create to continue</div>
        
        <div class="alert alert-danger" role="alert" v-if="errorMessage">{{errorMessage}}</div>

        <form @submit.prevent="saveStudent()" v-if="student">
            <div class="form-group">
                <label for="firstName">First Name</label>
                <input type="text" class="form-control" id="firstName" 
                       v-model="student.firstName"
                       autocomplete="given-name"
                       required>
            </div>
            <div class="form-group">
                <label for="lastName">Last Name</label>
                <input type="text" class="form-control" id="lastName" 
                       v-model="student.lastName"
                       autocomplete="family-name"
                       required>
            </div>
            <div class="form-group">
                <label for="email">E-Mail</label>
                <input type="email" class="form-control" id="email" 
                       v-model="student.email"
                       autocomplete="email">
            </div>
            <div class="form-group">
                <label for="phone">Phone</label>
                <input type="tel" class="form-control" id="phone" 
                       v-model="student.phone"
                       autocomplete="tel">
            </div>
            <div class="form-group">
                <label for="gpa">GPA</label>
                <input type="number" class="form-control" id="gpa" 
                       min="1" max="4" step="0.01"
                       v-model="student.gpa"
                       required>
            </div>
            <div class="form-group">
                <label for="notes">Notes</label>
                <textarea class="form-control" 
                          id="notes" 
                          v-model="student.notes"
                          rows="3" />
            </div>
            <button type="submit" class="btn btn-success">Create</button>
        </form>
        <busy-spinner v-else />
    </div>
</template>

<script>
import StudentService from '@/services/StudentService.js';
import BusySpinner from '@/components/BusySpinner.vue';

export default {
    components: {
        BusySpinner
    },
    data() {
        return {
            errorMessage: '',
            student: {
                firstName: '',
                lastName: '',
                email: '',
                gpa: 3.00,
                phone: '',
                notes: ''
            }
        }
    },
    methods: {
        saveStudent() {
            StudentService.create(this.student)
                .then(response => {
                    const newStudent = response.data;
                    this.$store.commit('STUDENT_ADDED', newStudent);
                    this.$router.push({name: 'StudentDetails', params: {studentId: newStudent.id}})
                })
                .catch(error => {
                    this.errorMessage = error.message;
                });
        }
    }
}
</script>

<style>

</style>