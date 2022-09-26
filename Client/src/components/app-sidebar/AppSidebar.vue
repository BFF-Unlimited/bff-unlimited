<template>
  <div
    class="side-nav"
    :class="{ minimal: sidebarStore.isMinimal }"
  >
    <button
      class="toggle-sidenav"
      @click="sidebarStore.toggleIsMinimal"
    >
      <span
        v-if="!sidebarStore.isMinimal"
        class="icon"
        >⬅️</span
      >
      <span
        v-if="sidebarStore.isMinimal"
        class="icon"
        >➡️</span
      >
      <span class="visually-hidden">{{ sidebarStore.isMinimal ? 'maximaliseer' : 'minimaliseer' }} sidebaar</span>
    </button>
    <ul class="side-nav-ul">
      <li
        v-for="item of menu"
        :key="item?.name"
        :class="{ active: item?.active }"
        class="side-nav-item"
      >
        <NuxtLink
          class="side-nav-link"
          :to="item?.link"
        >
          <span
            v-if="!sidebarStore.isMinimal"
            class="text"
            >{{ item?.name }}</span
          >
          <span
            v-if="sidebarStore.isMinimal"
            class="icon"
            >➡️</span
          >
        </NuxtLink>
        <ul
          v-if="item?.items && item?.active"
          class="side-sub-ul"
        >
          <li
            v-for="sub of item.items"
            :key="sub?.id"
            :class="{ active: sub?.active }"
            class="side-sub-item"
          >
            <NuxtLink
              class="side-nav-link"
              :to="sub?.link"
              >{{ sub?.name }}</NuxtLink
            >
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { sidebarStore } from '../../stores/sidebar';

const hiddenTextToggleButton = sidebarStore.isMinimal ? 'maximaliseer' : 'minimaliseer'

defineProps({
  menu: {
    type: Array,
    default: null,
  },
});
</script>

<style src="./app-sidebar.css" scoped lang="postcss" />
