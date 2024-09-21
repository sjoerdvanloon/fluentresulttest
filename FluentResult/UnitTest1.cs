namespace FluentResult;

public class UnitTest1
{
    [Fact]
    public void SuccessResult_ShouldBeSuccess()
    {
        var noteGenerator = new NoteGenerator();
        var result = noteGenerator.Generate();
        Assert.True(result.IsSuccess);
        Assert.Equal("Note", result.Value);
    }

    [Fact]
    public void FailResult_ShouldHave1Error()
    {
        var noteGenerator = new NoteGenerator();
        var result = noteGenerator.GenerateSourNote();
        Assert.True(result.IsFailed);
        Assert.Equal("Error", result.Errors.First().Message);
    }

    [Fact]
    public void FailResult_ShouldHave2Errors()
    {
        var noteGenerator = new NoteGenerator();
        var result = noteGenerator.GenerateSourNoteWithMultpleErrors();
        Assert.True(result.IsFailed);
        Assert.Equal(2, result.Errors.Count);
        Assert.Equal("Error1", result.Errors.First().Message);
        Assert.Equal("Error2", result.Errors.Last().Message);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IfFail_ShouldBeConditional(bool success)
    {
        var noteGenerator = new NoteGenerator();
        var result = noteGenerator.CheckIfFail(success);

        if (success)
        {
            Assert.True(result.IsSuccess);
            return;
        }
        else
        {
            Assert.True(result.IsFailed);
            Assert.Equal("Error", result.Errors.First().Message);
        }
    }
}