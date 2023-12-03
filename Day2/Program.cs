
System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
string input = file.ReadToEnd();
file.Close();

string[] lines = input.Split('\n');
List<Game> games = new List<Game>();
int max_red = 12;
int max_green = 13;
int max_blue = 14;

int idSum = 0;

foreach (string line in lines) {
	Game game = new Game();

	string[] data = line.Split(":");

	game.Id = int.Parse(data[0].Replace("Game ", ""));

	string[] matches = data[1].Split(";");
	foreach (string m in matches)
	{
		Match match = new Match();
		List<string> match_data = m.Split(",").ToList<string>();
		for (var i = 0; i < match_data.Count; i++)
		{
			string d = match_data[i];
			if (d.Contains(" red"))
			{
				match.Red = int.Parse(d.Replace(" red", ""));
			}
			else if (d.Contains(" blue"))
			{
				match.Blue = int.Parse(d.Replace(" blue", ""));
			}
			else if (d.Contains(" green"))
			{
				match.Green = int.Parse(d.Replace(" green", ""));
			}
		}
		game.Matches.Add(match);
	}
	games.Add(game);
}

List<Game> possible = new List<Game>();
foreach (Game g in games)
{
    bool isPossible = true;
    foreach (Match m in g.Matches)
	{
        if (m.Red > max_red || m.Blue > max_blue || m.Green > max_green)
		{
            isPossible = false;
            break;
        }
    }
    if (isPossible)
	{
        possible.Add(g);
    }
}

foreach (Game g in possible)
{
	idSum += g.Id;
	Console.WriteLine(g.Id);
}

Console.WriteLine(idSum);

class Game {
	public int Id { get; set; }
	public List<Match> Matches { get; set; } = new List<Match>();
}

class Match {
	public int Red { get; set; }
	public int Blue { get; set; }
	public int Green { get; set; }
}