# Vue styleguide

This project follows the [official style guide](https://vuejs.org/style-guide/) for Vue-specific code.

This document additonally outlines some component recommended rules.

## Component Recommended Rules

* When possible each component should be defined in its own dedicated file (SFC). To keep this file more readabily, the components styling is defined in its own `.css` file.
* App-wide reusable components are prefixed with `App`.
* Component names should always be multi-worded to not conflict with any existing or future HTML elements.
  Components that should only ever have a single active instance, e.g. the site header of site footer, should begin with the `The` prefix, to denote that there can be only one.
* Tightly coupled child components should be prefixed with their parent component's name, for instance a `TodoListItem` in a `TodoList`. This groups them together and declares them related.
