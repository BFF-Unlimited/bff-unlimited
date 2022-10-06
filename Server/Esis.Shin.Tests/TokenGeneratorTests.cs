using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using PactNet.Verifier.Messaging;
using Xunit;
using Xunit.Abstractions;

namespace Esis.Shin.Tests
{
    public class TokenGeneratorTests : IDisposable
    {
        private readonly PactVerifier _verifier;
        private readonly ServerApiFixture _fixture;
        public TokenGeneratorTests(ITestOutputHelper output)
        {
            _fixture = new ServerApiFixture();
            _verifier = new PactVerifier(new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(output)
                },
                LogLevel = PactLogLevel.Debug
            });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _verifier.Dispose();
        }

        [Fact]
        public void EnsureTokenApiHonoursPactWithConsumer()
        {
            var pactPath = Path.Combine("..",
                                           "..",
                                           "..",
                                           "..",
                                           "..",
                                           "Client",
                                           "cypress",
                                           "pacts",
                                           "bff-mock-provider-undefined.json");

            _verifier
                .ServiceProvider("Event API", _fixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .WithSslVerificationDisabled()
                .Verify();
        }
    }
}
