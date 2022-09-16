<template>
  <div class="side-nav">
    <ul class="side-nav-ul">
      <li
        v-for="item of menu"
        :key="item?.text"
        v-bind:class="{ active: true }"
      >
        <NuxtLink :to="item?.link">{{ item?.text }}</NuxtLink>
        <ul
          class="side-sub-ul"
          v-if="item?.submenu"
        >
          <li
            v-for="sub of item.submenu"
            :key="sub?.text"
          >
            <NuxtLink :to="sub?.link">{{ sub?.text }}</NuxtLink>
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup>
defineProps({
  menu: {
    type: String,
    default: 'button',
  },
});
</script>

<script>
const menu = [
  {
    text: 'Groep 4b',
    link: '/',
    submenu: [
      {
        text: 'Overzicht',
        link: '/',
      },
      {
        text: 'Groepsplan',
        link: '/',
      },
      {
        text: 'Over de groep',
        link: '/',
      },
    ],
  },
];
export default {
  data() {
    return {
      menu,
    };
  },
};
</script>

<style src="./app-sidebar.css" scoped lang="postcss" />
