<template>
  <div
    class="side-nav"
    :class="{ minimal: sidebar.isMinimal }"
  >
    <button
      class="toggle-sidenav"
      @click="sidebar.toggleIsMinimal"
    >
      <span
        v-if="!sidebar.isMinimal"
        class="icon"
        >⬅️</span
      >
      <span
        v-if="sidebar.isMinimal"
        class="icon"
        >➡️</span
      >
    </button>
    <ul class="side-nav-ul">
      <li
        v-for="item of menu"
        :key="item?.text"
        :class="{ active: item?.active }"
      >
        <NuxtLink :to="item?.link">
          <span
            v-if="!sidebar.isMinimal"
            class="text"
            >{{ item?.text }}</span
          >
          <span
            v-if="sidebar.isMinimal"
            class="icon"
            >➡️</span
          >
        </NuxtLink>
        <ul
          v-if="item?.submenu && item?.active"
          class="side-sub-ul"
        >
          <li
            v-for="sub of item.submenu"
            :key="sub?.text"
            :class="{ active: sub?.active }"
          >
            <NuxtLink :to="sub?.link">{{ sub?.text }}</NuxtLink>
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { sidebar } from '../../stores/sidebar';

defineProps({
  menu: {
    type: Object,
    default(data) {
      return { menu: data?.menu };
    },
  },
});
</script>

<style src="./app-sidebar.css" scoped lang="postcss" />
