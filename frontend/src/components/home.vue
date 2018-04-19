<template>
  <div class="home">
    <ul class="menu">
      <li><div class="buttonMenu"><router-link :to="{ name: 'timeTable'}">Расписание</router-link></div></li>
      <li><div class="buttonMenu"><router-link :to="{ name: 'admin'}">Админ Панель</router-link></div></li>
      <li><div class="buttonMenu"><router-link :to="{ name: 'about'}">О Нас</router-link></div></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "home",
  data: function() {
    return {};
  }
};
</script>

<style>
.menu {
  list-style-type: none;
}

</style>

