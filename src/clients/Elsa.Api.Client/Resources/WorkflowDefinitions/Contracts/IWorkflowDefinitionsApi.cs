using System.Net.Mime;
using Elsa.Api.Client.Resources.WorkflowDefinitions.Models;
using Elsa.Api.Client.Resources.WorkflowDefinitions.Requests;
using Elsa.Api.Client.Resources.WorkflowDefinitions.Responses;
using Elsa.Api.Client.Shared.Models;
using JetBrains.Annotations;
using Refit;

namespace Elsa.Api.Client.Resources.WorkflowDefinitions.Contracts;

/// <summary>
/// Represents a client for the workflow definitions API.
/// </summary>
[PublicAPI]
public interface IWorkflowDefinitionsApi
{
    /// <summary>
    /// Lists workflow definitions.
    /// </summary>
    /// <param name="request">The request containing options for listing workflow definitions.</param>
    /// <param name="versionOptions">The version options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Get("/workflow-definitions?versionOptions={versionOptions}")]
    Task<ListWorkflowDefinitionsResponse> ListAsync([Query]ListWorkflowDefinitionsRequest request, [Query]VersionOptions? versionOptions = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a workflow definition by definition ID.
    /// </summary>
    /// <param name="definitionId">The definition ID of the workflow definition to get.</param>
    /// <param name="versionOptions">The version options.</param>
    /// <param name="includeCompositeRoot">Whether to include the root activity of composite activities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Get("/workflow-definitions/by-definition-id/{definitionId}?versionOptions={versionOptions}&includeCompositeRoot={includeCompositeRoot}")]
    Task<WorkflowDefinition?> GetByDefinitionIdAsync(string definitionId, VersionOptions? versionOptions = default, bool includeCompositeRoot = false, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets a workflow definition by ID.
    /// </summary>
    /// <param name="id">The ID of the workflow definition to get.</param>
    /// <param name="includeCompositeRoot">Whether to include the root activity of composite activities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Get("/workflow-definitions/by-id/{id}?includeCompositeRoot={includeCompositeRoot}")]
    Task<WorkflowDefinition?> GetByIdAsync(string id, bool includeCompositeRoot = false, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets the number of workflow definitions.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Get("/workflow-definitions/query/count")]
    Task<CountWorkflowDefinitionsResponse> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a value indicating whether a workflow definition name is unique.
    /// </summary>
    /// <param name="name">The name to check.</param>
    /// <param name="definitionId">The ID of the workflow definition to exclude from the check.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Get("/workflow-definitions/validation/is-name-unique?name={name}")]
    Task<GetIsNameUniqueResponse> GetIsNameUniqueAsync(string name, string? definitionId = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves a workflow definition.
    /// </summary>
    /// <param name="request">The request containing the workflow definition to save.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/workflow-definitions")]
    Task<WorkflowDefinition> SaveAsync(SaveWorkflowDefinitionRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes a workflow definition.
    /// </summary>
    /// <param name="definitionId">The definition ID of the workflow definition, and all of its versions, to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Delete("/workflow-definitions/{definitionId}")]
    Task DeleteAsync(string definitionId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes a workflow definition version.
    /// </summary>
    /// <param name="id">The ID of a specific workflow definition version to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Delete("/workflow-definition-versions/{id}")]
    Task DeleteVersionAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Publishes a workflow definition.
    /// </summary>
    /// <param name="definitionId">The ID of the workflow definition to publish.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/workflow-definitions/{definitionId}/publish")]
    Task<WorkflowDefinition> PublishAsync(string definitionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retracts a workflow definition.
    /// </summary>
    /// <param name="definitionId">The ID of the workflow definition to retract.</param>
    /// <param name="request">An empty object to satisfy the request body requirement.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/workflow-definitions/{definitionId}/retract")]
    [Headers(MediaTypeNames.Application.Json)]
    Task<WorkflowDefinition> RetractAsync(string definitionId, RetractWorkflowDefinitionRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes many workflow definitions.
    /// </summary>
    /// <param name="request">The request containing the IDs of the workflow definitions to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/bulk-actions/delete/workflow-definitions/by-definition-id")]
    Task<BulkDeleteWorkflowDefinitionsResponse> BulkDeleteAsync(BulkDeleteWorkflowDefinitionsRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes many workflow definition versions.
    /// </summary>
    /// <param name="request">The request containing the IDs of the workflow definition versions to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/bulk-actions/delete/workflow-definitions/by-id")]
    Task<BulkDeleteWorkflowDefinitionsResponse> BulkDeleteVersionsAsync(BulkDeleteWorkflowDefinitionVersionsRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Publishes many workflow definitions.
    /// </summary>
    /// <param name="request">The request containing the IDs of the workflow definitions to publish.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/bulk-actions/publish/workflow-definitions/by-definition-ids")]
    Task<BulkPublishWorkflowDefinitionsResponse> BulkPublishAsync(BulkPublishWorkflowDefinitionsRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retracts many workflow definitions.
    /// </summary>
    /// <param name="request">The request containing the IDs of the workflow definitions to retract.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Post("/bulk-actions/retract/workflow-definitions/by-definition-ids")]
    Task<BulkRetractWorkflowDefinitionsResponse> BulkRetractAsync(BulkRetractWorkflowDefinitionsRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Exports a workflow definition.
    /// </summary>
    /// <param name="definitionId">The ID of the workflow definition to export.</param>
    /// <param name="versionOptions">The version options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    [Get("/workflow-definitions/{definitionId}/export?versionOptions={versionOptions}")]
    Task<IApiResponse<Stream>> ExportAsync(string definitionId, VersionOptions? versionOptions = default, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Imports a workflow definition.
    /// </summary>
    /// <param name="model">The model containing the workflow definition to import.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The imported workflow definition.</returns>
    [Post("/workflow-definitions/import")]
    Task<WorkflowDefinition> ImportAsync(WorkflowDefinitionModel model, CancellationToken cancellationToken = default);
}