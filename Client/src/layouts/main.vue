<template>
  <div class="page__container">
    <header class="page__header"><slot name="header" /></header>
    <aside
      class="page__aside"
      :class="{ minimal: sidebar.isMinimal }"
    >
      <slot name="sidebar" />
    </aside>
    <main class="page__main"><slot /></main>
  </div>
</template>

<script setup>
import { sidebar } from '../stores/sidebar';
</script>

<style src="./default.css" scoped lang="postcss" />
