// Open the input.txt file and read the contents into a string variable.


using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

List<string> lookFor = new List<string>(){ "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; 
List<MatchyMatchy> matchyMatchies = new List<MatchyMatchy>();
System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
string line = file.ReadToEnd();
file.Close();

string[] lines = line.Split('\n');
int total = 0;

foreach (string l in lines)
{
    matchyMatchies.Clear();
    MatchyMatchy matchy = new MatchyMatchy();

    for (var i = 0; i < l.Length; i++)
    {
        foreach (string target in lookFor)
        {
            // If the string begins with the target in lookfor, add it to the matchyMatchies
            if (l.Substring(i).StartsWith(target))
            {
                matchy = new MatchyMatchy();
                matchy.Index = i;
                matchy.Value = GetNumber(target);
                matchyMatchies.Add(matchy);
            }
        }
    }

    // Sort the matchyMatchies by index
    matchyMatchies = matchyMatchies.OrderBy(m => m.Index).ToList();
    List<string> thisLine = matchyMatchies.Select(m => m.Value).ToList();
    string thisLineString = string.Join("", thisLine);

    string firstNumber = thisLineString.Substring(0, 1);
    string lastNumber = thisLineString.Substring(thisLineString.Length - 1, 1);
    string aggregate = firstNumber + lastNumber;
    total += int.Parse(aggregate);
}

Console.WriteLine(total);

string GetNumber(string input)
{
    int result = 0;
    try
    {
        result = int.Parse(input);
    } catch
    {
        switch (input)
        {
            case "one":
                result = 1;
                break;
            case "two":
                result = 2;
                break;
            case "three":
                result = 3;
                break;
            case "four":
                result = 4;
                break;
            case "five":
            result = 5;
                break;
            case "six":
                result = 6;
                break;
            case "seven":
                result = 7;
                break;
            case "eight":
                result = 8;
                break;
            case "nine":
                result = 9;
                break;
        }
    }
    return result.ToString();
}

class MatchyMatchy
{
    public int Index { get; set; }
    public string Value { get; set; }
}


