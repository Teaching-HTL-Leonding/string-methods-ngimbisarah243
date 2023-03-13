Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("String Methods");
Console.WriteLine("**************************");
Console.WriteLine();
Console.ResetColor();

Console.Write("Char for 'IndexOf' and 'Contains':    ");
char indexOf = DoWhileCharFalse();
Console.Write("String:  ");
string stringInput = Console.ReadLine()!;
Console.WriteLine();

Console.WriteLine($"IndexOf(\"{stringInput}\", '{indexOf}')            =   {IndexOf(stringInput, indexOf)} ");
Console.WriteLine($"LastIndexOf(\"{stringInput}\", '{indexOf}')        =   {LastIndexOf(stringInput, indexOf)} ");
Console.WriteLine($"Contains(\"{stringInput}\", '{indexOf}')           =   {Contains(stringInput, indexOf)}");
Console.WriteLine();

Console.Write("Start index for 'Remove':                     ");
int startIndex = DoWhileFalse();
Console.Write("Int for number of deleted chars for 'Remove': ");
int numberForRemove = DoWhileFalse();
Console.Write("String for 'Remove':  ");
stringInput = Console.ReadLine()!;
Console.WriteLine($"Remove(\"{stringInput}\"), {startIndex}, {numberForRemove})       = {Remove(stringInput, startIndex, numberForRemove)}");
Console.WriteLine();

Console.Write("Char for 'Trim':      ");
char trim = DoWhileCharFalse();
Console.Write("String for 'Trim':  ");
stringInput = Console.ReadLine()!;
Console.WriteLine($"TrimStart(\"{stringInput}\", {trim})               =   {TrimStart(stringInput, trim)}");
Console.WriteLine($"TrimEnd(\"{stringInput}\", {trim})                 =   {TrimEnd(stringInput, trim)}");
Console.WriteLine($"Trim(\"{stringInput}\", {trim})                    =   {Trim(stringInput, trim)}");
Console.WriteLine();

Console.Write("Int for start index for 'Substring':  ");
startIndex = DoWhileFalse();

Console.Write("Int for end index for 'Substring':  ");
int endIndex= DoWhileFalse();

Console.WriteLine("String for 'Substring':  ");
stringInput = Console.ReadLine()!;
Console.WriteLine($"Substring(\"{stringInput}\", {startIndex}, {endIndex})     =  {Substring(stringInput, startIndex, endIndex)}");

bool Contains(string input, char character)
{
    while (input != string.Empty)
    {
        if (input[0] == character) { return true; }
        input = input.Substring(1);
    }
    return false;
}
int IndexOf(string input, char character)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == character)
        {
            return i;
        }
    }
    return -1;
}
int LastIndexOf(string input, char character)
{
    int i = input.Length - 1;

    while (i >= 0)
    {

        if (input[i] == character)
        {
            return i;
        }

        i--;
    }
    return -1;
}
string Substring(string input, int startIndex, int endIndex)
{
    string output = string.Empty;
    while (startIndex <= endIndex)
    {
        output += input[startIndex];
        startIndex++;

        if (startIndex > input.Length && output[startIndex] == ' ') { break; }
    }
    return output;
}
string Remove(string input, int startIndex, int numberOfDeletedChars)
{
    string output = string.Empty;
    int i = 0;
    int counter = 0;

    if (numberOfDeletedChars > input.Length) { numberOfDeletedChars = input.Length - startIndex; }

    while (i < input.Length)
    {
        if (i == startIndex)
        {
            while (counter < numberOfDeletedChars)
            {
                counter++;
                i++;
            }
        }
        else
        {
            output += input[i];
            i++;
        }
    }

    return output;
}
string Trim(string input, char trimCharacter)
{
    if (Contains(input, trimCharacter) == false) { return input; }

    string output = string.Empty;
    int i = 0;

    while (i < input.Length)
    {
        if (input[i] == trimCharacter) { i++; }
        else { output += input[i]; i++; }
    }

    return output;
}

string TrimStart(string input, char trimCharacter)
{
    if (Contains(input, trimCharacter) == false) { return input; }

    string output = input;

    while (output[0] == trimCharacter)
    {
        output = Substring(output, 1, output.Length - 1);
    }

    return output;
}
string TrimEnd(string input, char trimCharacter)
{
    if (Contains(input, trimCharacter) == false) { return input; }

    string output = string.Empty;
    int i = input.Length - 1;

    while (input[i] == trimCharacter) { i--; }

    return Remove(input, i + 1, input.Length - i);
}

int DoWhileFalse()
{
    bool isNumber = int.TryParse(Console.ReadLine(), out int index);

    if (isNumber == true) { return index; }

    Console.ForegroundColor = ConsoleColor.Red;

    while (isNumber == false)
    {
        Console.WriteLine("invalid input!! Try again...");
        Console.ResetColor();
        isNumber = int.TryParse(Console.ReadLine(), out index);
    }

    return index;

}
char DoWhileCharFalse()
{
    bool isOneChar = char.TryParse(Console.ReadLine(), out char character);

    if (isOneChar == true) { return character; }

    Console.ForegroundColor = ConsoleColor.Red;

    while (isOneChar == false)
    {
        Console.WriteLine("invalid input!! Try again...");
        Console.ResetColor();

        isOneChar = char.TryParse(Console.ReadLine(), out  character);
    }

    return character;

}