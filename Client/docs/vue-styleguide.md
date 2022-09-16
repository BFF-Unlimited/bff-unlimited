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

## Attributes

* For better readability, elements with multiple attributes should span multiple lines, with one attribute per line.
* Attributes [should be ordered consistently](https://vuejs.org/style-guide/rules-recommended.html#element-attribute-order).
* Non-empty HTML attribute values should always be inside quotes:

```HTML
<AppSidebar :style="{ width: sidebarWidth + 'px' }">
```
