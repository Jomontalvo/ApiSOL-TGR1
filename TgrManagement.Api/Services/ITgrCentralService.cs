using TgrManagement.Api.Models;

namespace TgrManagement.Api.Services;

public interface ITgrCentralService
{
    Task<ActionResponse<IEnumerable<Classifier>>> GetIdTypesAsync();
    Task<ActionResponse<IEnumerable<Classifier>>> GetInstitutionsAsync();
    Task<ActionResponse<IEnumerable<Classifier>>> GetCategoriesByInstitutionAsync(int institutionId);
    Task<ActionResponse<IEnumerable<Classifier>>> GetItemsByCategoryAsync(int institutionId, int categoryId);
    Task<ActionResponse<TgrReceipt>> GetReceiptById(int id);

}
