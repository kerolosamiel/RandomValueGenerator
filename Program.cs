// Random values generation
using System.Text;
using Random_Values_Generation;

InitializeApplication();

static void InitializeApplication()
{
    // Display a welcome message to the user.
    Console.WriteLine("Welcome to random values generation application :)");
    bool bIsRunning = true;

    // Main loop of the application.
    while (bIsRunning)
    {
        DisplayMessage("Please select option");
        Console.WriteLine("1- Generation random number \n2- Generation random string");

        // Check if the user input is a valid number.
        if (IsValidNumber(out int nSelectOption))
        {
            Console.Clear();

            // Handle the user's selection.
            if (nSelectOption == 1)
            {
                GenerateRandomNumber();
                if (!PromptRetry())
                    bIsRunning = false;
            }
            else if (nSelectOption == 2)
            {
                GenerateRandomString();
                if (!PromptRetry())
                    bIsRunning = false;
            }
            else
            {
                Console.WriteLine("Enter Valid Number :(");

                if (!PromptRetry())
                    bIsRunning = false;
            }
        }
        else
        {
            if (!PromptRetry())
                bIsRunning = false;
        }
    }
}

// Method to display a message to the user.
static void DisplayMessage(string message) => Console.WriteLine($"{message}: ");

// Check if the user input is a valid number.
static bool IsValidNumber(out int number)
{
    bool bIsNumber = int.TryParse(Console.ReadLine(), out number);

    // Clear the console for better readability.
    Console.Clear();
    return bIsNumber;
}

// Prompt the user to try again.
static bool PromptRetry()
{
    Console.WriteLine();
    DisplayMessage("Do you want to try again (Y/N)");
    string? sUserResponse = Console.ReadLine();

    Console.Clear();

    // Check the user's response.
    return IsYesResponse(sUserResponse);
}

// Check if the user response is a "Yes".
static bool IsYesResponse(string? response)
{
    return response switch
    {
        "y" or "Y" or "yes" or "Yes" or "YES" => true,
        _ => false,
    };
}

// Method to generate a random number based on user input.
static void GenerateRandomNumber()
{
    DisplayMessage("Enter Min Value");
    if (!IsValidNumber(out int nMinNumber))
    {
        Console.WriteLine("Enter Valid Number :(");
        return;
    }

    DisplayMessage("Enter Max Value");
    if (!IsValidNumber(out int nMaxNumber))
    {
        Console.WriteLine("Enter Valid Number :(");
        return;
    }

    // Display the generated random number.
    Console.WriteLine($"Random Number: {GetRandomNumber(nMinNumber, nMaxNumber)}");
}

// Method to generate a random number within a specified range.
static int GetRandomNumber(int minValue, int maxValue)
{
    var nRandomValue = new Random();

    try
    {
        // Generate and return a random number between the specified values.
        return nRandomValue.Next(minValue, maxValue);
    }
    catch (Exception)
    {
        Console.WriteLine("The minimum value should be bigger than max value!!");
        return 0;
    }
}

// Placeholder for random string generation method (assuming you'd implement this based on your needs).
static void GenerateRandomString()
{
    // Initialize character sets.
    Constances constances = new();
    string sAvailableCharacters = "";

    // Prompt the user to enter the desired length of the random string.
    DisplayMessage("Enter the length of string");
    if (!IsValidNumber(out int nStringLength))
        return;

    // Ask the user whether to include capital letters.
    if (PromptCharacterSetInclusion("Include capital letters", 1))
        sAvailableCharacters += constances.CapitalLetters;

    // Ask the user whether to include small letters.
    if (PromptCharacterSetInclusion("Include small letters", 2))
        sAvailableCharacters += constances.SmallLetters;

    // Ask the user whether to include numbers.
    if (PromptCharacterSetInclusion("Include numbers", 3))
        sAvailableCharacters += constances.Numbers;

    // Ask the user whether to include symbols.
    if (PromptCharacterSetInclusion("Include symbols", 4))
        sAvailableCharacters += constances.Symbols;

    // If no character sets were selected, notify the user and exit.
    if (!(sAvailableCharacters.Length > 0))
    {
        Console.WriteLine("No character sets selected. Cannot generate a random string.");
        return;
    }

    // Clear the console and display the generated random string.
    Console.Clear();
    Console.WriteLine($"Generated Random String: {BuildRandomeString(sAvailableCharacters, nStringLength)}");
}

// Prompts the user to include a specific character set based on the question.
static bool PromptCharacterSetInclusion(string question, int optionNumber)
{
    Console.Write($"[{optionNumber}] {question} (Y/N)? ");
    string? sUserResponse = Console.ReadLine();

    return IsYesResponse(sUserResponse);
}

// Builds a random string of the specified length using the available characters.
static string BuildRandomeString(string availableCharacters, int length)
{
    var result = new StringBuilder();
    var rnd = new Random();

    // Keep appending random characters until the desired length is reached.
    while (result.Length < length)
    {
        var index = rnd.Next(availableCharacters.Length - 1);
        result.Append(availableCharacters[index]);
    }

    return result.ToString();
}