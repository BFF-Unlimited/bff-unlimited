<template>
    <aside>
        Sidebar
    </aside>
  </template>
  
  <script setup>
  defineProps({
    type: {
      type: String,
      default: 'button',
    },
    label: {
      type: String,
      default: 'Opslaan',
    },
    primaryAction: {
      type: Boolean,
      default: false,
    },
  });
  </script>
  
  <style src="./app-sidebar.css" scoped lang="postcss" />
  