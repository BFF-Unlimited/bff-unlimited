import { Matchers } from "@pact-foundation/pact-web";
const { like } = Matchers;

const expectedLoginResult = "796dcfda-2b20-4927-abb7-c14d34e81eaf";

describe("Login page", () => {
  describe("when user logs in", () => {
    before(() => {
      cy.setupPact({
        consumer: "pactflow-example-consumer-cypress",
        provider: 'pactflow-example-provider',
      });
      cy.intercept(
      {
        method: "post",
        url: "https://localhost:7182/token"
      },
      {
        status: 200,
        headers: {
          "Content-Type": "application/text; charset=utf-8",
        },
        body: like(expectedLoginResult)
      }).as('login');
    });

    it("Login user with correct password and username", () => {
      // Navigate to products listing page
      cy.visit("http://localhost:3000/login");
      cy.get('input#username').type("Ans");
      cy.get('input#password').type("1234");
      cy.get('button.primary-button').click();
      cy.usePactWait('login');
    });
  });
});