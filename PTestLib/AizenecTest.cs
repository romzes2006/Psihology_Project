using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTestLib
{
    public sealed class AizenecTest : StanBase
    {
        public ListQuestions Questions;
        public ListInterpretations Interpritations;
        private byte[] _dostovernost = new byte[] { 6, 24, 36, 12, 18, 30, 42, 48, 54 };
        private byte[] _extraversia = new byte[] { 1, 3, 8, 10, 13, 17, 22, 25, 27, 39, 44, 46, 49, 53, 56, 5, 15, 20, 29, 32, 34, 37, 41, 51 };
        private byte[] _neirotizm = new byte[] { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23, 26, 28, 31, 33, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57 };

        public byte dostovernostBal = 0;
        public byte extraversiaBal = 0;
        public byte neirotizmBal = 0;

        //private byte[] IscrennostYes = new byte[] { 6, 24, 36 };
        //private byte[] IscrennostNo = new byte[] { 12, 18, 30, 42, 48, 54 };

        //private byte[] ExtraversiaYes = new byte[] { 1, 3, 8, 10, 13, 17, 22, 25, 27, 39, 44, 46, 49, 53, 56 };
        //private byte[] ExtraversiaNo = new byte[] { 5, 15, 20, 29, 32, 34, 37, 41, 51 };

        //private byte[] Ystoychivost = new byte[] { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23, 26, 28, 31, 33, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57 };

        //Искренность:
        //• Да — 6, 24, 36.
        //• Нет — 12, 18, 30, 42, 48, 54.
        //Если по искренности вы набрали:
        //• 7-9 баллов,то вы отвечали не искренне.Пройдите тест заново 
        //• 4-6 баллов,то где-то вы приврали и, вероятно, результат будет не совсем достоверным
        //• 0-3 баллов,то вы просто сама искренность

        // Экстраверсия:
        //• Да — 1, 3, 8, 10, 13, 17, 22, 25, 27, 39, 44, 46, 49, 53, 56.
        //• Нет — 5, 15, 20, 29, 32, 34, 37, 41, 51.

        // Устойчивость:
        //• Да — 2, 4, 7, 9, 11, 14, 16, 19, 21, 23, 26, 28, 31, 33, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57.
        public AizenecTest(ListQuestions question)
        {
            Questions = question;
        }

        public List<int> CorrectAnswers(ListQuestions clientAnswers)
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
                        if (anCl.Content == answer.Content)
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

            for (int i = 0; i < _dostovernost.Length; ++i)
            {
                if (correctAnswers.Contains(_dostovernost[i]))
                {
                    ++dostovernostBal;
                }
            }

            if (dostovernostBal > 7)// 7 - 9 баллов
            {
                throw new Exception("Достоверность больше 7");
            }

            for (int i = 0; i < _extraversia.Length; ++i)
            {
                if (correctAnswers.Contains(_extraversia[i]))
                {
                    ++extraversiaBal;
                }
            }

            for (int i = 0; i < _neirotizm.Length; ++i)
            {
                if (correctAnswers.Contains(_neirotizm[i]))
                {
                    ++neirotizmBal;
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
