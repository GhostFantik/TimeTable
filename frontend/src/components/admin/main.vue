<template>
    <div class="main">
        <div class="toggleMain">
            <h1>Админ панель</h1>
            <ul>
                <li><div class="buttonMenu">
                    <button @click="toggleComponent = 'classAdmin'">Редактировать классы</button>
                    </div></li>
                <li><div class="buttonMenu">
                    <button @click="toggleComponent = 'timeTableAdmin'">Редактировать расписание</button>
                    </div></li>
            </ul>
        </div>
        <div class="currentComponent"><component :is="toggleComponent"></component></div>
    </div>
</template>
<script>
import classAdmin from "./classAdmin.vue";
import timeTableAdmin from "./timeTableAdmin.vue";

export default {
  data: function() {
    return {
      toggleComponent: "classAdmin"
    };
  },
  components: {
    classAdmin,
    timeTableAdmin
  }
};
</script>
<style>
.main {
  display: inline;
}

.currentComponent {
  float: left;
}
</style>

