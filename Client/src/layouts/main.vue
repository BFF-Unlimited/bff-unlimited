<template>
  <div class="page-container">
    <header class="page-header"><slot name="header" /></header>

    <main class="page-main">
      <aside
        class="page-aside"
      >
        <slot name="sidebar" />
      </aside>
      
      <div class="main-wrapper">
        <slot />
      </div>
    </main>
  </div>
</template>

<style src="./default.css" scoped lang="postcss" />
