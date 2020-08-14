<template>
    <article>
        <h1>Edit Student</h1>

        <div class="alert alert-info" role="alert">Enter information about the new student and click Create to continue</div>
        
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
            <button type="submit" class="btn btn-success">Save</button>
        </form>
        <busy-spinner v-else />

        <div class="alert alert-danger" role="alert" v-if="errorMessage">
            The student could not be saved: {{errorMessage}}
        </div>

    </article>
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
            student: null,
            errorMessage: ''
        }
    },
    methods: {
        saveStudent() {
            StudentService.update(this.student)
                .then(response => {
                    this.$store.commit('STUDENT_UPDATED', response.data);
                    this.$router.push({name: 'StudentDetails', params: {studentId: response.data.id}});
                })
                .catch(error => {
                    this.errorMessage = error.message;
                });
        }
    },
    created() {
        const id = this.$route.params.studentId;
        StudentService.getStudent(id)
            .then(response => {
                this.student = response.data;
            })
            .catch(error => this.errorMessage = error.message);
    }
    
}
</script>