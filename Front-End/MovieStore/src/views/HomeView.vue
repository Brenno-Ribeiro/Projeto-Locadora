<template>
    <div class="dashboard">
      <movie></movie>
    </div>
</template>


<script lang="ts">

  import Movie from '@/components/Movie.vue';
  import { Options, Vue } from 'vue-class-component';

  @Options({
    name: 'DashboardView',
    components: {
      Movie
    }
  })
  export default class DashboardView extends Vue {}
  
</script>

<style lang="scss" scoped>

</style>