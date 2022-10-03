<template>
  <div class="page-container">
    <div class="page-header"><slot name="header" /></div>
    <div class="page-sidebar">
      <slot name="sidebar" />
    </div>
    <main class="page-main">
      <slot />
    </main>
  </div>
</template>

<style src="./default.css" scoped lang="postcss" />
