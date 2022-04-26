using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTestLib.Utils
{
    public class JsonSerialize
    {
        //        string json;
        //        public TestLoader()
        //        {
        //            json = string.Empty;
        //        }

        //        public string GetFileString(string questionPath) // Открыть тест.json и спарсить в Questions и Interpretation
        //        {
        //            using (StreamReader reader = new StreamReader(questionPath))
        //            {
        //                json = reader.ReadToEnd();
        //            }
        //            return json;
        //        }
        //        public QuestionList CreateQuestion(string json)
        //        {
        //            JsonIsCloseException();
        //            return JsonConvert.DeserializeObject<QuestionList>(json);
        //        }

        //        public InterpretationList CreateInterpretations(string json)
        //        {
        //            JsonIsCloseException();
        //            InterpretationList interpretationList = new InterpretationList();

        //            JObject objects = JObject.Parse(json);

        //            var interpretationsList = (from interpretation in objects.Values()
        //                                       select interpretation).First();

        //            foreach (var interpretation in interpretationsList)
        //            {
        //                Dictionary<string, List<int>> pairList =
        //                     JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(interpretation.ToString());

        //                if (pairList == null) throw new Exception("Не найдена пара ключ значение - интерпретации");

        //                var key = (from _key in pairList.Keys
        //                           select _key).First();

        //                var values = (from _value in pairList.Values
        //                              select _value).First();

        //                interpretationList.Add(key, values);
        //            }

        //            return interpretationList;
        //        }

        //        public void JsonIsCloseException()
        //        {
        //            if (json == null) throw new Exception("Json file не открыт");
        //        }
        //    }
        //}
    }

    public struct Answer
    {
        //"answers": [{
        //            "id": 1,
        //            "content": "True"
        //        }
        //    ]
        public int Id { get; set; }
        public object Content { get; set; }
    }
    public struct ListAnswers
    {
        public List<Answer> Questions { get; set; }
    }
    public struct Question
    {
        //{
        //    "id": 1,
        //    "content": "Вы часто испытываете тягу к новым впечатлениям, к тому, чтобы «встряхнуться», испытать возбуждение?",
        //    "answers": [{
        //            "id": 1,
        //            "content": "True"
        //        }
        //    ]
        //}
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
    public struct ListQuestions
    {
        public List<Question> Questions { get; set; }
    }
}
