using PTestLib;
using PTestLib.Utils;

var json = File.ReadAllText("Questions.json");
var jsonClient = File.ReadAllText("ClientAnswers.json");


ListQuestions questions = JsonSerialize.GetQuestions(json);
ListQuestions clientAnswers = JsonSerialize.GetQuestions(jsonClient);

AizenecTest aizenecTest = new AizenecTest(questions);


aizenecTest.GetStan(clientAnswers);

Console.WriteLine("Dostovernost\t"+aizenecTest.dostovernostBal);
Console.WriteLine("Extraversia\t"+aizenecTest.extraversiaBal);
Console.WriteLine("Neirotizm\t"+aizenecTest.neirotizmBal);

Console.WriteLine("----------------------------------------------");
aizenecTest.GetInterpretation();


