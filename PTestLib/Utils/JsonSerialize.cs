using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTestLib.Utils
{
    public class JsonSerialize
    {

    }

    public struct Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
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
    }
}
