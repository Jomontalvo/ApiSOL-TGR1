using System;
using TgrManagement.Api.Services;

namespace TgrManagement.Api.Endpoints;

public static class Receipts
{
    public static RouteGroupBuilder MapReceipts(this RouteGroupBuilder builder)
    {
        builder.MapGet("/consultar", GetReceiptByIdAsync).WithName("ObtenerReciboTgr");
        return builder;
    }

    private static async Task<IResult> GetReceiptByIdAsync(
        ITgrCentralService tgrService, int id)
    {
        var response = await tgrService.GetReceiptById(id);
        if (!response.IsSuccess)
        {
            return TypedResults.BadRequest(response.Message);
        }
        return TypedResults.Ok(response.Result);
    }

}
