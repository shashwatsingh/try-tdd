using System;
using System.Linq;
using System.Collections.Generic;
using Ardalis.GuardClauses;


namespace QuizApp.Core;

public sealed class SystemData
{
    public IEnumerable<Tenant>? Tenants { get; set; }
}

public sealed class Tenant
{
    public static Tenant NullTenant = new Tenant();

    internal User? Owner { get; set; }
    internal IEnumerable<User>? Participants { get; set; }
    internal List<Quiz> Quizzes { get; set; } = new();
    internal List<QuizRun> Runs { get; set; } = new();
}

public sealed class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? EmailAddress { get; set; }
}

public sealed class Quiz
{
    public static readonly Quiz NullQuiz = new Quiz("null");

    private readonly ISet<Question> questions = new SortedSet<Question>();

    public Quiz(string name)
    {
        Guard.Against.NullOrWhiteSpace(name, nameof(name));

        Name = name;
    }
    public long ID { get; set; }
    public string Name { get; set; }
    public IEnumerable<Question> Questions => questions.AsEnumerable();

    public void AddQuestion(Question question)
    {
        Guard.Against.Null(question, nameof(question));
        if (!questions.Add(question))
        {
            throw new ArgumentException("The question is already added in this quiz");
        }
    }
}

public record Question
{
    public long Id { get; set; }
    public string? Text { get; set; }
    public IEnumerable<Answer>? Answers { get; set; }
    public long AnswerId { get; set; }
}
public sealed class Answer
{
    public long Id { get; set; }
    public string? Text { get; set; }
}


public sealed class QuizRun
{

    public long Id { get; set; }
    public long QuizId { get; set; }

    public List<QuizResponse> Answers { get; set; } = new ();

    public IEnumerable<long>? Participants { get; set; }
}

public sealed class QuizResponse
{
    public long Id { get; set; }
    public long QuizId { get; set; }
    public long ParticipantId { get; set; }
    public long AnswerId { get; set; }
    public DateTime AnsweredOn { get; set; }
}
