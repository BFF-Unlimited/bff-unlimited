<template>
  <button
    :type="type"
    :class="[primaryAction ? 'primary-button' : 'secondary-button']"
  >
    {{ label }}
  </button>
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

<style src="./app-button.css" scoped lang="postcss" />
