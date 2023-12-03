
// Read input.txt into a string array
System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
string input = file.ReadToEnd();
file.Close();

string[] lines = input.Split('\n');
List<Game> games = new List<Game>();

foreach (string line in lines) {
	Game game = new Game();

	// Find the Id of the game
	game.Id = int.Parse(line.Split(":")[0].Replace("Game ", ""));
	Console.WriteLine(game.Id);
}

class Game {
	public int Id { get; set; }
	public Match Match1 { get; set; } = new Match();
	public Match Match2 { get; set; } = new Match();
	public Match Match3 { get; set; } = new Match();
}

class Match {
	public int Red { get; set; }
	public int Blue { get; set; }
	public int Green { get; set; }
}