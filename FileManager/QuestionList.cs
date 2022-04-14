using Iterpretation_Lib;
using Questions_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager // TODO :: решится в 16
{
    public class QuestionList
    {
        public List<Question> Questions { get; set; }
        public QuestionList()
        {
            Questions = new List<Question>();
        }

    }
}
