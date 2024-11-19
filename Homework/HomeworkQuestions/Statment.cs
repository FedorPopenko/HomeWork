namespace Homework.HomeworkQuestions
{
    public class Statment
    {
        public Statment(string Question, string Answer, string Fact)
        {
            this.Question = Question;
            this.Answer = Answer;
            this.Fact = Fact;
        }

        public string Question { get; }
        public string Answer { get; }
        public string Fact { get; }
    }

}
