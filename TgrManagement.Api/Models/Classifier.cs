using System;

namespace TgrManagement.Api.Models;

public class Classifier
{
    public string Code { get; set; } = default!;
    public string? Description { get; set; }
    public string? Name { get; set;}
}
