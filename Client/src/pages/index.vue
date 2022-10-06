<template>
  <NuxtLayout name="main">
    <template #header><TheHeader :user="userStore?.user" /></template>
    <template #sidebar><AppSidebar :menu="sidebarStore.navigation" /></template>
    <template
      v-if="!!userStore?.user"
      #default>
      <h1>Hello World</h1>
    </template>
    <template
      v-else
      #default>
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
