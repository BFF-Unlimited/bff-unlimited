<template>
  <NuxtLayout name="login">
    <div class="login-container">
      <AppCard>
        <template #header>
          <h2>Inloggen</h2>
        </template>
        <template #body>
          <AppForm
            action="/token"
            method="post"
            button-label="Inloggen"
            has-primary-button
            @validated="onValidated"
            @success="onSuccess"
          >
            <FormInput
              v-model="username"
              type="text"
              name="username"
              label="Gebruikersnaam"
              :should-validate="shouldValidate"
              validation-error-message="Gebruikersnaam is verplicht"
              required
            />
            <FormInput
              v-model="password"
              type="text"
              name="password"
              label="Password"
              :should-validate="shouldValidate"
              validation-error-message="Wachtwoord is verplicht"
              required
            />
          </AppForm>
        </template>
      </AppCard>
    </div>
  </NuxtLayout>
</template>

<script setup lang="ts">import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const username = ref('');
const password = ref('');
const shouldValidate = ref(false);

function onValidated() {
  shouldValidate.value = true;
}

function onSuccess(data: any) {
  window.localStorage.setItem('token', data.value);
  router.push({ path: '/' });
}
</script>
