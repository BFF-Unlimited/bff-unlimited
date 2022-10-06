<template>
  <NuxtLayout name="login">
    <div class="login-container">
      <AppCard>
        <template #header>
          <h2>Inloggen</h2>
        </template>
        <template #body>
          <AppButton
            :label="'Inloggen'"
            @click="redirectToLogin()" 
            ></AppButton>
        </template>
      </AppCard>
    </div>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const username = ref('');
const password = ref('');
const shouldValidate = ref(false);

onMounted(() => loginGuard());

//TODO: moet worden vervangen door routing guard middleware
function loginGuard(){
  let userIsLoggedIn: string = window.localStorage.getItem("token");
  if(userIsLoggedIn) router.push({ path: '/' });
}

function onValidated() {
  shouldValidate.value = true;
}

function onSuccess(token: string) {
  window.localStorage.setItem("token", token)
  router.push({ path: '/' });
}

function redirectToLogin() {
  document.location = "/bff/login"
}
</script>
