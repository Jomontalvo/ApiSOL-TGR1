using TgrManagement.Api.Models;

namespace TgrManagement.Api.Services;

public class TgrCentralService(
    HttpClient httpClient,
    IConfiguration configuration,
    ILogger<TgrCentralService> logger) : ITgrCentralService
{
    /// <summary>
    /// Get Id Types for generate TGR receipt
    /// </summary>
    /// <returns></returns>
    public async Task<ActionResponse<IEnumerable<Classifier>>> GetIdTypesAsync()
    {
        logger.LogInformation("Calling TGR external service to get id types.");
        var endpoint = configuration["TgrApi:Endpoints:IdTypeList"];
        var response = await httpClient.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            string errorContent = await response.Content.ReadAsStringAsync(); // Lee el contenido como string
            logger.LogWarning("External service responded with status {StatusCode}. Error content: {ErrorContent}",
                (int)response.StatusCode,
                errorContent);
            return new ActionResponse<IEnumerable<Classifier>>
            {
                IsSuccess = false,
                Message = errorContent
            };
        }
        var classifiers = await response.Content.ReadFromJsonAsync<IEnumerable<Classifier>>();
        return new ActionResponse<IEnumerable<Classifier>>
        {
            IsSuccess = true,
            Result = classifiers
        };
    }

    /// <summary>
    /// Get TGR-1 Receipt Categories by Institution
    /// </summary>
    /// <param name="institutionId"></param>
    /// <returns></returns>
    public async Task<ActionResponse<IEnumerable<Classifier>>> GetCategoriesByInstitutionAsync(int institutionId)
    {
        logger.LogInformation("Calling TGR-1 external service to get categories.");
        var endpoint = configuration["TgrApi:Endpoints:CategoryList"];

        var response = await httpClient.GetAsync($"{endpoint}?institutionId={institutionId}");
        if (!response.IsSuccessStatusCode)
        {
            string errorContent = await response.Content.ReadAsStringAsync(); // Lee el contenido como string
            logger.LogWarning("External TGR-1 service responded with status {StatusCode}. Error content: {ErrorContent}",
                (int)response.StatusCode,
                errorContent);
            return new ActionResponse<IEnumerable<Classifier>>
            {
                IsSuccess = false,
                Message = errorContent
            };
        }
        var classifiers = await response.Content.ReadFromJsonAsync<IEnumerable<Classifier>>();
        return new ActionResponse<IEnumerable<Classifier>>
        {
            IsSuccess = true,
            Result = classifiers
        };
    }

    /// <summary>
    /// Get TGR-1 institution list
    /// </summary>
    /// <returns></returns>
    public async Task<ActionResponse<IEnumerable<Classifier>>> GetInstitutionsAsync()
    {
        logger.LogInformation("Calling TGR external service to get institutions.");
        var endpoint = configuration["TgrApi:Endpoints:InstitutionList"];
        var response = await httpClient.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            string errorContent = await response.Content.ReadAsStringAsync(); // Lee el contenido como string
            logger.LogWarning("External service responded with status {StatusCode}. Error content: {ErrorContent}",
                (int)response.StatusCode,
                errorContent);
            return new ActionResponse<IEnumerable<Classifier>>
            {
                IsSuccess = false,
                Message = errorContent
            };
        }
        var classifiers = await response.Content.ReadFromJsonAsync<IEnumerable<Classifier>>();
        return new ActionResponse<IEnumerable<Classifier>>
        {
            IsSuccess = true,
            Result = classifiers
        };
    }

    public Task<ActionResponse<IEnumerable<Classifier>>> GetItemsByCategoryAsync(int institutionId, int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResponse<TgrReceipt>> GetReceiptById(int id)
    {
        throw new NotImplementedException();
    }
}
