using PTestLib.Utils;

namespace PTestLib
{
    public abstract class AbstractTest
    {
        public ListQuestions GetQuestions(string path)
        {
            return JsonSerialize.GetQuestions(path);
        }
        public ListInterpretations GetInterpretations(string path)
        {
            return JsonSerialize.GetInterpretations(path);
        }
        public string GetJson(string path) // открыть тест.json и спарсить в questions и interpretation
        {
            string json = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
        public abstract void GetObject();
        public abstract void GetInterpretation();
        public abstract void SetInterpretation();
    }
}