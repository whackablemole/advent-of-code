
System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
string input = file.ReadToEnd();
file.Close();

string[] lines = input.Split('\n');
List<Game> games = new List<Game>();

int powerSum = 0;

foreach (string line in lines)
{
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
                if (match.Red > game.MinRed)
                {
                    game.MinRed = match.Red;
                }
            }
            else if (d.Contains(" blue"))
            {
                match.Blue = int.Parse(d.Replace(" blue", ""));
                if (match.Blue > game.MinBlue)
                {
                    game.MinBlue = match.Blue;
                }
            }
            else if (d.Contains(" green"))
            {
                match.Green = int.Parse(d.Replace(" green", ""));
                if (match.Green > game.MinGreen)
                {
                    game.MinGreen = match.Green;
                }
            }
        }
        game.Power = (game.MinRed > 0 ? game.MinRed : 1) * (game.MinBlue > 0 ? game.MinBlue : 1) * (game.MinGreen > 0 ? game.MinGreen : 1);
        game.Matches.Add(match);
    }
    games.Add(game);
}

foreach (Game g in games)
{
        powerSum += g.Power;
}

Console.WriteLine(powerSum);

class Game
{
    public int Id { get; set; }
    public List<Match> Matches { get; set; } = new List<Match>();
    public int MinRed { get; set; }
    public int MinBlue { get; set; }
    public int MinGreen { get; set; }
    public int Power { get; set; }
}

class Match
{
    public int Red { get; set; }
    public int Blue { get; set; }
    public int Green { get; set; }
}