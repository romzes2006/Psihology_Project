using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PTestLib
{
    public class AizenecTest : StanBase
    {
        public Dictionary<int,bool> Questions;
        private byte[] _iscrennost = new byte[] { 6, 24, 36, 12, 18, 30, 42, 48, 54 };
        private byte[] _extraversia = new byte[] { 1, 3, 8, 10, 13, 17, 22, 25, 27, 39, 44, 46, 49, 53, 56, 5, 15, 20, 29, 32, 34, 37, 41, 51 };
        private byte[] _ystoychivost = new byte[] { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23, 26, 28, 31, 33, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57 };

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
        public AizenecTest()
        {
            Questions = new Dictionary<int, bool>();
        }

        public override void GetStan()
        {
            throw new NotImplementedException();
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
