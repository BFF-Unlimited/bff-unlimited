<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template
      #sidebar
      ><AppSidebar
        :menu="menu"
    /></template>
    <template #default><h1>Hello World</h1></template>
  </NuxtLayout>
</template>

<script>
definePageMeta({
  layout: false,
});

export default {
  data() {
    return {
      menu: [
        {
          text: 'Groep 4b',
          link: '/',
          active: true,
          submenu: [
            {
              text: 'Overzicht',
              link: '/',
              active: false,
            },
            {
              text: 'Groepsplan',
              link: '/',
              active: false,
            },
            {
              text: 'Over de groep',
              link: '/',
              active: true,
            },
          ],
        },
        {
          text: 'Leerlingen',
          link: '/',
          active: false,
          submenu: [
            {
              text: 'Overzicht',
              link: '/',
              active: false,
            },
            {
              text: 'Groepsplan',
              link: '/',
              active: false,
            },
            {
              text: 'Over de groep',
              link: '/',
              active: false,
            },
          ],
        },
        {
          text: 'Absenties',
          link: '/',
          active: false,
          submenu: [
            {
              text: 'Overzicht',
              link: '/',
              active: false,
            },
            {
              text: 'Groepsplan',
              link: '/',
              active: false,
            },
            {
              text: 'Over de groep',
              link: '/',
              active: false,
            },
          ],
        },
        {
          text: 'Registraties',
          link: '/',
          active: false,
          submenu: [
            {
              text: 'Overzicht',
              link: '/',
              active: false,
            },
            {
              text: 'Groepsplan',
              link: '/',
              active: false,
            },
            {
              text: 'Over de groep',
              link: '/',
              active: false,
            },
          ],
        },
        {
          text: 'Resultaten',
          link: '/',
          active: false,
          submenu: [
            {
              text: 'Overzicht',
              link: '/',
              active: false,
            },
            {
              text: 'Groepsplan',
              link: '/',
              active: false,
            },
            {
              text: 'Over de groep',
              link: '/',
              active: false,
            },
          ],
        },
        {
          text: 'Koppelingen',
          link: '/',
          active: false,
          submenu: [
            {
              text: 'Overzicht',
              link: '/',
              active: false,
            },
            {
              text: 'Groepsplan',
              link: '/',
              active: false,
            },
            {
              text: 'Over de groep',
              link: '/',
              active: false,
            },
          ],
        },
      ],
    };
  },
  methods: {},
};
</script>

<style src="../styles/pages/index.css" scoped lang="postcss" />
