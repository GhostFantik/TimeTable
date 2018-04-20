<template>
  <div class="main">
        <select-data v-model="day" @input="LoadLessons()" :values="valuesDay">День Недели</select-data>
        <select-data v-model="classData" @input="LoadLessons()" :values="valuesClasses">Класс</select-data>
        <div class="output"> 
          <ul><li v-for="item in valuesLessons" :key="item.number">{{item.number}}. {{item.name}}</li></ul>
          </div>
  </div>
</template>

<script>
import selectComponent from "./../select.vue";
import axios from "./../../http-common.js";

export default {
  name: "mainTimeTable",
  data: function() {
    return {
      day: "default",
      classData: "default",
      valuesDay: [
        { key: 0, name: "Понедельник", value: "1" },
        { key: 1, name: "Вторник", value: "2" },
        { key: 2, name: "Среда", value: "3" },
        { key: 3, name: "Четверг", value: "4" },
        { key: 4, name: "Пятница", value: "5" },
        { key: 5, name: "Суббота", value: "6" }
      ],
      valuesClasses: [],
      valuesLessons: [],
    };
  },
  created() {
    this.LoadClasses();
  },
  components: {
    selectData: selectComponent
  },
  methods: {
    LoadClasses: function() {
      axios.HTTP.get("class")
        .then(response => {
          if (response.status == 200) {
            let id = 0;
            response.data.forEach(item => {
              let buffer = {
                key: id,
                name: item.name + " " + item.amount,
                value: item.name
              };
              this.valuesClasses.push(buffer);
              id++;
            });
          }
        })
        .catch(e => {
          this.error = "Error " + e;
        });
    },
    LoadLessons: function() {
      if (this.classData != "default" && this.data != "default") {
        this.valuesLessons = [];
        axios.HTTP.get("class/" + this.classData)
          .then(response => {
            if(response.status == 200){
              let lessons = response.data.lessons;
              lessons.forEach(item => {
                  if(item.day == this.day){
                    this.valuesLessons.push(item);
                  }
              });
              if(this.valuesLessons.lenght <= 0){
                alert("Уроков нет!");
              }
            }
            else{
              alert('Неизвестная ошибка!');
            }
          })
          .catch(e => {
            this.error = "Error " + e;
          });
      }
      else {
        //alert("Выберите класс и день недели");
      }
    }
  }
};
</script>
<style>
.main {
  float: left;
}

</style>

