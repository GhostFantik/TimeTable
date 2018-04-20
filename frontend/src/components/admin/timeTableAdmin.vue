<template>
    <div class="main">
        <select-data v-model="classData" @input="LoadLessons()" :values="valuesClasses">Класс</select-data>
        <select-data v-model="day" @input="LoadLessons()" :values="valuesDay">День Недели</select-data>
        <select-data v-model="numberLesson"  :values="valuesNumber">Номер</select-data>
        <input type="text" placeholder="Название урока" v-model="nameLesson">
        <select-data v-model="currentLesson" :values="valuesLesson">Выберите урок</select-data>
        <button @click="AddLesson()">Добавить урок</button>
        <button @click="DeleteLesson()">Удалить урок</button>
    </div>
</template>

<script>
import selectComponent from "./../select.vue";
import axios from "./../../http-common.js";

export default {
  data: function() {
    return {
      valuesClasses: [],
      valuesLesson: [],
      classData: "",
      day: "",
      numberLesson: "",
      nameLesson: "",
      currentLesson: null, // для удаления
      valuesDay: [
        { key: 0, name: "Понедельник", value: "1" },
        { key: 1, name: "Вторник", value: "2" },
        { key: 2, name: "Среда", value: "3" },
        { key: 3, name: "Четверг", value: "4" },
        { key: 4, name: "Пятница", value: "5" },
        { key: 5, name: "Суббота", value: "6" }
      ],
      valuesNumber: [
        { key: 0, name: "1", value: "1" },
        { key: 1, name: "2", value: "2" },
        { key: 2, name: "3", value: "3" },
        { key: 3, name: "4", value: "4" },
        { key: 4, name: "5", value: "5" },
        { key: 5, name: "6", value: "6" },
        { key: 6, name: "7", value: "7" },
        { key: 7, name: "8", value: "8" }
      ]
    };
  },
  components: {
    selectData: selectComponent
  },
  created() {
    this.LoadClasses();
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
    AddLesson: function() {
      if (
        this.day != "" &&
        this.classData != "" &&
        this.numberLesson != "" &&
        this.nameLesson != ""
      ) {
        let data = {
          lesson: {
            Name: this.nameLesson,
            Number: this.numberLesson,
            Day: this.day
          },
          nameClass: this.classData,
          nameTeacher: "Иванов Иван Иванович"
        };
        axios.HTTP.post("lesson", data)
          .then(response => {
            if (response.status == 200) {
              alert("Операция успешна!");
              LoadLessons();
            } else {
              alert("Не удалось выполнить операцию!");
            }
          })
          .catch(e => (this.error = e));
      } else {
        alert("Введите данные!");
      }
    },
    DeleteLesson: function() {
      if (this.currentLesson != null) {
        axios.HTTP.delete("lesson/" + this.currentLesson)
          .then(response => {
            if (response.status == 200) {
              alert("Урок удалён!");
              LoadLessons();
            } else {
              alert("Ошибка!");
            }
          })
          .catch(e => (this.error = e));
      } else {
        alert("Выберите урок!");
      }
    },
    LoadLessons: function() {
      if (this.classData != "" && this.day != "") {
        this.valuesLesson = [];
        axios.HTTP.get("class/" + this.classData)
          .then(response => {
            if (response.status == 200) {
              let lessons = response.data.lessons;
              let id = 0;
              lessons.forEach(item => {
                if (item.day == this.day) {
                  let valuesForLesson = {
                    key: id,
                    name: item.name + " " + item.number,
                    value: item.id,
                  };
                  this.valuesLesson.push(valuesForLesson);
                  id++;
                }
              });
            } else {
              alert("Неизвестная ошибка!");
            }
          })
          .catch(e => {
            this.error = "Error " + e;
          });
      } else {
        //alert("Выберите класс и день недели");
      }
    }
  }
};
</script>

