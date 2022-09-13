<template>
  <form
    ref="form"
    novalidate
    :class="{ 'is-validated': shouldValidate }"
    @input="checkValidity"
    @submit.prevent="onSubmit"
  >
    <p
      v-if="shouldValidate && !isValid"
      class="error-message"
    >
      Het formulier bevat fouten
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

onMounted(() => checkValidity());

function checkValidity() {
  isValid.value = form.value.checkValidity();
}

function onSubmit() {
  shouldValidate.value = true;
  emit('validated');
  isValid.value = form.value.checkValidity();

  if (!isValid.value) {
    return;
  }

  fetch(props.action, {
    method: props.method,
    body: JSON.stringify(Object.fromEntries(new FormData(form.value))),
  })
    .then((res) => res.json())
    .then(() => {
      return emit('success');
    })
    .catch((err) => console.log(err))
    .finally(() => {
      isValid.value = false;
    });
}
</script>

<style src="./app-form.css" scoped lang="postcss" />
