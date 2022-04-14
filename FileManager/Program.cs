using FileManager;

TestLoader loader = new TestLoader();


var questionsJson = loader.GetFileString("1.json");
var interpretationJson = loader.GetFileString("2.json");

var questions = loader.CreateQuestion(questionsJson);
var interpretations = loader.CreateInterpretations(interpretationJson);

Console.WriteLine("Все работает"); 


