using System.Net;
using Elsa.Http;
using Elsa.Workflows.Core.Abstractions;
using Elsa.Workflows.Core.Activities;
using Elsa.Workflows.Core.Contracts;
using Elsa.Workflows.Core.Services;

namespace Elsa.Samples.HelloWorld;

public class HelloWorldHttpWorkflow : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        builder.Root = new Sequence
        {
            Activities =
            {
                new HttpEndpoint
                {
                    Path = new("/hello-world"),
                    SupportedMethods = new(new[] { HttpMethods.Get }),
                    CanStartWorkflow = true
                },
                new WriteHttpResponse
                {
                    StatusCode = new(HttpStatusCode.OK),
                    Content = new("Hello world!")
                }
            }
        };
    }
}