<template>
    <div>
        <div class="alert alert-danger" role="alert" v-if="errorMessage">{{errorMessage}}</div>

        <div v-if="loaded || students.length > 0">
            <ul class="list-group" v-if="students.length">
                <router-link v-for="student of students" v-bind:key="student.id"
                    v-bind:to="{name: 'StudentDetails', params: {studentId: student.id}}"                
                    class="list-group-item list-group-action">
                    {{student.firstName}} {{student.lastName}}
                </router-link>
            </ul>
            <div class="alert alert-warning" role="alert" v-else>
                There are no students currently enrolled
            </div>
        </div>
        <busy-spinner v-else />        
    </div>
</template>

<script>
import StudentService from '@/services/StudentService.js';
import BusySpinner from '@/components/BusySpinner.vue';

export default {
    computed: {
        students() {
            return this.$store.state.students;
        }
    },
    components: {
        BusySpinner
    },
    data() {
        return {
            errorMessage: '',
            loaded: false
        }
    },
    created() {
        StudentService.getAllStudents()
            .then(response => {
                this.loaded = true;
                this.$store.commit('STUDENTS_LOADED', response.data);
            })
            .catch(error => {
                console.error('Oh snap. Could not load students!', error);
                this.errorMessage = 'There was a problem loading students. Make sure you have enough Diet Doctor Pepper.';
            });
    }

}
</script>