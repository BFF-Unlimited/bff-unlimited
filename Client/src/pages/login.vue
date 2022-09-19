<template>
  <NuxtLayout name="login">
    <div class="login-container">
      <AppCard>
        <template #header>
          <h2>Inloggen</h2>
        </template>
        <template #body>
          <AppForm
            action="/api/login"
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
          </AppForm>
        </template>
      </AppCard>
    </div>
  </NuxtLayout>
</template>

<script setup>
const router = useRouter();
const username = ref('');
const shouldValidate = ref(false);
function onValidated() {
  shouldValidate.value = true;
}
function onSuccess() {
  router.push({ path: '/' });
}
</script>
