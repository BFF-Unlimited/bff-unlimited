<template>
  <div class="page__container">
    <header class="page__header"><slot name="header" /></header>
    <aside class="page__aside"><slot name="sidebar" /></aside>
    <main class="page__main"><slot /></main>
  </div>
</template>

<style src="./default.css" scoped lang="postcss" />
