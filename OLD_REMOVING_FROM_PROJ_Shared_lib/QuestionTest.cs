namespace Shared_lib

    //Модель элемента опросника (номер вопроса, сам вопрос, ответ тестируемого)
{
    public class QuestionTest
    {
        public int number;
        public string question;
        public bool answer;

        public QuestionTest(int _num, string _question, bool _answer)
        {
            number = _num;
            question = _question;
            answer = _answer;
        }
    }
}