<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template #sidebar><AppSidebar :menu="sidebarStore?.navigation" /></template>
    <template #default>
      <h1>Hello World</h1>
      <pre>
        {{ navigation }}
      </pre>
    </template>
  </NuxtLayout>
</template>

<script setup>
import { sidebarStore } from '../stores/sidebar';

onMounted(() => sidebarStore?.getUserPermissions())

definePageMeta({
  layout: false,
});

</script>

<style src="../styles/pages/index.css" scoped lang="postcss" />
