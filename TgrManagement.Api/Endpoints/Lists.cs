using Microsoft.AspNetCore.Mvc;
using TgrManagement.Api.Services;

namespace TgrManagement.Api.Endpoints;

public static class Lists
{
    public static RouteGroupBuilder MapLists(this RouteGroupBuilder builder)
    {
        builder.MapGet("/tiposid", GetIdTypeListAsync).WithName("ObtenerTiposId");
        builder.MapGet("/instituciones", GetInstitutionListAsync).WithName("ObtenerInstituciones");
        return builder;
    }

    /// <summary>
    /// Get Id Type List
    /// </summary>
    /// <param name="tgrService"></param>
    /// <param name="campo"></param>
    /// <returns></returns>
    public async static Task<IResult> GetIdTypeListAsync(
        [FromQuery] string campo,
        ITgrCentralService tgrService)
    {
        try
        {
            var response = await tgrService.GetIdTypesAsync();
            if (!response.IsSuccess)
            {
                return TypedResults.BadRequest(response.Message);
            }
            var idTypeList = response.Result!;
            return TypedResults.Ok(idTypeList.Select(it => it.Description ?? string.Empty));
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get institution list from TGR-1
    /// </summary>
    /// <param name="campo"></param>
    /// <param name="tgrService"></param>
    /// <returns></returns>
    public async static Task<IResult> GetInstitutionListAsync(
        [FromQuery] string campo,
        ITgrCentralService tgrService)
    {
        var response = await tgrService.GetInstitutionsAsync();
        if (!response.IsSuccess)
        {
            return TypedResults.BadRequest(response.Message);
        }
        var institutionList = response.Result!;
        return TypedResults.Ok(institutionList.Select(i => i.Description ?? string.Empty));
    }
}
