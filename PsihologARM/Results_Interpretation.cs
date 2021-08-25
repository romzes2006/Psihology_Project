using System.Collections.Generic;

namespace PsihologARM
{
     public class Results_Interpretation : BasePsihologyInterpretation
    {
        public int Credibility { get; private set; }
        public int Adaptive { get; private set; }
        public int Neuropsychological { get; private set; }
        public int Communication { get; private set; }
        public int Moral_normativity { get; private set; }
        public int Suicide_risk { get; private set; }
        
        public int stan_Adaptive { get; private set; }
        public int stan_Neuropsychological { get; private set; }
        public int stan_Communication { get; private set; }
        public int stan_Moral_normativity { get; private set; }
        public int stan_Suicide_risk { get; private set; }

        private int[] _credibility_arr = new int[] {1, 10, 19, 31, 51, 69, 78, 92, 101, 116, 128, 138, 148};

        private int[] _adaptive_abilities_key_true_arr = new int[]
        {
            4, 6, 7, 8, 9, 11, 12, 14, 15, 16, 17, 18, 20, 21, 22, 24, 27, 28, 29, 30, 33, 36, 37, 39, 40, 41, 42, 43,
            46, 47, 50, 56, 57, 59, 59, 60, 61, 63, 64, 65, 67, 68, 70, 71, 72, 73, 75, 77, 79, 80, 81, 82, 83, 84, 86,
            88, 89, 90, 91, 93, 94, 95, 96, 98, 99, 102, 103, 104, 16, 108, 109, 110, 111, 112, 113, 114, 115, 117, 118,
            119, 120, 121, 122, 123, 124, 125, 126, 127, 129, 131, 133, 135, 136, 137, 139, 141, 142, 143, 145, 146,
            149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 161, 162, 164, 165
        };

        private int[] _adaptive_abilities_key_false_arr = new int[]
        {
            2, 3, 5, 13, 23, 25, 26, 32, 34, 35, 38, 44, 45, 48, 49, 52, 53, 54, 55, 58, 62, 66, 74, 76, 85, 87, 100,
            105, 107, 130, 132, 134, 140, 144, 147, 159, 160, 163
        };

        private int[] _neuropsychological_steadiness_key_true_arr = new int[]
        {
            4, 6, 7, 8, 11, 12, 15, 16, 17, 18, 20, 21, 28, 29, 30, 37, 39, 40, 41, 47, 57, 60, 63, 65, 67, 68, 70, 71,
            73, 75, 80, 82, 83, 84, 86, 89, 94, 95, 96, 98, 102, 103, 108, 109, 110, 111, 112, 113, 115, 117, 118, 119,
            120, 122, 123, 124, 127, 129, 131, 135, 136, 139, 143, 146, 149, 153, 154, 155, 156, 157, 158, 161, 162
        };

        private int[] _neuropsychological_steadiness_key_false_arr = new int[]
        {
            2, 3, 5, 23, 25, 32, 38, 44, 45, 49, 52, 53, 54, 55, 58, 62, 66, 87, 105, 132, 134, 140
        };

        private int[] _communication_features_key_true_arr = new int[]
        {
            9, 24, 27, 33, 43, 46, 61, 64, 81, 88, 90, 99, 104, 106, 114, 121, 126, 133, 142, 151, 152
        };

        private int[] _communication_features_key_false_arr = new int[]
        {
            26, 34, 35, 48, 74, 85, 107, 130, 144, 147, 159
        };

        private int[] _moral_normativity_key_true_arr = new int[]
        {
            14, 22, 36, 42, 50, 56, 59, 72, 77, 79, 91, 93, 125, 141, 145, 150, 164, 165
        };

        private int[] _moral_normativity_key_false_arr = new int[]
        {
            13, 76, 97, 100, 160, 163
        };

        private int[] _suicide_risk_key_true_arr = new int[]
        {
            4, 8, 10, 28, 29, 39, 41, 47, 70, 84, 115, 119, 124, 136, 137, 149, 154, 155
        };

        private int[] _suicide_risk_key_false_arr = new int[]
        {
            35, 105
        };

        public Results_Interpretation(List<QuestionTest> resultArr)
        {
            ResultArr = resultArr;
            Credibility = 0;
            Adaptive = 0;
            Communication = 0;
            Moral_normativity = 0;
            Suicide_risk = 0;
            
            stan_Adaptive = 0;
            stan_Communication = 0;
            stan_Moral_normativity = 0;
            stan_Suicide_risk = 0;
        }

  

        public bool func_Credibility_test()
        {
            int promResult = 0;
            for (int i = 0; i < ResultArr.Count; i++)
            {
                for (int j = 0; j < _credibility_arr.Length; j++)
                {
                    if (ResultArr[i].number == _credibility_arr[j])
                    {
                        if (ResultArr[i].answer == false)
                        {
                            promResult++;
                        }
                    }
                }
            }

            Credibility = promResult;
            if (promResult > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void _func_Adaptive_abilities(ref int adaptiveResult)
        {
            int promResult = 0;
            _func_Intermediate_calculation_result(ref promResult, _adaptive_abilities_key_true_arr,
                _adaptive_abilities_key_false_arr);
            Adaptive = promResult;
           if (promResult > 61)
            {
                adaptiveResult = 1;
            }
            else if (promResult > 50 && promResult < 62)
            {
                adaptiveResult = 2;
            }
            else if (promResult > 39 && promResult < 51)
            {
                adaptiveResult = 3;
            }
            else if (promResult > 32 && promResult < 40)
            {
                adaptiveResult = 4;
            }
            else if (promResult > 27 && promResult < 33)
            {
                adaptiveResult = 5;
            }
            else if (promResult > 21 && promResult < 28)
            {
                adaptiveResult = 6;
            }
            else if (promResult > 15 && promResult < 22)
            {
                adaptiveResult = 7;
            }
            else if (promResult > 10 && promResult < 16)
            {
                adaptiveResult = 8;
            }
            else if (promResult > 5 && promResult < 11)
            {
                adaptiveResult = 9;
            }
            else if (promResult > 0 && promResult < 6)
            {
                adaptiveResult = 10;
            }
            stan_Adaptive = adaptiveResult;
        }

        private void _func_Neuropsychological_steadiness(ref int neuropsychologicalResult)
        {
            int promResult = 0;
            _func_Intermediate_calculation_result(ref promResult, _neuropsychological_steadiness_key_true_arr,
                _neuropsychological_steadiness_key_false_arr);
            Neuropsychological = promResult;
            if (promResult > 45)
            {
                neuropsychologicalResult = 1;
            }
            else if (promResult > 38 && promResult < 46)
            {
                neuropsychologicalResult = 2;
            }
            else if (promResult > 29 && promResult < 38)
            {
                neuropsychologicalResult = 3;
            }
            else if (promResult > 21 && promResult < 30)
            {
                neuropsychologicalResult = 4;
            }
            else if (promResult > 15 && promResult < 22)
            {
                neuropsychologicalResult = 5;
            }
            else if (promResult > 12 && promResult < 16)
            {
                neuropsychologicalResult = 6;
            }
            else if (promResult > 8 && promResult < 13)
            {
                neuropsychologicalResult = 7;
            }
            else if (promResult > 5 && promResult < 9)
            {
                neuropsychologicalResult = 8;
            }
            else if (promResult > 3 && promResult < 6)
            {
                neuropsychologicalResult = 9;
            }
            else if (promResult > -1 && promResult < 4)
            {
                neuropsychologicalResult = 10;
            }

            stan_Neuropsychological = neuropsychologicalResult;
        }

        private void _func_Communication_features(ref int communicationResult)
        {
            int promResult = 0;
            _func_Intermediate_calculation_result(ref promResult, _communication_features_key_true_arr,
                _communication_features_key_false_arr);
            Communication = promResult;
            if (promResult > 26 && promResult < 32)
            {
                communicationResult = 1;
            }
            else if (promResult > 21 && promResult < 27)
            {
                communicationResult = 2;
            }
            else if (promResult > 16 && promResult < 22)
            {
                communicationResult = 3;
            }
            else if (promResult > 12 && promResult < 17)
            {
                communicationResult = 4;
            }
            else if (promResult > 9 && promResult < 13)
            {
                communicationResult = 5;
            }
            else if (promResult > 6 && promResult < 10)
            {
                communicationResult = 6;
            }
            else if (promResult > 4 && promResult < 7)
            {
                communicationResult = 7;
            }
            else if (promResult > 2 && promResult < 5)
            {
                communicationResult = 8;
            }
            else if (promResult > 0 && promResult < 3)
            {
                communicationResult = 9;
            }
            else if (promResult == 0)
            {
                communicationResult = 10;
            }

            stan_Communication = communicationResult;
        }

        private void _func_Moral_normativity(ref int moralNormativityResult)
        {
            int promResult = 0;
            _func_Intermediate_calculation_result(ref promResult, _moral_normativity_key_true_arr,
                _moral_normativity_key_false_arr);
            Moral_normativity = promResult;
            if (promResult > 17)
            {
                moralNormativityResult = 1;
            }
            else if (promResult > 14 && promResult < 18)
            {
                moralNormativityResult = 2;
            }
            else if (promResult > 11 && promResult < 15)
            {
                moralNormativityResult = 3;
            }
            else if (promResult > 9 && promResult < 12)
            {
                moralNormativityResult = 4;
            }
            else if (promResult > 6 && promResult < 10)
            {
                moralNormativityResult = 5;
            }
            else if (promResult > 4 && promResult < 7)
            {
                moralNormativityResult = 6;
            }
            else if (promResult > 2 && promResult < 5)
            {
                moralNormativityResult = 7;
            }
            else if (promResult == 2)
            {
                moralNormativityResult = 8;
            }
            else if (promResult == 1)
            {
                moralNormativityResult = 9;
            }
            else if (promResult == 0)
            {
                moralNormativityResult = 10;
            }

            stan_Moral_normativity = moralNormativityResult;
        }

        private void _func_Suicide_risk(ref int suicideRiskResult)
        {
            int promResult = 0;
            _func_Intermediate_calculation_result(ref promResult, _suicide_risk_key_true_arr,
                _suicide_risk_key_false_arr);
            Suicide_risk = promResult;
            if (promResult > 10)
            {
                suicideRiskResult = 1;
            }
            else if (promResult > 8 && promResult < 11)
            {
                suicideRiskResult = 2;
            }
            else if (promResult == 8)
            {
                suicideRiskResult = 3;
            }
            else if (promResult > 5 && promResult < 8)
            {
                suicideRiskResult = 4;
            }
            else if (promResult > 3 && promResult < 6)
            {
                suicideRiskResult = 5;
            }
            else if (promResult > 1 && promResult < 4)
            {
                suicideRiskResult = 6;
            }
            else if (promResult == 1)
            {
                suicideRiskResult = 7;
            }
            else if (promResult == 0)
            {
                suicideRiskResult = 8;
            }

            stan_Suicide_risk = suicideRiskResult;
        }

        public void func_Interpretation_Adaptive_abilities(ref string headerText, ref string textMessage)
        {
            int adaptiveResult = 0;
            _func_Adaptive_abilities(ref adaptiveResult);
            if (adaptiveResult > 7 && adaptiveResult < 11)
            {
                headerText = "Группа высокой адаптации";
                textMessage = "Лица этих групп очень легко адаптируются к новым условиям деятельности, адекватно " +
                               "ориентируются в сложных ситуациях, быстро вырабатывают стратегию своего поведения. \n" +
                               "Как правило, не конфликтны, обладают высокой НПУ. \n";
            }
            else if (adaptiveResult > 5 && adaptiveResult < 8)
            {
                headerText = "Группа нормальной адаптации";
                textMessage = "Лица этих групп достаточно легко адаптируются к новым условиям деятельности, " +
                               "адекватно ориентируются в сложных ситуациях, достаточно быстро вырабатывают " +
                               "стратегию своего поведения. Как правило, не конфликтны, обладают высокой НПУ. \n";
            }
            else if (adaptiveResult > 3 && adaptiveResult < 6)
            {
                headerText = "Группа удовлетворительной адаптации";
                textMessage = "Большинство лиц этой группы обладают признаками различных акцентуаций, " +
                               "которые в обычных ситуациях частично компенсированы, но могут проявляться " +
                               "при смене деятельности. Эти лица, как правило, обладают невысокой НПУ. " +
                               "Возможны асоциальные срывы, проявления агрессивности и конфликтности. \n" +
                               "Требуют постоянного контроля.";
            }
            else if (adaptiveResult > 0 && adaptiveResult < 4)
            {
                headerText = "Группа низкой адаптации";
                textMessage = "Лица этой группы обладают явными признаками акцентуаций характера и " +
                               "некоторыми признаками психопатий. Возможны нервно-психические срывы. " +
                               "Обладают низкой НПУ, конфликтны, могут допускать асоциальные поступки. " +
                               "Требуют консультации психолога и в случае необходимости по рекомендации " +
                               "психолога консультация врача-невропатолога.";
            }
        }

        public void func_Interpretation_Neuropsychological_steadiness(ref string headerText, ref string textMessage)
        {
            int result = 0;
            _func_Neuropsychological_steadiness(ref result);
            headerText = "Нервно-психологическая устойчивость.";
            if (result > 0 && result < 4)
            {
                textMessage = "Низкий уровень поведенческой регуляции, склонность к нервно-психическим срывам, " +
                               "отсутствие адекватной самооценки и адекватного восприятия действительности. " +
                               "К несению караульной службы не допускаются.";
            }
            else if (result > 3 && result < 8)
            {
                textMessage = "Средний уровень поведенческой регуляции";
            }
            else if (result > 7 && result < 11)
            {
                textMessage = "Высокий уровень НПУ и поведенческой регуляции, высокая адекватная самооценка, " +
                               "адекватное восприятие действительности.";
            }
        }

        public void func_Interpretation_Communication_features(ref string headerText, ref string textMessage)
        {
            int result = 0;
            _func_Communication_features(ref result);
            headerText = "Коммуникативные особенности.";
            if (result > 0 && result < 4)
            {
                textMessage = "Низкий уровень коммуникативных способностей, затруднение в установлении контактов " +
                               "с окружающими, проявление агрессивности, повышенная конфликтность.";
            }
            else if (result > 3 && result < 8)
            {
                textMessage = "Средний уровень коммуникативных способностей";
            }
            else if (result > 7 && result < 11)
            {
                textMessage = "Высокий уровень коммуникативных способностей, легко устанавливает контакты с " +
                               "окружающими, не конфликтен.";
            }
        }

        public void func_Interpretation_Moral_normativity(ref string headerText, ref string textMessage)
        {
            int result = 0;
            _func_Moral_normativity(ref result);
            headerText = "Моральная нормативность.";
            if (result > 0 && result < 4)
            {
                textMessage = "Не может адекватно оценивать свое место и роль в коллективе, не стремится соблюдать " +
                               "общепринятые нормы поведения.";
            }
            else if (result > 3 && result < 8)
            {
                textMessage = "Средний уровень моральных качеств";
            }
            else if (result > 7 && result < 11)
            {
                textMessage = "Адекватно оценивает свою роль в коллективе, ориентируется на соблюдение общепринятых " +
                               "норм поведения.";
            }
        }

        public void func_Interpretation_Suicide_risk(ref string headerText, ref string textMessage)
        {
            int result = 0;
            _func_Suicide_risk(ref result);
            headerText = "Суицидальный риск.";
            if (result > 0 && result < 4)
            {
                textMessage = "Характерно стремление к уединению, пессимистическая оценка своих личностных " +
                               "качеств и результатов деятельности, безразличие ко всему происходящему, часто " +
                               "возникающие мысли суицидального характера.";
            }
            else if (result > 3 && result < 8)
            {
                textMessage = "Средний уровень риска суицида";
            }
            else if (result > 7 && result < 11)
            {
                textMessage = "Характеризуется оптимистичностью, жизнерадостностью, находит новизну в " +
                               "повседневных делах.";
            }
        }
    }
}