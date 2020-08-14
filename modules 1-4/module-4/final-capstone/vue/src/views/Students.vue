<template>
    <div>
        <div class="jumbotron">
            <h1>Students</h1>
            <p class="lead">Take a look at information on currently enrolled students below. Click on a student to navigate in to view their details.</p>
        </div>
        <students-list />
        <router-link class="btn btn-success" :to="{name: 'AddStudent'}">Add Student</router-link>
    </div>
</template>

<script>
import StudentsList from '@/components/StudentsList.vue';

export default {
    components: {
        StudentsList
    },
}
</script>

<style>

</style>