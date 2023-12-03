

using System.Text.RegularExpressions;

string input = File.ReadAllText("input.txt");

string[] lines = input.Split("\n");
List<Line> textLines = new List<Line>();
int partNumberSum = 0;

foreach (string l in lines)
{
    Line line = new Line();
    line.LineNumber = Array.IndexOf(lines, l) + 1;
    string pattern = @"([0-9])\w+";
    MatchCollection numbers = Regex.Matches(l, pattern);
    
    // Find all the numbers in the line
    foreach (Match m in numbers)
    {
        NumberMatch nm = new NumberMatch();
        nm.Number = m.Value;
        nm.Index = l.IndexOf(m.Value);
        nm.Length = m.Value.Length;
        nm.LineNumber = Array.IndexOf(lines, l) + 1;
        line.Numbers.Add(nm);
    }

    // Find all the special characters in the line
    for (int i = 0; i < l.Length; i++)
    {
        if (l[i] == '#' || l[i] == '@' || l[i] == '/' || l[i] == '+' || l[i] == '$' || l[i] == '*' || l[i] == '%' || l[i] == '-' || l[i] == '&' || l[i] == '=')
        {
            SpecialChar sc = new SpecialChar();
            sc.Index = i;
            line.SpecialChars.Add(sc);
        }
    }

    textLines.Add(line);
}

foreach (Line l in textLines)
{
    Line next = new Line();
    Line previous = new Line();
    if (l.LineNumber > 1)
    {
        previous = textLines.First(nl => nl.LineNumber == l.LineNumber - 1);
    }
    if (l.LineNumber < textLines.Count)
    {
        next = textLines.First(nl => nl.LineNumber == l.LineNumber + 1);
    }

    foreach (NumberMatch nm in l.Numbers)
    {
        List<SpecialChar> scSL = l.SpecialChars.Where(sc => sc.Index >= nm.Index - 1 && sc.Index <= nm.Index + nm.Length).ToList(); // Special chars in the same line
        List<SpecialChar> scNL = next.SpecialChars.Where(sc => sc.Index >= nm.Index - 1 && sc.Index <= nm.Index + nm.Length).ToList(); // Special chars in the next line
        List<SpecialChar> scPL = previous.SpecialChars.Where(sc => sc.Index >= nm.Index - 1 && sc.Index <= nm.Index + nm.Length).ToList(); // Special chars in the previous line
        if (scSL.Count > 0 || scNL.Count > 0 || scPL.Count > 0)
        {
            Console.WriteLine($"Line {nm.LineNumber} - {nm.Number}");
            partNumberSum += int.Parse(nm.Number);
        }
    }
}

Console.WriteLine($"Part 1: {partNumberSum}");

class Line
{
    public int LineNumber { get; set; } = 0;
    public List<NumberMatch> Numbers { get; set; } = new List<NumberMatch>();
    public List<SpecialChar> SpecialChars { get; set; } = new List<SpecialChar>(); 
    public List<NumberMatch> PartNumbers { get; set; } = new List<NumberMatch>();
}

class NumberMatch {
    public string Number { get; set; } = string.Empty;
    public int Index { get; set; } = 0;
    public int Length { get; set; } = 0;
    public int LineNumber { get; set; } = 0;    
    public bool AdjacentChars { get; set; } = false;
}

class SpecialChar
{
    public int Index { get; set; } = 0;
}
