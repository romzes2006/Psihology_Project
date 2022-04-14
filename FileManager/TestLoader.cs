using Iterpretation_Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FileManager
{
    public class TestLoader
    {
        string json;

        public TestLoader()
        {
            json = string.Empty;
        }

        public string GetFileString(string questionPath) // Открыть тест.json и спарсить в Questions и Interpretation
        {
            using (StreamReader reader = new StreamReader(questionPath))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
        public QuestionList CreateQuestion(string json)
        {
            JsonIsCloseException();
            return JsonConvert.DeserializeObject<QuestionList>(json);
        }

        public InterpretationList CreateInterpretations(string json)
        {
            JsonIsCloseException();
            InterpretationList interpretationList = new InterpretationList();            

            JObject objects = JObject.Parse(json);

            var interpretationsList = (from interpretation in objects.Values()
                                       select interpretation).First();

            foreach (var interpretation in interpretationsList)
            {
                Dictionary<string, List<int>> pairList =
                     JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(interpretation.ToString());

                if (pairList == null) throw new Exception("Не найдена пара ключ значение - интерпретации");

                var key = (from _key in pairList.Keys
                           select _key).First();

                var values = (from _value in pairList.Values
                              select _value).First();

                interpretationList.Add(key, values);
            }

            return interpretationList;
        }

        public void JsonIsCloseException()
        {
            if (json == null) throw new Exception("Json file не открыт");
        }
    }
}
