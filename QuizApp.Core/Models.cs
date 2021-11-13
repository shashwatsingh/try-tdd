namespace QuizApp.Core;

public sealed class SystemData
{
    public IEnumerable<Tenant>? Tenants {get;set;}
}

public sealed class Tenant
{
    public static Tenant NullTenant = new Tenant();

    internal User? Owner { get; set; }
    internal IEnumerable<User>? Participants {get;set;}
    internal IEnumerable<Quiz>? Quizzes {get;set;}
    internal IEnumerable<QuizRun>? Runs { get; set; }
}

public sealed class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? EmailAddress { get; set; }
}

public sealed class Quiz
{
    public string? Name{get;set;}
    public IEnumerable<Question>? Questions{get;set;}

}

public sealed class Question
{
    public long Id{get;set;}
    public string? Text{get;set;}
    public IEnumerable<Answer>? Answers{get;set;}
    public long AnswerId{get;set;}
}
public sealed class Answer
{
    public long Id{get;set;}
    public string? Text{get;set;}
}


public sealed class QuizRun
{
    public long Id { get; set; }
    public long QuizId { get; set; }

    public IEnumerable<QuizResponse>? Answers {get;set;}

    public IEnumerable<int>? Participants {get;set;}
}

public sealed class QuizResponse
{
    public long Id { get; set; }
    public long QuizId { get; set; }
    public long ParticipantId { get; set; }
    public long AnswerId { get; set; }
    public DateTime AnsweredOn { get; set; }
}
