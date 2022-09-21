<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template #sidebar><AppSidebar :menu="menu" /></template>
    <template #default><h1>Hello World</h1></template>
  </NuxtLayout>
</template>

<script setup>
const {
  public: { baseURL },
} = useRuntimeConfig();

let token = null;

if (process?.client) {
  token = window.localStorage.getItem('token');
}


definePageMeta({
  layout: false,
});

console.log('loading: ', token);
if (token) {
  try {
    console.log('baseURL: ', baseURL);
    // console.log('ans: ', ans)
    const data = await $fetch(baseURL + '/User/activeUser', {
      headers: {
        Authorization:  `Bearer ${token}`
      }
    });
    console.log('response: ', data);
  } catch (err) {
    console.error(err);
  }
}

const menu = [
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
];
</script>

<style src="../styles/pages/index.css" scoped lang="postcss" />
