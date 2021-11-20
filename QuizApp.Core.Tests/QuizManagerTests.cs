namespace QuizApp.Core.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class QuziManagerTests
{
    [Fact]
    public void ShouldAddQuiz()
    {
        //Given
        var qm = new QuizManager(TestData.GetNewTenant());

        //When
        qm.Add(new Quiz("q1"));

        //Then
        Assert.True(qm.TryFindQuiz("q1", out _));
    }
    [Fact]
    public void ShouldDeleteQuiz()
    {
        Tenant tenant = TestData.GetNewTenantWithRuns();
        var qm = new QuizManager(tenant);
        qm.Add(new Quiz("q1") { ID = 10, });
        qm.Add(new Quiz("q2") { ID = 20, });
        qm.Add(new Quiz("q3") { ID = 30, });

        var quizIdWithRuns = 30;
        var quizIdWithoutRuns = 1;
        var invalidQuizID = -9;


        Assert.Throws<ArgumentException>(
            () => qm.Delete(quizIdWithoutRuns)
        );

        Assert.Throws<ArgumentException>(
            () => qm.Delete(invalidQuizID)
        );

        Assert.Throws<InvalidOperationException>(
            () => qm.Delete(quizIdWithRuns)
        );

        qm.Delete(10);
        Assert.True(tenant.Quizzes.Count == 2);
    }
}

internal static class TestData
{

    public static Tenant GetNewTenant()
    {
        return new Tenant();
    }
    public static Tenant GetNewTenantWithRuns()
    {
        return new Tenant()
        {
            Runs = new List<QuizRun>()
            {
                new QuizRun
                {
                    QuizId = 30
                }
            }
        };
    }
}