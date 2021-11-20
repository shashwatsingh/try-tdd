namespace QuizApp.Core;

public interface IQuizManager
{

}

public class QuizManager : IQuizManager
{
    private readonly Tenant tenant;

    public QuizManager(Tenant tenant)
    {
        this.tenant = tenant;
    }

    internal void Add(Quiz quiz)
    {
        tenant.Quizzes.Add(quiz);
    }

    public bool TryFindQuiz(string v, out Quiz quiz)
    {
        var found = tenant.Quizzes.FirstOrDefault(q => q.Name == v);

        if (found == null)
        {
            quiz = Quiz.NullQuiz;
            return false;
        }

        quiz = found;
        return true;
    }

    internal bool HasRuns(long ID)
    {
        return tenant.Runs.Where(x => x.QuizId == ID).Any();
    }

    internal void Delete(long quizID)
    {
        Console.WriteLine("Delete");
        if (quizID <= 0) throw new ArgumentException("Invalid Quiz ID");

        var quiz = tenant.Quizzes.Where(x => x.ID == quizID).FirstOrDefault();

        if (quiz == null) throw new ArgumentException("Quiz does not exist.");

        if (HasRuns(quizID)) throw new InvalidOperationException("Cannot delete a quiz with quns");

        tenant.Quizzes.Remove(quiz);

        Console.WriteLine("Abc");
        // TODO: DELETE related questions.

    }

}