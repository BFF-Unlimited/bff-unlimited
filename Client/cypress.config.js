import { defineConfig } from "cypress";
const registerPact = require('./cypress/plugins/cypress-pact');

export default defineConfig({
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
      registerPact(on, config)
  
    },    
  },
  pact: {
      options: {
        dir: "./pacts"
      },
      providers: [
        {
          provider: "pactflow-example-provider"
        },
        {
          provider: "pactflow-example-bi-directional-provider-dredd"
        },
        {
          provider: "pactflow-example-bi-directional-provider-restassured"
        },
        {
          provider: "pactflow-example-bi-directional-provider-postman"
        }
      ]
    }    
  }
);
