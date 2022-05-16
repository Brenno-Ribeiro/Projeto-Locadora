<template>
    

    <Transition name="bounce">
        <div v-show="overlayer" class="overlayer">
            <button @click="CloseModal()" class="btn-close-modal">
                <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="red" class="bi bi-x-circle-fill" viewBox="0 0 16 16">
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z"/>
                </svg>
            </button>
            <MovieModal :movie="movie"></MovieModal>
        </div>
    </Transition>
    
    <div class="row">
        <h1>Filmes</h1>
    </div>
    <div class="row">
       
        <div class="movies" v-for="(movie,id) in movies" :key="id">
            
            <button class="btn-action" @click="MoreInfo(movie)">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="#1abcc2" class="bi bi-grid-fill" viewBox="0 0 16 16">
                    <path d="M1 2.5A1.5 1.5 0 0 1 2.5 1h3A1.5 1.5 0 0 1 7 2.5v3A1.5 1.5 0 0 1 5.5 7h-3A1.5 1.5 0 0 1 1 5.5v-3zm8 0A1.5 1.5 0 0 1 10.5 1h3A1.5 1.5 0 0 1 15 2.5v3A1.5 1.5 0 0 1 13.5 7h-3A1.5 1.5 0 0 1 9 5.5v-3zm-8 8A1.5 1.5 0 0 1 2.5 9h3A1.5 1.5 0 0 1 7 10.5v3A1.5 1.5 0 0 1 5.5 15h-3A1.5 1.5 0 0 1 1 13.5v-3zm8 0A1.5 1.5 0 0 1 10.5 9h3a1.5 1.5 0 0 1 1.5 1.5v3a1.5 1.5 0 0 1-1.5 1.5h-3A1.5 1.5 0 0 1 9 13.5v-3z"/>
                </svg>
            </button>

            <div class="movie-img"> 

                <img :src="movie.imageLink" :alt="movie.title">

                <p class="movie-age-group livre" v-if="movie.ageGroup == 'L ' ">
                   {{movie.ageGroup}}
                </p>
                <p class="movie-age-group maior-10" v-if="movie.ageGroup == '10' ">
                   {{movie.ageGroup}}
                </p>
                <p class="movie-age-group maior-12" v-if="movie.ageGroup == '12' ">
                   {{movie.ageGroup}}
                </p>
                 <p class="movie-age-group maior-14" v-if="movie.ageGroup == '14' ">
                   {{movie.ageGroup}}
                </p>
                <p class="movie-age-group maior-16" v-if="movie.ageGroup == '16' ">
                   {{movie.ageGroup}}
                </p>
                <p class="movie-age-group maior-18" v-if="movie.ageGroup == '18' ">
                   {{movie.ageGroup}}
                </p>

            </div>

            <div class="movie-information">
                <p>{{movie.nameDirector}} {{movie.lastNameDirector}}</p>
                <p class="releaseYear">{{movie.releaseYear}}</p>
            </div>

            
            <div class="movie-title">
                <p>{{movie.title}}</p>
            </div>
         
        </div>

       
        <div v-show="ShowNullMovie" class="screen-null-movie">
            <div>
                <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-film" viewBox="0 0 16 16">
                    <path d="M0 1a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v14a1 1 0 0 1-1 1H1a1 1 0 0 1-1-1V1zm4 0v6h8V1H4zm8 8H4v6h8V9zM1 1v2h2V1H1zm2 3H1v2h2V4zM1 7v2h2V7H1zm2 3H1v2h2v-2zm-2 3v2h2v-2H1zM15 1h-2v2h2V1zm-2 3v2h2V4h-2zm2 3h-2v2h2V7zm-2 3v2h2v-2h-2zm2 3h-2v2h2v-2z"/>
                </svg>
            </div>
            <div>
                <p>Você ainda não tem filmes na sua base</p>
            </div>
        </div>
   
    </div>


    <Transition>
        <div v-show="loading" class="loading-screen">
            <div class="animation-jump">
                <img src="@/assets/Logo.png" alt="" width="30" height="30"/>
            </div>
        </div>
    </Transition>
    


</template>


<script lang="ts">

    import { Options, Vue } from "vue-class-component";
    import Api from '@/services/configuration'
    import MovieModal from '@/components/MovieModal.vue'

    @Options({
        name:'Movie',
        data(){
            return{
                movies: [],
                showModalAction: true,
                overlayer: false,
                movie:{},
                ShowNullMovie: false,
                loading: true
            }
        },
        components:{
            MovieModal
        },
        created(){
            this.loading = true
            Api.get('movie').then(response => {
                this.movies = response.data.movies    
            })
            .catch(error =>{
                this.ShowNullMovie = true
            })
            .finally(() =>{
                 this.loading = false
            })
        },
        methods:{

            MoreInfo(movie: object){
                this.overlayer = !this.overlayer
                this.movie = movie
            },

            CloseModal(){
                this.overlayer = false
            }
        }
    })

    export default class Movie extends Vue{}

</script>





<style lang="scss" scoped>

    .movies{
        width: 185px;
        height: 400px;
        margin-bottom: 3em;
        margin-right: 2.5em;
        transition: all .4s;
    }

    .movie-img{
        width: 100%;
        height: 270px;
        position: relative;
        background-color: black;
    }

    .movie-img img{
        width: 100%;
        transition: all .4s;
    }

    .movie-img img:hover{
        opacity: 0.7;
    }

    .movie-information{
        display: flex;
        align-items: center;
        justify-content: space-between;
        color: rgb(167, 167, 167);
        margin-top: .2em;
    }

    .movie-information p{
        margin-top: .7em
    }
    
    .movies:hover{
        transform: scale(1.1,1.1);
    }

    .movie-title{
        color: rgb(238, 238, 238);
        font-weight: bold;
        font-size: 16px;
        text-align: left;
        margin-top: .3em;
    }

    .releaseYear{
        color: white;
        background: #292D3E;
        padding: .2em;
        border-radius: .2em;
        font-weight: bold;
        font-size: 14px;
    }

    .btn-action{
        background: rgb(255, 255, 255);
        top:  23px;
        left: -20px;
        border: none;
        position: relative;
        display: inline-block;
        border-radius: 100%;
        padding: 1em;
        transition: all .5s;
        z-index: 2;
        transform: scale(.8,.8);
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
    }

    .btn-action:hover{
        transform: scale(1.2,1.2);
        cursor: pointer;
    }

    .movie-age-group{
        width: 50px;
        height: 50px;
        position: absolute;
        bottom: 4px;
        left: 12px;
        border-radius: .2em;
        color:white;
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 20px;
        font-weight: bold;
        border: 2px solid white;
    }

    .btn-close-modal{
        position: absolute;
        top: 70px;
        display: block;
        border: none;
        background: transparent;
        transition: all .6s;
        
    }

    .btn-close-modal:hover{
        cursor: pointer;
        transform: scale(1.7,1.7);
     }
    

    .livre{
        background-color: #32A540;
    }

    .maior-10{
        background-color: #5BA0BD;
    }

    .maior-12{
         background-color: #FAB02B;
    }

    .maior-14{
         background-color: #EF762D;
    }
    .maior-16{
         background-color: #E4322E;
    }

    .maior-18{
        background-color: black;
    }

    .action{
        background: red;
        position: absolute;
        left: 7%;
        top: 30%;
        padding: 3em 5em;
    }


    .screen-null-movie{
        background: #292D3E;
        padding: 2em;
        color: white;
        font-size: 18px;
        text-align: center;
        border-radius: 1em;
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
    }

    .screen-null-movie div{
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        margin-top: 2em;
    }


.bounce-enter-active {
  animation: bounce-in 0.5s;
}
.bounce-leave-active {
  animation: bounce-in 0.5s reverse;
}

@keyframes bounce-in {
  0% {
    transform: scale(0);
  }
  50% {
    transform: scale(1.25);
  }
  100% {
    transform: scale(1);
  }
}

   

</style>