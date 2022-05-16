<template>
  <header>
    <navegation></navegation>
  </header>
  <main class="container">
     <router-view/>
  </main>
</template>


<script lang="ts">

    import { Options , Vue } from "vue-class-component";
    import Navegation from "@/components/Navegation.vue"

    @Options({
      name: 'App',
      components:{
        Navegation
      }

    })

    export default class App extends Vue{}
</script>


<style lang="scss" scoped>
    main{
      margin-top: 6em;
    }

</style>
