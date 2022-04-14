

using Iterpretation_Lib;

namespace FileManager
{
    public class InterpretationList
    {
        public List<Interpretation> Interpretations { get; set; }

        public InterpretationList()
        {
            Interpretations = new List<Interpretation>();
        }

        public void Add(string key, List<int> values)
        {
            Interpretations.Add(new Interpretation(key, values));
        }
    }
}
