using UnityEngine;

public class TerminalCode : MonoBehaviour
{
    // Game configuration data
    const string menu = "Type 'menu' to return";
    string[] lvl1Pass = { "pampis", "kostis", "giannakis", "lampis" };
    string[] lvl2Pass = { "xampis", "giorkis", "pavlis", "lampis" };
    string[] lvl3Pass = { "artemakis", "giasemakis", "takis", "lakis" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Local library");
        Terminal.WriteLine("Press 2 for the Police station");
        Terminal.WriteLine("Press 3 for the Nasa");
        Terminal.WriteLine("Please enter your selection: ");
    }
    
    void OnUserInput (string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input =="exit")
        {
            Terminal.WriteLine("If on the web close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPass(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLvlNum = (input == "1" || input == "2" || input == "3");
        if (isValidLvlNum)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPass();
        Terminal.WriteLine("Enter your password. hint: " + password.Anagram());
        Terminal.WriteLine(menu);
    }

    private void SetRandomPass()
    {
        switch (level)
        {
            case 1:
                password = lvl1Pass[Random.Range(0, lvl1Pass.Length)];
                break;
            case 2:
                password = lvl2Pass[Random.Range(0, lvl2Pass.Length)];
                break;
            case 3:
                password = lvl3Pass[Random.Range(0, lvl3Pass.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPass(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

     void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLvlReward();
        Terminal.WriteLine(menu);
    }

    void ShowLvlReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You earned a hacker guide book");
                Terminal.WriteLine(@"
      )________)
     /        //
    / Hacker //
   /        //
  /________//
 (________(/
");
                break;
            case 2:
                Terminal.WriteLine("You earned a Psyduck");
                Terminal.WriteLine(@"
     ,~~.
     (  9 )-_,
(\___ )=='-'
 \ .   ) )
  \ `-' /
   `~j-'   cra cra
");
                break;
            case 3:
                Terminal.WriteLine("Your earned a nasa's robot");
                Terminal.WriteLine(@"
     [___] /~\ [___]
     |ooo|.\_/.|ooo|
    /|888||   ||888|\
  /~\ ~~~ /[_]\ ~~~ /~\
 (O_O)/~~[_____]~~\(O_O)
     [~`]       ['~]
   _<\/>_       _<\/>_
  /_====_\     /_====_\   BOOM!");
                break;
        }
    }
}
