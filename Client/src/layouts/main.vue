<template>
  <div class="page-container">
    <header class="page-header"><slot name="header" /></header>

    <main class="page-main">
      <aside
        class="page-aside"
        :class="{ minimal: sidebarStore.isMinimal }"
      >
        <slot name="sidebar" />
      </aside>
      
      <div class="main-wrapper">
        <slot />
      </div>
    </main>
  </div>
</template>

<script setup>
import { sidebarStore } from '../stores/sidebar';
</script>

<style src="./default.css" scoped lang="postcss" />
