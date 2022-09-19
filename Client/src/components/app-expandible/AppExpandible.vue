<template>
  <div
    ref="expandible"
    class="expandible"
    :class="{ 'is-expanded': isExpanded }"
  >
    <button
      aria-expanded="false"
      class="expandible-button"
      @click="toggle"
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
const isExpanded = ref(false);

function toggle() {
  isExpanded.value = !isExpanded.value;
}

useClickOutside(expandible, () => {
  isExpanded.value = false;
});
</script>

<style src="./app-expandible.css" scoped lang="postcss" />
