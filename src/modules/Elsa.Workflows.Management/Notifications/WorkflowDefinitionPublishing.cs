using Elsa.Mediator.Contracts;
using Elsa.Workflows.Management.Entities;

namespace Elsa.Workflows.Management.Notifications;

public record WorkflowDefinitionPublishing(WorkflowDefinition WorkflowDefinition) : INotification;