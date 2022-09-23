import { Matchers } from "@pact-foundation/pact-web";
const { like, eachLike } = Matchers;

let server;

const sendLogin = {
  username: "Ans",
  password: "1234"
};

const expectedLoginResult = "796dcfda-2b20-4927-abb7-c14d34e81eaf";

describe("Login page", () => {
  describe("when user logs in", () => {
    before(() => {
      cy.mockServer({
        consumer: "pactflow-example-consumer-cypress",
        provider: 'pactflow-example-provider',
      }).then(opts => {
        server = opts
      })
    });

    it("Login user with correct password and username", () => {
      cy.addMockRoute({
        server,
        as: 'login',
        state: "Login user",
        uponReceiving: "Bearer token",
        withRequest: {
          method: "post",
          path: "/token",
          body: like(sendLogin)
        },
        willRespondWith: {
          status: 200,
          headers: {
            "Content-Type": "application/text; charset=utf-8",
          },
          body: like(expectedLoginResult),
        },
      });

      // Navigate to products listing page
      cy.visit("http://localhost:3000/login");
      cy.get('input#username').type("Ans");
      cy.get('input#password').type("1234");
      cy.get('button.primary-button').click();
      cy.wait("@login");
    });
  });
});