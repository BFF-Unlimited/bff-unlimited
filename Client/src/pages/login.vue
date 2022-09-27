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

<script setup lang="ts">
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
</script>
