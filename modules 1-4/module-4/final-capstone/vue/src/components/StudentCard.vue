<template>
    <article>
        <div class="card border-primary">
            <h5 class="card-header d-flex justify-content-between">
                {{student.firstName}} {{student.lastName}} 
                <span class="badge badge-primary">({{student.gpa}} GPA)</span>
            </h5>
            <div class="card-body">
                <p class="card-text">{{student.notes}}</p>
            </div>
            <div class="card-footer">
                <p class="card-text" v-if="student.phone">Phone: {{student.phone}}</p>
                <p class="card-text" v-if="student.email">Email: {{student.email}}</p>
            </div>
        </div>
    </article>
</template>

<script>
export default {
    props: ['student']
}
</script>