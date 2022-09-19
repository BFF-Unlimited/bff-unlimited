<template>
  <div
    ref="expandible"
    class="expandible"
    :class="{ 'is-expanded': isExpanded }"
  >
    <button
      aria-expanded="false"
      class="expandible-button"
      @click="isExpanded = !isExpanded"
    >
      <slot name="buttonText" />
    </button>
    <div
      v-if="isExpanded"
      class="expandible-panel"
    >
      <slot name="content" />
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useClickOutside } from './../../composables/useClickOutside';

const expandible = ref(null);
let isExpanded = ref(false);

useClickOutside(expandible, () => {
  isExpanded.value = false;
});
</script>

<style src="./app-expandible.css" scoped lang="postcss" />
