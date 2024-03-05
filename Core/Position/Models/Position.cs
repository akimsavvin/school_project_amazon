using System.ComponentModel.DataAnnotations;

namespace Amazon.Core.Position.Models;

public class PositionModel(Guid id, string name, string descrpiption)
{
    public Guid Id { get; } = id;
    public string Name { get; set; } = name;

    [MinLength(40)]
    public string Descrpiption { get; set; } = descrpiption;
}
