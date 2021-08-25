using System.Collections.Generic;

namespace PsihologARM
{
    public abstract class BasePsihologyInterpretation
    {
        protected List<QuestionTest> ResultArr = new List<QuestionTest>();

        protected void _func_Intermediate_calculation_result(ref int promResult, int[] keyTrueArr,
            int[] keyFalseArr)
        {
            for (int i = 0; i < ResultArr.Count; i++)
            {
                for (int j = 0; j < keyTrueArr.Length; j++)
                {
                    if (ResultArr[i].number == keyTrueArr[j])
                    {
                        if (ResultArr[i].answer == true)
                        {
                            promResult++;
                        }
                    }
                }

                for (int j = 0; j < keyFalseArr.Length; j++)
                {
                    if (ResultArr[i].number == keyFalseArr[j])
                    {
                        if (ResultArr[i].answer == false)
                        {
                            promResult++;
                        }
                    }
                }
            }
        }
    }
}