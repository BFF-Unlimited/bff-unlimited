/**
 * @param {*} element The Root element for which clicking outside will trigger callbackFunction
 * @param {*} callbackFunction The function to call when the user clicks outside of the element
 * @returns
 */

import { onMounted, onBeforeMount } from 'vue';

export function useClickOutside(element, callbackFunction) {
  if (!element) return;

  let listener = (event) => {
    if (event.target !== element.value && event.composedPath().includes(element.value)) {
      return;
    }

    if (typeof callbackFunction === 'function') {
      callbackFunction();
    }
  };

  onMounted(() => {
    window.addEventListener('click', listener);
  });

  onBeforeMount(() => {
    window.removeEventListener('click', listener);
  });

  return listener;
}
