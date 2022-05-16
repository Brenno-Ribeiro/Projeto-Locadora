<template>
    <div class="modal">

        <div>
            <h3>{{movie.title}}</h3>
            <p>Diretor: {{movie.nameDirector}} {{movie.lastNameDirector}}</p>
        </div>

        <div class="modal-movie">

            <div class="modal-movie-img">
                <img :src="movie.imageLink">
            </div>
        </div>
        
        <div class="btn-actions">

            <button @click="OpenModalUpdate()" class="btn btn-update" >
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                </svg>
                Update
            </button>

            <button  @click="OpenModalDelete(movie.id)" class="btn btn-delete">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                    <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                </svg>
                Delete
            </button>

        </div>

    </div>

     <Transition>
        <div v-show="ShowModalUpdate" class="Modal-Update">
            
            <div class="update">
                <h3>Atualização</h3>
                <form @submit="Update($event, movie)">

                    <div>
                        <label>Titulo</label>
                        <input type="text" v-model="movieUpdate.title" required>
                    </div>

                    <div>
                        <label>Ano</label>
                        <input type="number" v-model="movieUpdate.releaseYear" required min="1885">
                    </div>

                    <div>
                        <label>Duração</label>
                        <input type="text" v-model="movieUpdate.duration" required>
                    </div>

                    <div>
                        <label>Genero</label>
                        <input type="text" v-model="movieUpdate.gender" required>
                    </div>

                    <div>
                        <label>Faixa etária</label>
                        <select v-model="movie.ageGroup" required>
                            <option value="" key="">Selecione a faixa etária</option>
                            <option value="L">L</option>
                            <option value="10">10</option>
                            <option value="12">12</option>
                            <option value="14">14</option>
                            <option value="16">16</option>
                            <option value="18">18</option>
                        </select>
                    </div>
    
                    <div class="btn-actions">
                        <button  type="submit" class="btn btn-update">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-check-circle" viewBox="0 0 16 16">
                                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                                <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
                            </svg>
                            Update
                        </button>
                         <button type="button" @click="Cancel()" class="btn btn-cancel">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
                                <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
                            </svg>
                            Cancelar
                        </button>
                    </div>
                </form>
            </div>
        </div>
     </Transition>
   

    <Transition>
        <div v-show="ShowModalDelete" class="Modal-Delete">
            <div class="delete">
                <h4>Tem certeza que deseja deletar esse filme?</h4>
                <div class="delete-options">
                    <button  @click="Delete(movie.id)" class="btn btn-delete">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                            <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                        </svg>
                        Delete
                    </button>
                    <button  @click="Cancel()" class="btn btn-cancel">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
                            <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
                        </svg>
                        Cancelar
                    </button>
                </div>
            </div>
        </div>
    </Transition>



    <Transition>
        <div v-show="UpdateIsDone">
            <div class="overlayer">
                <div class="screen-success">
                    <div>
                        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="#23ce70" class="bi bi-check-circle" viewBox="0 0 16 16">
                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                            <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
                        </svg>
                    </div>
                    <div>
                        <p>Filme atualizado com sucesso</p>
                    </div>
                </div>      
            </div>
        </div>
    </Transition>


     <Transition>
        <div v-show="DeleteIsDone">
            <div class="overlayer">
                <div class="screen-success">
                    <div>
                        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="#23ce70" class="bi bi-check-circle" viewBox="0 0 16 16">
                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                            <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
                        </svg>
                    </div>
                    <div>
                        <p>Filme deletado com sucesso</p>
                    </div>
                </div>
            </div>
        </div>
    </Transition>
    

</template>


<script lang="ts">

  import { Options, Vue } from 'vue-class-component';
  import Api from '@/services/configuration'

  @Options({
    name: 'MovieModal',
    props:{
        movie: Object
    },
    data(){
        return{
            ShowModalUpdate: false,
            ShowModalDelete: false,
            
            DeleteIsDone: false,
            UpdateIsDone: false,

            movieUpdate:{
                title:"",
                releaseYear: 0,
                duration: "",
                gender:"",
                ageGroup:""
            },
        }  
    },
    methods:{

        OpenModalUpdate(){
            this.movieUpdate = this.movie
            this.ShowModalUpdate = !this.ShowModalUpdate
        },

        OpenModalDelete(){
            this.ShowModalDelete = !this.ShowModalDelete
        },


        Update(e: Event, movie: any){
            e.preventDefault()
            Api.put(`movie/${movie.id}`,movie,{
                method: "Put"
            }).then(response => {
                 this.UpdateIsDone = true
    
                setTimeout(() =>{
                  this.UpdateIsDone = false
                },2*20000)

                setTimeout(() =>{
                  this.$router.go()
                },3*1000)

            }).catch(error =>{
                console.log(error)
            });
        },

        Delete(id: string){  

            this.ShowModalDelete = false  

           Api.delete(`movie/${id}`,{method: 'delete'}).then(response => {

                this.DeleteIsDone = true
    
                setTimeout(() =>{
                  this.DeleteIsDone = false
                },2*20000)

                setTimeout(() =>{
                  this.$router.go()
                },3*1000)
                        
            }).catch(error =>{
                console.log(error)
            });

            
        },

        Cancel(){
            this.ShowModalDelete = false
            this.ShowModalUpdate = false    
        },

    }
  })

  export default class MovieModal extends Vue {}
  
</script>








<style lang="scss" scoped>
    .modal{
        background: rgb(37, 36, 36);
        width: 500px;
        padding: 2em;
        border-radius: 2em;
    }

    button{
        display: block;
        margin: 0px 1em, 5em 4em;
        font-size: 14px;
    }
    button svg{ 
        margin-right: 1em;
    }
    .btn-actions{
        display: flex;
        justify-content: center;
        align-items: center;
        margin-top: 2em;
    }

     label{
        display:block;
        color: white;
        font-weight: bold;
        text-transform: uppercase;
        font-size: 12px;
    }

    input{
        display:block;
        width: 100%;
        background: transparent;
        border: 1px solid gray;
        padding: .5em;
        border-radius: .5em;
        color:rgb(90,255,218);
    }

    form div{
        margin-bottom: .6em;
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
        padding: .5em;
        border-radius: .5em;
        color:rgb(90,255,218);
    }

    option{
         background-color: #292D3E;
    }

    .modal h3{
        text-align: center;
        color: white;
    }
    .modal p{
        text-align: center;
        color: rgb(131, 131, 131);
        font-style: italic;
        margin-top: .3em;
    }


    .modal-movie-img img{
        width: 100px;
        height: 150px;
        border: 1px solid white;
    }

    .modal-movie-info{
        width: 100%;
        margin-top: 2em;
        text-align: center;
    }

    .modal-movie{
        margin-top: 1.3em;
        margin-right: 2em;
        display: flex;
        flex-direction: center;
        justify-content: center;
        align-items: center;
        width: 100%;
    }


    .btn{
        padding: .8em 2em;
        border:none;
        border-radius: 1em;
        background: transparent;
        text-align: center;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-right: 1em;
    }

    .btn-update{
        border: 1px solid #32A540;
        color: #32A540;
        transition: all .5s cubic-bezier(0.165, 0.84, 0.44, 1);
    }

    .btn-update:hover{
        color: white;
        background: #32A540;
         cursor: pointer
    }

    .btn-delete{
        border: 1px solid #E4322E;
        color: #E4322E;
        transition: all .5s cubic-bezier(0.165, 0.84, 0.44, 1);
    }

    .btn-delete:hover{
        cursor: pointer;
        color: white;
        background: #E4322E;
    }

    .btn-cancel{
        border: 1px solid #2e9be4;
        color: #2e9be4;
        transition: all .5s cubic-bezier(0.165, 0.84, 0.44, 1);
    }

    .btn-cancel:hover{
        cursor: pointer;
        color: white;
        background: #2e9be4;
    }

    .btn-update{
        border: 1px solid #23ce70;
        color: #23ce70;
        transition: all .5s cubic-bezier(0.165, 0.84, 0.44, 1);
    }

    .btn-update:hover{
        cursor: pointer;
        color: white;
        background: #23ce70;
    }

    .delete-options{
        display: flex;
        flex-wrap: wrap;
        margin-top: 2em;
        justify-content: center;
        align-items: center;
    }

     .delete-options button{
         margin-bottom: 2em;
     }

    .Modal-Delete{
        width: 100%;
        height: 100%;
        position: fixed;
        z-index: 6;
        background: rgba(0, 0, 0, 0.911);
        display: flex;
        justify-content: center;
        align-items: center; 
    }
    .Modal-Update{
        width: 100%;
        height: 100%;
        position: fixed;
        z-index: 6;
        background: rgba(0, 0, 0, 0.911);
        display: flex;
        justify-content: center;
        align-items: center; 
    }

    .update{
        background: rgb(27, 27, 27);
        padding: 5em;
        border-radius: 1em;
    }

    .delete{
        background: rgb(27, 27, 27);
        padding: 2em;
        border-radius: 1em;
    }

    .delete h4{
        color: white;
        text-align: center;
    }

  


</style>