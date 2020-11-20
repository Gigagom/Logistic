<template>
    <div>
        Авторизация
        <form>
            <label for="login" >Логин</label>
            <div>
                <input id="login" type="email" v-model="item.name" required autofocus>
            </div>
            <div>
                <label for="password" >Пароль</label>
                <div>
                <input id="password" type="password" v-model="item.password" required>
                </div>
            </div>
            <div>
                <button type="submit" v-on:click.prevent="handleSubmit">Войти</button>
            </div>
        </form>
    </div>
</template>

<script>
  export default {
    data(){
      return {
        item:{name : "", password : ""}      
      }
    },
    methods : {
      async handleSubmit(){
        if (this.item.password.length > 0) {
            await fetch('https://localhost:5001/api/token/', 
            { 
                method: 'POST',
                body: JSON.stringify(this.item),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .then(json => {
                if(json.access_token){
                    localStorage.setItem('jwt',json.access_token)
                    if (localStorage.getItem('jwt') !== 'null' || localStorage.getItem('jwt') !== ''){
                        this.$router.push('/')
                    }
                }
                else{
                    alert("Неверные данные")
                }   
            })
            .catch(function (error) {
                console.error(error.response);
            });
        }
      }
    }
  }
</script>