<template>
  <div class="card">
    <header class="card-header">
      <slot name="header" />
    </header>
    <div class="card-body">
      <slot name="body" />
    </div>
  </div>
</template>

<style src="./app-card.css" scoped lang="postcss" />
