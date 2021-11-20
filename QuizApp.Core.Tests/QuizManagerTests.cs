using Xunit;

namespace QuizApp.Core.Tests;

public class QuizManagerTests
{
    [Fact]
    public void ShouldCreateNewQuiz()
    {
        var sut = new QuizManager();
        var quiz = new Quiz
        {
            Name = "Q1",
            Questions = 
        };

        sut.CreateQuiz();
    }
}