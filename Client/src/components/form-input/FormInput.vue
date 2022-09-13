<template>
  <div class="form-input">
    <label :for="name">
      {{ label }}
    </label>
    <input
      :id="name"
      ref="input"
      :name="name"
      v-bind="$attrs"
      :value="modelValue"
      @input="onInput"
    />
    <span
      v-if="showValidationMessage"
      class="error-message"
      >{{ validationErrorMessage }}</span
    >
  </div>
</template>

<script>
import { ref, computed, watch } from 'vue';
export default {
  inheritAttrs: false,
};
</script>

<script setup>
const props = defineProps({
  label: {
    type: String,
    required: true,
  },
  modelValue: {
    type: String,
    required: true,
  },
  name: {
    type: String,
    required: true,
  },
  shouldValidate: {
    type: Boolean,
  },
  validationErrorMessage: {
    type: String,
    default: 'Er gaat iets mis!',
  },
  showCustomValidity: {
    type: Boolean,
  },
});

const emits = defineEmits(['update:modelValue']);
const isValid = ref(false);
const input = ref(null);

const showValidationMessage = computed(() => {
  return props.shouldValidate && !isValid.value;
});

watch(
  () => props.modelValue,
  () => {
    isValid.value = input.value.checkValidity();
  },
);

watch(
  () => props.showCustomValidity,
  () => {
    setCustomValidity();
  },
);

function onInput(e) {
  emits('update:modelValue', e.target.value);
}

function setCustomValidity() {
  input.value.setCustomValidity(props.showCustomValidity ? props.validationErrorMessage : '');
  isValid.value = input.value.checkValidity();
}
</script>

<style src="./form-input.css" scoped lang="postcss" />
