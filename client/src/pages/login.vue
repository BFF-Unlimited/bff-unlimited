<template>
  <div class="container">
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
  </div>
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
