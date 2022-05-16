<template>

  <div>
      <form @submit="SaveMovie($event)" class="form">

           <div class="flex-form">
                <div class="title">
                    <label for="title">Titulo</label>
                    <input type="text"  placeholder="Titulo do filme" id="title" required v-model="movie.title"/>
                </div>
           </div>

           <div class="flex-form">
                <div class="">
                    <label for="age">Ano</label>
                    <input type="number" placeholder="Ano de lançamento" id="age" required v-model="movie.releaseYear"/>
                </div>

                <div class="">
                    <label for="duration">Duração</label>
                    <input type="text" placeholder="Ex: 1h 55m" id="duration" required v-model="movie.duration"/>
                </div>

                <div class="">
                    <label for="gender">Genero</label>
                    <input type="text" placeholder="Genero" id="gender" required v-model="movie.gender"/>
                </div>

                <div class="">
                    <label for="ageGroup">Faixa etária</label>
                    <select v-model="movie.ageGroup" required id="ageGroup">
                        <option value="" key="">Selecione a faixa etária</option>
                        <option value="L">L</option>
                        <option value="10">10</option>
                        <option value="12">12</option>
                        <option value="14">14</option>
                        <option value="16">16</option>
                        <option value="18">18</option>
                    </select>
                </div>
           </div>

           <h3>Diretor</h3>
           <div class="director">
                <div class="flex-form">

                    <div class="director">
                        <label for="name-dicretor">Nome</label>
                        <input type="text" placeholder="Nome" id="name-dicretor" required v-model="movie.nameDirector"/>
                    </div>

                    <div class="director">
                        <label for="last-name-director">Sobrenome</label>
                        <input type="text" placeholder="Sobrenome" id="last-name-director" required v-model="movie.lastNameDirector"/>
                    </div>

                </div>

           </div>

           <div class="flex-form-img">
               <div class="">
                    <P>Faça o upload da capa do filme</P>
                        <label for="image" class="upload-image">
                        <input type="file" placeholder="Sobrenome" name="image" id="image"  size="60" accept="image/*" @change="Upload($event)" required/>
                        </label>
                    </div>   
                </div>
            <div class="btn-save">
                <input class="btn-submit" type="submit" value="Salvar"/>
            </div>

      </form>
  </div>

  <Transition>
        <div v-show="InsertIsDone">
            <div class="overlayer">
                <div class="screen-success">
                    <div>
                        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="#23ce70" class="bi bi-check-circle" viewBox="0 0 16 16">
                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                            <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
                        </svg>
                    </div>
                    <div>
                        <p>Filme Inserido com sucesso</p>
                    </div>
                </div>
            </div>
        </div>
    </Transition>

    
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

    @Options({
        name:"Form",
        data(){
            return {
               movie:{
                    title:"",
                    releaseYear: 0,
                    duration: "",
                    gender:"",
                    ageGroup:"",
                    nameDirector:"",
                    lastNameDirector:""
               },
               formData: new FormData(),
               image: null,
               movieId: null,
               InsertIsDone: false,
               loading: false
            }
        },
        methods:{  

            Upload(e: any){
               this.image = e.target.files[0]
               this.formData.append('image',this.image)
            },

            SaveMovie(e: Event){
                e.preventDefault()

                this.loading = true

                Api.post('movie',this.movie).then(response =>{
                    this.movieId = response.data.movieId 
                    Api.post(`Image/upload/${this.movieId}`,this.formData,{
                        method: 'post',
                        headers: {
                        'Content-Type': 'multipart/form-data'
                        }
                    }).then(() =>{
                        this.loading = false
                        this.InsertIsDone = true
                        setTimeout(() =>{
                        this.$router.push({name: 'home'})
                        },2*1000)
                    }).catch(error =>{
                         console.log(error)
                    }).finally(() =>{
                      
                    })
                })
                .catch(error => {
                    console.log(error)
                })
                

            }
        }
    })

    export default class Form extends Vue{}

</script>


<style lang="scss" scoped>

    h1{
      color: white
    }

    .form{
        margin-top: 2em;
        margin-bottom: 2em;
    }

    .flex-form{
        display: flex;
        align-items: center;
        justify-content: center;
        padding: 1.4em 2em 2em;
        flex-wrap: wrap;
        margin: 0;
        margin-bottom: 2em;
        background-color: #292D3E;
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
        border-radius: .6em;
        border: 1px solid white;
    }

    .flex-form div{
        margin-right: 2em;
        margin-bottom: .5em;
    }

    .flex-form-img{
        color: rgb(90,255,218);
        padding: 1.4em 2em 2em;
        flex-wrap: wrap;
        margin: 0;
        margin-bottom: 2em;
        background-color: #292D3E;
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
        border-radius: .6em;
        border: 1px solid white;
    }

    .flex-form-img p{
        text-align: center;
        font-weight: bold;
        margin-bottom: 1em;
    }


    .btn-save{
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .flex-form-img div{
        width: 100%;
    }

    h3{
        font-size: 20px
    }

    .flex-form .title{
        flex-grow: 1;
    }

    .director{
        display: flex;
        flex-direction: column;
        justify-content: center;
    }

    .director .flex-form{
        justify-content: center;
    }

    .director .flex-form div{
        width: 100%;
        margin-right: 2em;
    }

    .image:hover{
        background: red;
    }

    .btn-submit{
         background: rgb(90,255,218);
         border: none;
         padding: 1em;
         border-radius: 1em;
         color:white;
         font-weight: bold;
         transition: all .7s;
    }

    .btn-submit:hover{
        background: rgb(78, 180, 158);
        cursor: pointer;
    }
    

    label{
        display:block;
        color: white;
        font-weight: bold;
        text-transform: uppercase;
        font-size: 12px;
    }

    .upload-image{
        border: 2px dotted rgb(90,255,218);
        border-radius: 1em;
    }

    .upload-image:hover{
        
        border: 2px solid rgb(90,255,218);
    }

    input[type="file"]{
        width: 100%;
        padding: 4em;
        border: none;
        cursor: pointer;
    }
   
    input[type="submit"]{
        width: 50%;
        text-align: center;
    }

    input{
        width: 100%;
        background: transparent;
        border: 1px solid gray;
        padding: 1em;
        border-radius: .5em;
        color:rgb(90,255,218);
    }

    

    input:focus{
        background: #1B2634;
        border: 2px solid rgb(90,255,218);
        outline: 2px;
    }

    input:checked{
        background: #1B2634;
        border: 2px solid rgb(90,255,218);
        outline: 2px;
    }

    select{
        display:block;
        width: 100%;
        display:block;
        width: 100%;
        background: transparent;
        border: 1px solid gray;
        padding: 1em;
        border-radius: .5em;
        color:rgb(90,255,218);
    }

    option{
         background-color: #292D3E;
    }


.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}

</style>
