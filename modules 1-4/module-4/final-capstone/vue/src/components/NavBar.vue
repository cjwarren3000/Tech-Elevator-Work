<template>
<nav id="nav" class="nav nav-pills">
    <router-link 
        class="nav-link nav-item" 
        exact-active-class="active"
        v-bind:to="{ name: 'home' }">
    <i class="fas fa-home"></i> <!-- This is a font awesome icon -->
    Home 
    </router-link>
    <router-link
        class="nav-link nav-item"
        exact-active-class="active"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token">Register</router-link>
    <router-link
        class="nav-link nav-item"
        exact-active-class="active"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token">Login</router-link>
    <router-link
        class="nav-link nav-item"
        exact-active-class="active"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token">Logout</router-link>
</nav>
</template>