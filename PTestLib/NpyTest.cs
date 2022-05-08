using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTestLib
{
    public class NpyTest : StanBase
    {
        public ListQuestions Questions;
        public ListInterpretations Interpritations;
        private byte[] reliability = new byte[] { 1, 10, 19, 31, 51, 69, 78, 92, 101, 116, 128, 138, 148 };
        private byte[] adaptiveAbilities = new byte[] {4,6,7,8,9,11,12,14,15,16,17,18,20,21,22,
            24,27,28,29,30,33,36,37,39,40,41,42,43,
            46,47,50,56,57, 59, 59, 60, 61, 63, 64, 65,67,68,70,71,72,73,75, 77, 79, 80, 81, 82,83,84,86,88,89,90,91,93, 94, 95, 96, 98,99,102,103,104,16,108,109,110,111,
            112,113,114,115,117,118,119, 120, 121, 122,123, 124,125,126, 127,129, 131, 133,135,136,137,139,141,142,143, 145,
            146,149,150,151,152,153,154,155, 156,
            157,158,161, 162,164,165,2,3,5,13,23,25,26,32,34,35,38,44,45,48,49,52, 53, 54, 55, 58, 62, 66, 74, 76,85,87, 100, 105, 107, 130, 132, 134, 140, 144, 147, 159,160,163
                };
        private byte[] neuropsychicStability = new byte[] {4, 6, 7, 8, 11, 12, 15, 16, 17, 18, 20, 21, 28, 29, 30, 37, 39, 40, 41, 47, 57, 60, 63, 65, 67, 68, 70, 71, 73, 75, 80, 82, 83, 84, 86,89,94,95,96,98,102,103,108,109,110, 111,112,113,115,117,118,119,120,122,
        123,124, 127, 129, 131, 135, 136, 139, 143,146,149,153,154, 155, 156, 157, 158,161,162, 2, 3, 5, 23, 25, 32, 38, 44, 45, 49, 52, 53, 54, 55, 58, 62, 66, 87, 105, 132, 134, 140};
        private byte[] communicationFeatures = new byte[] { 9, 24, 27, 33, 43, 46, 61, 64, 81, 88, 90, 99, 104, 106, 114, 121, 126, 133, 142, 151, 152,
        26, 34, 35, 48, 74, 85, 107, 130,144,147,159};

        private byte[] moralNormativity = new byte[] { 14, 22, 36, 42, 50, 56, 59, 72, 77, 79, 91, 93, 125, 141, 145, 150, 164, 165, 13, 76, 97, 100, 160, 163 };
        private byte[] suicidalRisk = new byte[] { 4, 8, 10, 28, 29, 39, 41, 47, 70, 84, 115, 119, 124, 136, 137, 149, 154, 155, 35, 105 };

        public byte reliabilityScore = 0;
        public byte adaptiveAbilitiesScore = 0;
        public byte neuropsychicStabilityScore = 0;
        public byte communicationFeaturesScore = 0;
        public byte moralNormativityScore = 0;
        public byte suicidalRiskScore = 0;

        public NpyTest(ListQuestions questions)
        {
            Questions = questions;
        }

        private List<int> CorrectAnswers(ListQuestions clientAnswers)
        {
            List<int> correctAnswers = new List<int>();
            for (int i = 0; i < clientAnswers.Questions.Count; ++i)
            {
                var answers = Questions.Get(i).Answers;
                var answersClient = clientAnswers.Get(i).Answers;

                // Проверка ответов клиента с првильными ответами
                foreach (var answer in answers)
                {
                    foreach (var anCl in answersClient)
                    {
                        if (anCl.Content.ToString().Contains(answer.Content.ToString()))
                        {
                            correctAnswers.Add(Questions.Get(i).Id);
                        }
                    }
                }
            }
            return correctAnswers;
        }


        public override void GetStan(ListQuestions clientAnswers)
        {
            List<int> correctAnswers = CorrectAnswers(clientAnswers);

            for (int i = 0; i < reliability.Length; ++i)
            {
                if (correctAnswers.Contains(reliability[i]))
                {
                    ++reliabilityScore;
                }
            }

            for (int i = 0; i < adaptiveAbilities.Length; ++i)
            {
                if (correctAnswers.Contains(adaptiveAbilities[i]))
                {
                    ++adaptiveAbilitiesScore;
                }
            }

            for (int i = 0; i < neuropsychicStability.Length; ++i)
            {
                if (correctAnswers.Contains(neuropsychicStability[i]))
                {
                    ++neuropsychicStabilityScore;
                }
            }
            
            for (int i = 0; i < communicationFeatures.Length; ++i)
            {
                if (correctAnswers.Contains(communicationFeatures[i]))
                {
                    ++communicationFeaturesScore;
                }
            }

            for (int i = 0; i < moralNormativity.Length; ++i)
            {
                if (correctAnswers.Contains(moralNormativity[i]))
                {
                    ++moralNormativityScore;
                }
            } 
            
            
            for (int i = 0; i < suicidalRisk.Length; ++i)
            {
                if (correctAnswers.Contains(suicidalRisk[i]))
                {
                    ++suicidalRiskScore;
                }
            }
        }

        public override void GetObject()
        {
            throw new NotImplementedException();
        }

        public override void GetInterpretation()
        {
            throw new NotImplementedException();
        }

        public override void SetInterpretation()
        {
            throw new NotImplementedException();
        }
    }
}
