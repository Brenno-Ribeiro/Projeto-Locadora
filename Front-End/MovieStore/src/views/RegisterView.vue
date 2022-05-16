<template>
  <div class="registrer">
      <h1>Add New Movie</h1>
      <Form/>
  </div>
</template>

<script lang="ts">

   import { Options, Vue } from "vue-class-component";
   import Form from '@/components/Form.vue'

    @Options({
        name:'RegisterView',
        components:{
          Form
        }
    })

    export default class RegisterView extends Vue{}

</script>


<style lang="scss" scoped>

    h1{
      color: white
    }
</style>
