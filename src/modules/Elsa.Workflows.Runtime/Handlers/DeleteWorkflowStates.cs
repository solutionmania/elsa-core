using Elsa.Mediator.Contracts;
using Elsa.Workflows.Management.Notifications;
using Elsa.Workflows.Runtime.Contracts;
using Elsa.Workflows.Runtime.Filters;

namespace Elsa.Workflows.Runtime.Handlers;

/// <summary>
/// Deletes workflow states when a workflow definition or version is deleted.
/// </summary>
public class DeleteWorkflowStates :
    INotificationHandler<WorkflowDefinitionDeleting>,
    INotificationHandler<WorkflowDefinitionVersionDeleting>,
    INotificationHandler<WorkflowDefinitionsDeleting>,
    INotificationHandler<WorkflowDefinitionVersionsDeleting>
{
    private readonly IWorkflowStateStore _workflowStateStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteWorkflowStates"/> class.
    /// </summary>
    public DeleteWorkflowStates(IWorkflowStateStore workflowStateStore)
    {
        _workflowStateStore = workflowStateStore;
    }

    /// <inheritdoc />
    public async Task HandleAsync(WorkflowDefinitionDeleting notification, CancellationToken cancellationToken)
    {
        await DeleteWorkflowStatesAsync(new WorkflowStateFilter { DefinitionId = notification.DefinitionId }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task HandleAsync(WorkflowDefinitionVersionDeleting notification, CancellationToken cancellationToken)
    {
        await DeleteWorkflowStatesAsync(new WorkflowStateFilter { DefinitionVersionId = notification.WorkflowDefinition.Id }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task HandleAsync(WorkflowDefinitionsDeleting notification, CancellationToken cancellationToken)
    {
        await DeleteWorkflowStatesAsync(new WorkflowStateFilter { DefinitionIds = notification.DefinitionIds }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task HandleAsync(WorkflowDefinitionVersionsDeleting notification, CancellationToken cancellationToken)
    {
        await DeleteWorkflowStatesAsync(new WorkflowStateFilter { Ids = notification.Ids }, cancellationToken);
    }

    private async Task DeleteWorkflowStatesAsync(WorkflowStateFilter filter, CancellationToken cancellationToken) => await _workflowStateStore.DeleteManyAsync(filter, cancellationToken);
}