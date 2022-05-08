using PTestLib;
using PTestLib.Utils;

var json = File.ReadAllText("Questions.json");

ListQuestions questions = JsonSerialize.GetQuestions(json);

AizenecTest aizenecTest = new AizenecTest(questions);

aizenecTest.GetStan(questions);

Console.WriteLine("Dostovernost\t"+aizenecTest.dostovernostBal);
Console.WriteLine("Extraversia\t"+aizenecTest.extraversiaBal);
Console.WriteLine("Neirotizm\t"+aizenecTest.neirotizmBal);


