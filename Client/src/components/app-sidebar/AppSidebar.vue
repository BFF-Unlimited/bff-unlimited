<template>
  <div
    class="side-nav"
    :class="{ minimal: isSidebarMinimal }"
  >
    <button
      class="toggle-sidenav"
      @click="toggleIsSidebarMinimal"
    >Lalla</button>
    <ul class="side-nav-ul">
      <li
        v-for="item of menu"
        :key="item?.text"
        :class="{ active: item?.active }"
      >
        <NuxtLink :to="item?.link">{{ item?.text }}</NuxtLink>
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
import { ref, emit } from 'vue';

defineProps({
  menu: {
    type: Object,
    default(data) {
      return { menu: data?.menu };
    },
  },
});

const isSidebarMinimal = ref(true);
function toggleIsSidebarMinimal() {
  isSidebarMinimal.value = !isSidebarMinimal.value;

  emit('toggle-sidebar', isSidebarMinimal.value)
}
</script>

<style src="./app-sidebar.css" scoped lang="postcss" />
