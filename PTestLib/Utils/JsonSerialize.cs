using Newtonsoft.Json;

namespace PTestLib.Utils
{
    public static class JsonSerialize
    {
        public static ListQuestions GetQuestions(string json)
        {
            if (json == null) throw new Exception("json file не открыт");
            return JsonConvert.DeserializeObject<ListQuestions>(json);
        }

        public static ListInterpretations GetInterpretations(string json)
        {
            if (json == null) throw new Exception("json file не открыт");            
            return JsonConvert.DeserializeObject<ListInterpretations>(json);
        }
    }
}

public struct Answer
{
    public int Id { get; set; }
    public object Content { get; set; }
}
public struct ListAnswers
{
    public List<Answer> Questions { get; set; }
}
public struct Question
{
    public int Id { get; set; }
    public string Content { get; set; }
    public List<Answer> Answers { get; set; }
}
public struct ListQuestions
{
    public List<Question> Questions { get; set; }

    public Question Get(int index)
    {
        return Questions[index];
    }
}
public struct Interpretation
{
    public string Name { get; set; }
    public List<int> NumbersQuestion { get; set; }
}

public struct ListInterpretations
{
    public List<Interpretation> Interpretations { get; set; }
}




