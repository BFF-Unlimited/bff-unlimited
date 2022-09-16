<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template #sidebar><AppSidebar /></template>
    <template #default><h1>Hello World</h1></template>
  </NuxtLayout>
</template>

<script>
definePageMeta({
  layout: false,
});
</script>

<style src="../styles/pages/index.css" scoped lang="postcss" />
