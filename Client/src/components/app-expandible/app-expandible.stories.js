import AppExpandible from './AppExpandible.vue';

export default {
  title: 'Expandible',
  component: AppExpandible,
};

const Template = (args, { argTypes }) => ({
  props: Object.keys(argTypes),
  components: { AppExpandible },
  template: `
  <AppExpandible v-bind="$props">
    <template #buttonText>${args.buttonText}</template>
    <template #content>${args.content}</template>
  </AppExpandible>
  `,
});

export const Expandible = Template.bind({});
Expandible.args = {
  buttonText: 'Menu',
  content: 'Menu item 1',
};
