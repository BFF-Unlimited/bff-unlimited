# Vue styleguide

This project follows the [official style guide](https://vuejs.org/style-guide/) for Vue-specific code. When writing Vue code, please check this document to see which rules to follow.
This is a living document: if no rules are specified in this document yet, please add them. Small deviations from the official style guide are documented here as well.

## Component Recommended Rules

* When possible each component should be defined in its own dedicated file (SFC). To keep this file more readabily, the components styling is defined in its own `.css` file.
* Filenames of Single-File Components should always be PascalCase.
* App-wide reusable components are prefixed with `App`.
* Component names should always be multi-worded to not conflict with any existing or future HTML elements.
* Components that should only ever have a single active instance, e.g. the site header of site footer, should begin with the `The` prefix, to denote that there can be only one.
* Tightly coupled child components should be prefixed with their parent component's name, for instance a `TodoListItem` in a `TodoList`. This groups them together and declares them related.
* Components with no content should be self-closing. Components that self-close communicate that they not only have no content, but are meant to have no content.
* Component names should prefer full words over abbreviations. The autocompletion in editors make the cost of writing longer names very low, while the clarity they provide is invaluable. Uncommon abbreviations, in particular, should always be avoided.

---

## Props

* Prop definitions should always be as detailed as possible, specifying at least type(s):

```js
// Bad
props: ['status']

// Good
props: {
  status: String
  required: true
}
```

* Prop names should always use camelCase during declaration, but kebab-case in templates:

```js
props: {
  greetingText: String
}
```

```HTML
<WelcomeMessage greeting-text="hi"/>
```

---

## Attributes

* For better readability, elements with multiple attributes should span multiple lines, with one attribute per line.
* Attributes [should be ordered consistently](https://vuejs.org/style-guide/rules-recommended.html#element-attribute-order).
* Non-empty HTML attribute values should always be inside quotes:

```HTML
<AppSidebar :class="{ open: isOpen }">
```

---

## Fetch (Ajax calls)
In this project we are mainly using `isFetch` for doing Ajax calls. Because `useFetch` is a smart wrapper around `useAsyncData` and `$fetch`.

> `useFetch` only works during setup or Lifecycle Hooks ([read more about data fetching](https://v3.nuxtjs.org/getting-started/data-fetching/)).


The `useFetch` can be simply used like the example below.

```vue
<script setup>
const { data: count } = await useFetch('/api/count')
</script>

<template>
  Page visits: {{ count }}
</template>
```

The `useFetch` composable will return a few things next to the data from the response. The properties that are comming back are `data`, `pending`, `error` and `refresh`.

- `data` will give the data from the response
- `pending` will be true when the request has being called but not been resolved or reject. So this property will be excelent for showing a loading spinner.
- `error` will give back an error when the request has been rejected for whatever reason
- `refresh` is an method that is handy in the situations when you have to do the call again to refresh the data from the request.

in the example below you can see how you can use them.

```vue
<template>
  <!-- you'll need to handle a loading state -->
  <div v-if="pending">
    Loading ...
  </div>
  <div v-if="error">
    The posts couldn't load from the API 😔
  </div>
  <div v-else>
    <div v-for="post in posts">
      <!-- do something -->
    </div>
  </div>
  <button @click="refresh()"></button>
</template>

<script setup>
const { data: posts, pending, error, refresh } = useFetch('/api/posts')
</script>

```



---


## Composable


---


## TypeScript interfaces usage in components



---

## Rule of thumb variables in VueJS

- When using a `ref` of `reactive`, use a `const` variable.
- If the value doesn't change, use `const`
- When it's an `object` or `array`, use `const`
- Want to change a variable (value and/or type) use `let`
