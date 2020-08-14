<template>
    <div>
        <div class="alert alert-danger" role="alert" v-if="errorMessage">
            {{errorMessage}}
        </div>

        <div v-if="student">
            <student-card :student="student" />

            <nav class="btn-group">            
                <router-link class="btn btn-primary" 
                            :to="{name: 'Students'}">
                    Back
                </router-link>
                <router-link class="btn btn-warning" 
                            :to="{name: 'EditStudent', params: {studentId: student.id}}">
                    Edit
                </router-link>
                <a class="btn btn-danger" href="#" @click.prevent="deleteStudent()">
                    Delete
                </a>
            </nav>
        </div>
        <busy-spinner v-else />
    </div>
</template>

<script>
import StudentCard from '@/components/StudentCard.vue';
import BusySpinner from '@/components/BusySpinner.vue';
import StudentService from '@/services/StudentService.js';

export default {
    components: {
        StudentCard,
        BusySpinner
    },
    data() {
        return {
            student: null,
            errorMessage: ''
        }
    },
    methods: {
        deleteStudent() {
            if (confirm('Are you sure you want to delete this student? This cannot be undone.')) {
                StudentService.delete(this.student)
                    .then(() => {
                        this.$router.push({name: 'Students'});
                    })
                    .catch(error => {
                        this.errorMessage = error.message;
                    });
            }
        }
    },
    created() {
        const id = this.$route.params.studentId;
        StudentService.getStudent(id)
            .then(response => {
                this.$store.commit('STUDENT_UPDATED', response.data);
                this.student = response.data;
            })
            .catch(error => this.errorMessage = error.message);
    }
}
</script>

<style>
    a.btn {
        margin-top: 1rem;
    }
</style>

