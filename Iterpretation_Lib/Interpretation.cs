namespace Iterpretation_Lib
{
    public class Interpretation
    {
        public string Key { get; set; }
        public List<int> Value { get; set; }

        public Interpretation(string key, List<int> value)
        {
            Key = key;
            Value = value;
        }
    }
}
