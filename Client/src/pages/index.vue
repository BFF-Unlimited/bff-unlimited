<template>
  <NuxtLayout name="main">
    <template #header><TheHeader :user="userStore?.user" /></template>
    <template #sidebar><AppSidebar :menu="sidebarStore.navigation" /></template>
    <template #default 
      v-if="!!userStore?.user">
      <h1>Hello World</h1>
    </template>
    <template #default 
      v-else>
      <Login></Login>
    </template>
  </NuxtLayout>
</template>

<script setup>
import { sidebarStore } from '../stores/sidebar';
import { userStore } from '../stores/user';
import Login from './login.vue';

onMounted(() => {
  userStore.getActiveUser();
  sidebarStore.getUserPermissions();
});

definePageMeta({
  layout: false,
});
</script>
