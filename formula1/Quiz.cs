

namespace quiz
{
	public class Quiz{

		public bool quizgame()
		{
		Random random = new Random();

		var questions = new List<List<string>>
		{
			new List<string> { "F1 Quiz: Who won the 2021 Formula 1 World Championship?", "1. Lewis Hamilton\n2. Max Verstappen\n3. Valtteri Bottas\n4. Sebastian Vettel", "2", "2. Max Verstappen" },
			new List<string> { "F1 Quiz: What is the name of the current Formula 1 CEO?", "1. Stefano Domenicali\n2. Toto Wolff\n3. Christian Horner\n4. Ross Brawn", "1" },
			new List<string> { "F1 Quiz: Which driver holds the record for the most Grand Prix wins in F1 history?", "1. Lewis Hamilton\n2. Michael Schumacher\n3. Ayrton Senna\n4. Sebastian Vettel", "1", "1. Stefano Domenicali" },
			new List<string> { "F1 Quiz: What is the name of the current Formula 1 World Champion team?", "1. Mercedes\n2. Red Bull\n3. Ferrari\n4. McLaren", "2", "2. Red Bull" },
			new List<string> { "F1 Quiz: what does DRS stand for?", "1. Drag Reduction System\n2. Drag Reduction Setup\n3. Drag Reduction Speed\n4. Drag Reduction Sensation", "1", "1. Drag Reduction System" },
			new List<string> { "F1 Quiz: What is the name of the current Formula 1 tyre supplier?", "1. Michelin\n2. Pirelli\n3. Bridgestone\n4. Goodyear", "2", "2. Pirelli" },
			new List<string> { "F1 Quiz: Which Formula 1 team has the most Constructors' Championships?", "1. Ferrari\n2. Mercedes\n3. McLaren\n4. Williams", "1", "1. Ferrari" },
			new List<string> { "F1 Quiz: Who became the youngest Formula 1 World Champion in history?", "1. Fernando Alonso\n2. Lewis Hamilton\n3. Max Verstappen\n4. Sebastian Vettel", "4", "4. Sebastian Vettel" },
			new List<string> { "F1 Quiz: Where is the headquarters of the Red Bull Racing Formula 1 team?", "1. Milton Keynes, UK\n2. Maranello, Italy\n3. Brackley, UK\n4. Enstone, UK", "1", "1. Milton Keynes, UK" },
			new List<string> { "F1 Quiz: Which Formula 1 circuit features the famous corner named 'Parabolica'?", "1. Silverstone\n2. Monza\n3. Spa-Francorchamps\n4. Suzuka", "2", "2. Monza" },
			new List<string> { "F1 Quiz: What is the fuel weight limit for a Formula 1 car at the start of the race, as of recent regulations?", "1. 100 kg\n2. 105 kg\n3. 110 kg\n4. 95 kg", "2", "2. 105 kg" },
			new List<string> { "F1 Quiz: In which year did the first Formula 1 night race take place, and where?", "1. 2008, Singapore\n2. 2006, Bahrain\n3. 2010, Abu Dhabi\n4. 2012, Qatar", "1", "1. 2008, Singapore" },
			new List<string> { "F1 Quiz: What part of a Formula 1 car is referred to as the 'halo'?", "1. The front wing\n2. The cockpit protection system\n3. The rear diffuser\n4. The steering wheel", "2", "2. The cockpit protection system" },
			new List<string> { "F1 Quiz: Who made the famous radio comment 'Leave me alone, I know what I'm doing' during a race?", "1. Fernando Alonso\n2. Kimi Räikkönen\n3. Sebastian Vettel\n4. Lewis Hamilton", "2", "2. Kimi Räikkönen" },
			new List<string> { "F1 Quiz: Which Formula 1 team is based in Brackley, UK?", "1. Red Bull Racing\n2. McLaren\n3. Mercedes-AMG Petronas\n4. Aston Martin", "3", "3. Mercedes-AMG Petronas" },
			new List<string> { "F1 Quiz: Which circuit is known as 'The Cathedral of Speed'?", "1. Monza\n2. Silverstone\n3. Spa-Francorchamps\n4. Suzuk", "1", "1. Monza" },
			new List<string> { "F1 Quiz: What does the term undercut refer to in Formula 1?", "1. A pit stop strategy\n2. A type of tyre compound\n3. A type of aerodynamic device\n4. A type of engine mode", "1", "1. A pit stop strategy" },
			new List<string> { "F1 Quiz: In what year did the first Formula 1 World Championship take place?", "1. 1948\n2. 1950\n3. 1952\n4. 1954", "2", "2. 1950" }
		};

		int quizIndex = random.Next(0,questions.Count);

        System.Console.WriteLine(questions[quizIndex][0]);
        System.Console.WriteLine(questions[quizIndex][1]);

        string answer = Console.ReadLine()?.ToUpper();
        if (answer == questions[quizIndex][2])
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine($"Wrong answer! It was {questions[quizIndex][3]}, you lost the mini game!");
            return false;
        }
		}
	}
}