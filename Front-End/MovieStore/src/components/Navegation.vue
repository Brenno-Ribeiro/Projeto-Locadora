<template>
    <nav class="nav">
       <div class="nav-flex">
            <router-link to="/" >
                <img class="logo" src="@/assets/Logo.png" alt="logo-movie-store">
            </router-link>
            <router-link to="/register" class="btn-add-movie">
                <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
                    <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                </svg>
                New Movie
            </router-link>

            <router-link to="/register" class="btn-add-movie-bottom">
                <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
                    <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                </svg>
            </router-link>
       </div>
    </nav>
</template>




<script lang="ts">

    import { Options, Vue } from "vue-class-component";
    import Api from '@/services/configuration'

    @Options({
        name:'Navegation',
    })

    export default class Navegation extends Vue{}

</script>


<style lang="scss" scoped>

    .nav-flex{
        display: flex;
    }

    .nav{
        background: #282d41;
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
        position: fixed;
        top: 0;
        width: 100%;
        padding: .5em;
        z-index: 4;
    }

    .logo{
        width: 40px;
    }


</style>