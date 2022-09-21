<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template #sidebar><AppSidebar :menu="menu" /></template>
    <template #default>
      <h1>Hello World</h1>
      <pre>
        {{user}}
      </pre>
    </template>
  </NuxtLayout>
</template>

<script setup>
import { useApi } from '~~/composables';

const {
  public: { baseURL },
} = useRuntimeConfig();

const user = ref(null);
const navigation = ref([])

definePageMeta({
  layout: false,
});

try {
  console.log('baseURL: ', baseURL);
  // console.log('ans: ', ans)
  const data = await useApi(baseURL + '/User/activeUser');
  console.log('response: ', data);
  user.value = data;
  const perm = {}
  user.value?.permissions.forEach((item) => {
    const [propName, child] = item.categoryDescription.split('.');
    const name = propName.toLowerCase()
    if (perm[name]) {
      perm[name]?.items.push(item)
    } else {
      perm[name] = {}
      perm[name].items = []
      perm[name].name = propName
    }
  })

  console.log('perm: ', Object.values(perm))
} catch (err) {
  console.error(err);
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
