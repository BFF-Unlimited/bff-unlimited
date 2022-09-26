import { defineConfig } from "cypress";
const registerPact = require('./cypress/plugins');

export default defineConfig({
    e2e: {
      setupNodeEvents(on, config) {
        // implement node event listeners here
        registerPact(on, config)
    
      },    
    }
  }
);
