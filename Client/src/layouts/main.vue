<template>
  <div class="page-container">
    <header class="page-header"><slot name="header" /></header>
    <aside
      class="page-aside"
      :class="{ minimal: sidebarStore.isMinimal }"
    >
      <slot name="sidebar" />
    </aside>
    <main class="page-main"><slot /></main>
  </div>
</template>

<script setup>
import { sidebarStore } from '../stores/sidebar';
</script>

<style src="./default.css" scoped lang="postcss" />
