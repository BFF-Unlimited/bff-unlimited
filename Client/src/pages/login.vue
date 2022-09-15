<template>
  <div class="container">
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
</template>

<script setup>
const router = useRouter();
const username = ref('');
const password = ref('');
const shouldValidate = ref(false);
function onValidated() {
  shouldValidate.value = true;
}
function onSuccess() {
  console.log("succes bitches")
  router.push({ path: '/' });
}
</script>
