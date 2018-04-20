import Vue from 'vue';
import VueRouter from 'vue-router';

// components
import home from './components/home.vue';
import about from './components/about.vue';
import timeTable from './components/timeTable/main.vue';
import admin from './components/admin/main.vue';
import timeTableAdmin from './components/admin/timeTableAdmin.vue';
import classAdmin from './components/admin/classAdmin.vue';

Vue.use(VueRouter);

const router = new VueRouter({
  routes: [
    {
      path: '/home',
      name: 'home',
      component: home,
      alias: '/',
    },
    {
      path: '/about',
      name: 'about',
      component: about,
    },
    {
      path: '/admin',
      name: 'admin',
      component: admin,
      children: [
        {
          path: 'class',
          component: classAdmin,
          name: 'classAdmin',
        },
        {
          path: 'timetable',
          component: timeTableAdmin,
          name: 'timeTableAdmin',
        },
      ],
    },
    {
      path: '/timetable',
      name: 'timeTable',
      component: timeTable,
      children: [
        {
          path: ':class',
          component: timeTable,
        },
      ],
    },
  ],
});

function Main() {
  const VueObj = new Vue({
    el: '#app',
    router,
    data: {
      test: 'Привет',
    },
    components: {
      home,
      about,
      timeTable,
    },
  });
}
Main();

