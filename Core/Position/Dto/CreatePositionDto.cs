namespace Amazon.Core.Position.Dto;

public class CreatePositionDto(string name, string description)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
}
