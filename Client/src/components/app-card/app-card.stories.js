import AppCard from './AppCard.vue';

export default {
  title: 'Card',
  component: AppCard,
};

const Template = (args, { argTypes }) => ({
  props: Object.keys(argTypes),
  components: { AppCard },
  template: `
  <AppCard v-bind="$props">
  <template v-if="${'header' in args}" v-slot:header>${args.header}</template>
  <template v-if="${'body' in args}" v-slot:body>${args.body}</template>
  </AppCard>
  `,

});

export const Basic = Template.bind({});
Basic.args = {
  body: `<p>The ocelot (Leopardus pardalis) is a medium-sized spotted wild cat that reaches 40-50 cm at the shoulders and weighs between 8 and 15.5 kg. Typically active during twilight and at night, the ocelot tends to be solitary and territorial.</p>`,
};

export const HasHeader = Template.bind({});
HasHeader.args = {
  header: `<h1>Ocelot</h1>`,
  body: `<p>The ocelot (Leopardus pardalis) is a medium-sized spotted wild cat that reaches 40-50 cm at the shoulders and weighs between 8 and 15.5 kg. Typically active during twilight and at night, the ocelot tends to be solitary and territorial.</p>`,
};
