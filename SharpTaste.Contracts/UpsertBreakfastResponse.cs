namespace SharpTaste.Contracts;
public record UpsertBreakfastRequest
(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);
