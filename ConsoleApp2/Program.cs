using PTestLib;
using PTestLib.Utils;


// Aizenec
//var json = File.ReadAllText("AizenecTest.json");
//var jsonClient = File.ReadAllText("ClientAnswers.json");


//ListQuestions questions = JsonSerialize.GetQuestions(json);
//ListQuestions clientAnswers = JsonSerialize.GetQuestions(jsonClient);

//AizenecTest aizenecTest = new AizenecTest(questions);


//aizenecTest.GetStan(clientAnswers);

//Console.WriteLine("Dostovernost\t"+aizenecTest.dostovernostBal);
//Console.WriteLine("Extraversia\t"+aizenecTest.extraversiaBal);
//Console.WriteLine("Neirotizm\t"+aizenecTest.neirotizmBal);

//Console.WriteLine("----------------------------------------------");
//aizenecTest.GetInterpretation();



// NPY
var jsonN = File.ReadAllText("NpyTest.json");

ListQuestions questions = JsonSerialize.GetQuestions(jsonN);

NpyTest npyTest = new NpyTest(questions);

npyTest.GetStan(questions);

Console.WriteLine("reliabilityScore\t" + npyTest.reliabilityScore);
Console.WriteLine("adaptiveAbilitiesScore\t" + npyTest.adaptiveAbilitiesScore);
Console.WriteLine("neuropsychicStabilityScore\t" + npyTest.neuropsychicStabilityScore);
Console.WriteLine("communicationFeaturesScore\t" + npyTest.communicationFeaturesScore);
Console.WriteLine("moralNormativityScore\t" + npyTest.moralNormativityScore);
Console.WriteLine("suicidalRiskScore\t" + npyTest.suicidalRiskScore);




