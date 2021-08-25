using System.Collections.Generic;

namespace PsihologARM
{
    public class Aizenc_test_Interpretation : BasePsihologyInterpretation
    {
        private int[] _credibility_arr_key_true = new int[] { 6, 24, 36 };
        private int[] _credibility_arr_key_false = new int[] { 12, 18, 30, 42, 48, 54 };

        private int[] _Extraversion_Introversion_arr_key_true = new int[]
            { 1, 3, 8, 10, 13, 17, 22, 25, 27, 39, 44, 46, 49, 53, 56 };

        private int[] _Extraversion_Introversion_arr_key_false = new int[] { 5, 15, 20, 29, 32, 34, 37, 41, 51 };

        private int[] _Emotional_Stability_arr_key_true = new int[]
            { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23, 26, 28, 31, 33, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57 };

        private int[] _Emotional_Stability_arr_key_false = new int[] { };

        public Aizenc_test_Interpretation(List<QuestionTest> resultArr)
        {
            ResultArr = resultArr;
        }

        public void func_Credibility_test(ref int resultCredibility)
        {
            int prom_result = 0;
            _func_Intermediate_calculation_result(ref prom_result, _credibility_arr_key_true,
                _credibility_arr_key_false);
            if (prom_result >= 0 && prom_result <= 3)
            {
                resultCredibility = 0;
            }
            else if (prom_result > 3 && prom_result < 7)
            {
                resultCredibility = 1;
            }
            else
            {
                resultCredibility = 2;
            }
        }

        public void _func_Extraversion_Introversion(ref int Extraversion_Introversion_result)
        {
            _func_Intermediate_calculation_result(ref Extraversion_Introversion_result,
                _Extraversion_Introversion_arr_key_true, _Extraversion_Introversion_arr_key_false);
        }

        public void _func_Emotional_Stability(ref int Emotional_Stability_result)
        {
            _func_Intermediate_calculation_result(ref Emotional_Stability_result, _Emotional_Stability_arr_key_true,
                _Emotional_Stability_arr_key_false);
        }
    }
}