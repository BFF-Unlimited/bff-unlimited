# CSS styleguide

This document outlines best practices on writing semantic, scalable, and modular CSS.

## Directory Structure

### Reusable styling

General, reusable styles are defined in the `/src/styles` directory:

#### `reset.css`

`reset.css` contains a collection of CSS rules used to clear the browser's default formatting of HTML elements.

#### `layout.css`

`layout.css` contains layout styles that apply globally to the project.

#### `variables.css`

`variables.css` contains the variables used throughout the project.

#### `typography.css`

`typography.css` sets the `font-family` of the app.

#### `utilities.css`

Utility classes avoid repetition by creating a set of abstract classes that can be reused on HTML elements. Each utility class is responsible for doing one specific job.

#### `index.css`

All files in the `/src/styles` directory are imported in `index.css`.

### Component styling

Each component in the `/src/components` directory has its own `.css` file, containing the component specific styling.
 
## Target classes

Add styles using classes (not tags), so that you are not tied to specific markup:

```css
// Bad
header {
  ...
}

// Good
.app-header {
  ...
}
```

## Code Formatting

### Declaractions

* There should be only one property per line
* Colors should be specified in hex or rgba values
* Hex values should be in lowercase and use shorthand if possible (e.g., `#fff`) for better readability
* Do not specify units for zero-values (e.g, `margin: 0`)

### Shorthand

Limit the use of shorthand declarations if you do not need to explicitly set additional declarations.

```css
// Bad
.my-selector {
  margin: 1rem 0 0 0;
  border-radius: 4px 0 0 0;
}

// Good
.my-selector {
  margin-top: 1rem;
  border-top-left-radius: 4px;
}
```

## Units

* Use `px` for things that should scale in a fixed manner
* Use `rem` for things that should scale with the root `font-size`
* Use `em` for things that should scale with the element `font-size`
* Use `vw` and `vh` for things that should scale with the viewport
* `line-height` should be a unitless multiplier of `font-size`

## Specificity

### Rule Specificity

Rules and properties should only be as specific as they need to be:

```css
// Bad
.grandparent .parent .my-selector {
  ...
}

// Good
.my-selector {
  ...
}
```

### Nesting

[PostCSS Nested](https://www.npmjs.com/package/postcss-nested) is used mainly for nesting media queries. This can make our code very easy to digest when working in responsive styles.

```css
.my-selector {
  ...

  @media (min-width: 1024px) {
    ...
  }
}
```

Nesting can easily make things much more complex and hard to digest. Therefor, use nesting sparingly and limit it to 3 levels or less.

## Variables

CSS variables should be used wherever a property value may need to be repeated across the codebase (e.g., color values, breakpoints).

* Use kebab-case (e.g., `$color-white`)
* Use semantic naming conventions

```css
// Bad
$blue: #0000ff;

// Good
$brand-primary: #0000ff;
```

## Ordering

* Order side values by `top`, `right`, `bottom`, `left`
* Declare mixins first, then regular properties
* Group properties by type:

```css
.my-block {
  // Positioning
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  z-index: 10;

  // Box Model
  box-sizing: border-box;
  display: block;
  width: 100px;
  height: 100px;
  padding-top: 10px;
  padding-bottom: 10px;
  margin: 10px;
  overflow: hidden;

  // Typography
  font-family: 'Times New Roman', serif;
  font-size: 1rem;
  font-style: italic;
  font-weight: bold;
  line-height: 1.5;
  color: #000;
  text-align: center;
  text-decoration: underline;
  text-shadow: 0 1px 0 #fff;
  text-transform: uppercase;

  // Accessibility & Interaction
  cursor: pointer;

  // Background & Borders
  background: #aaa;
  border: 10px solid #000;
  box-shadow: 0 0 10px #000;

  // Transitions & Animations
  transition: all 100ms ease;
}
```
