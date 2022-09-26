<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template #sidebar><AppSidebar :menu="sidebarStore.navigation" /></template>
    <template #default>
      <h1>Hello World</h1>
    </template>
  </NuxtLayout>
</template>

<script setup>
import { sidebarStore } from '../stores/sidebar';
import { userStore } from '../stores/user';

onMounted(() => {
  userStore.getActiveUser();
  sidebarStore.getUserPermissions();
});

definePageMeta({
  layout: false,
});
</script>

<style src="../styles/pages/index.css" scoped lang="postcss" />
