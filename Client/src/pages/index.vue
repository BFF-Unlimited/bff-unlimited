<template>
  <NuxtLayout name="main">
    <template #header>Header</template>
    <template #sidebar><AppSidebar :menu="menu" /></template>
    <template #default><h1>Hello World</h1></template>
  </NuxtLayout>
</template>

<script>
definePageMeta({
  layout: false,
});

const userData = {
  userName: 'Ans',
  activeVestiging: {
    logoUrl: 'logoUrl',
    name: 'Vestiging',
    id: '5ebd3711-9663-488d-b78e-631829f3ad66',
  },
  activeGroep: {
    name: 'Groep',
    id: '72af9af4-afa5-4d95-aaf1-d9a8155825b3',
  },
  vestigingen: [
    {
      logoUrl: 'logoUrl',
      name: 'Vestiging',
      id: '5ebd3711-9663-488d-b78e-631829f3ad66',
    },
  ],
  groepen: [
    {
      name: 'Groep',
      id: '72af9af4-afa5-4d95-aaf1-d9a8155825b3',
    },
  ],
  permissions: [
    {
      id: 'permission://Groep.Overview',
      categoryDescription: 'Groep.Overview',
      description: 'Groepsoverzicht',
    },
    {
      id: 'permission://Groep.Groepsplan',
      categoryDescription: 'Groep.Groepsplan',
      description: 'Groepsplan',
    },
    {
      id: 'permission://Groep.About',
      categoryDescription: 'Groep.About',
      description: 'Over',
    },
    {
      id: 'permission://Leerling.Overview',
      categoryDescription: 'Leerling.Overview',
      description: 'Leerlingenoverzicht',
    },
    {
      id: 'permission://Leerling.Search',
      categoryDescription: 'Leerling.Search',
      description: 'Leerling zoeken',
    },
    {
      id: 'permission://Registration.Overview',
      categoryDescription: 'Registration.Overview',
      description: 'Registratieoverzicht',
    },
    {
      id: 'permission://Registration.Create',
      categoryDescription: 'Registration.Create',
      description: 'Registratie aanmaken',
    },
  ],
  id: 'df449d66-ef37-49e7-9d2e-530277ed2aac',
};

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
