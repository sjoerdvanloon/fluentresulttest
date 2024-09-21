using FluentResults;

namespace FluentResult;

public class NoteGenerator
{
    public Result<string> Generate()
    {
        return "Note";
    }

    public Result<string> GenerateSourNote()
    {
        return Result.Fail("Error");
    }

    public Result<string> GenerateSourNoteWithMultpleErrors()
    {
        return Result.Fail(new List<IError>() { new Error("Error1"), new Error("Error2") });
    }

    public Result CheckIfFail(bool success)
    {
        return Result.FailIf(!success, "Error");
    }
}