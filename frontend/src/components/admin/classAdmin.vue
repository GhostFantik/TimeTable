<template>
    <div class="main">
        <div class="add">
            <input type="text" v-model="nameClass" placeholder="Название класса">
            <input type="text" v-model="amountClass" placeholder="Количество учеников">
            <button @click="AddClass">Добавить</button>
        </div>
    </div>
</template>
<script>
import axios from './../../http-common.js';

export default {
  data: function() {
      return {
          nameClass: '',
          amountClass: '',
      };
  },
  methods: {
      AddClass: function() {
          if(this.nameClass != '' && this.amountClass != ''){
              let classObj = {
                  Name: this.nameClass,
                  Amount: this.amountClass,
              }
              axios.HTTP.post('class', classObj)
              .then(response => {
                  if(response.status == 200){
                      alert("Операция успешна!");
                  }
                  else{
                      alert("Ошибка!");
                  }
              })
              .catch(e => this.error = e); 
          }
          else{
              alert('Введите значения!')
          }
      }
  }

}
</script>

<style>
.add {
    display: inline;
}
</style>
