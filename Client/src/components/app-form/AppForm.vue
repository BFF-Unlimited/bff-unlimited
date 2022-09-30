<template>
  <form
    ref="form"
    novalidate
    :class="{ 'is-validated': shouldValidate }"
    class="login-form"
    @input="checkValidity"
    @submit.prevent="onSubmit"
  >
    <p
      v-if="shouldValidate && !isValid"
      class="error-message"
    >
      {{errorMessage}}
    </p>
    <slot />
    <AppButton
      type="submit"
      :label="buttonLabel"
      :primary-action="hasPrimaryButton"
    />
  </form>
</template>

<script setup lang="ts">
const props = defineProps({
  action: {
    type: String,
    required: true,
  },
  method: {
    type: String,
    default: 'post',
  },
  buttonLabel: {
    type: String,
    default: 'Verstuur',
  },
  hasPrimaryButton: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(['validated', 'success']);

const form = ref(null);
const isValid = ref(false);
const shouldValidate = ref(false);
const errorMessage = ref("");
onMounted(() => checkValidity());

function checkValidity() {
  isValid.value = form.value.checkValidity();
}

async function onSubmit() {
  const {
    public: { baseURL },
  } = useRuntimeConfig();
  shouldValidate.value = true;
  errorMessage.value = ""
  emit('validated');
  isValid.value = form.value.checkValidity();

  if (!isValid.value) {
    return;
  }

  try {
    const response = await useApi(props.action, {
      headers: new Headers({ 'content-type': 'application/json' }),
      method: props.method,
      body: JSON.stringify(Object.fromEntries(new FormData(form.value))),
    });
    emit('success', response);
  } catch (err) {
    errorMessage.value = err.data
  } finally {
    isValid.value = false;
  }
}
</script>

<style src="./app-form.css" scoped lang="postcss" />
