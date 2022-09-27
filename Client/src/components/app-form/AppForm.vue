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
let errorMessage = ref("");
onMounted(() => checkValidity());

function checkValidity() {
  isValid.value = form.value.checkValidity();
}

async function onSubmit() {
  const {public: {baseURL}} = useRuntimeConfig();
  shouldValidate.value = true;
  errorMessage.value = ""
  emit('validated');
  isValid.value = form.value.checkValidity();

  if (!isValid.value) {
    return;
  }

  try{
    let {data, error}: any = await useFetch(props.action, {
      method: props.method,
      body: JSON.stringify(Object.fromEntries(new FormData(form.value))),
      baseURL,
      initialCache: false
    })

    if(data.value == null){
      errorMessage.value = error.value.data
      return
    }

    emit('success', data.value)
  }
  catch(err){
    console.log(err)
  }
  finally {
    isValid.value = false;
  }
}
</script>

<style src="./app-form.css" scoped lang="postcss" />
