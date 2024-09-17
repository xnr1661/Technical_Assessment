namespace Technical_Assessment.Application.Services.Abstractions;

using Technical_Assessment.Domain.Entities;

public interface IRoverService
{
    void ExecuteCommands(Rover rover, string commands);
}
