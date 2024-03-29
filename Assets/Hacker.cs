﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	//Constants
	private const string mainMenu = @"Welcome to D@rkn3t
Where you want to go?

Press 1 for Library
Press 2 for Militatry base
Press 3 for Microsoft
		
Enter your selection:";

	private const string book =
@"      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\     
 //________.|.________\\    
`----------`-'----------'";

	private const string sword = 
@"      /| ________________
O|===|* >________________>
      \|";
	private const string pc =
@"   _____
  | ___ |
  ||   ||  
  ||___||
  |   _ |
  |_____|
 /_/_|_\_\----.
             []";

	//Game configuration
	string[] level1Password= {"Shelf", "Library", "Catalog", "font", "books", "password"};
	string[] level2Password= {"mercenary", "helicopter", "ammunitions", "reenforce", "occupation", "conflict"};
	string[] level3Password= {"h@rD", "p@sSw0rD", "g0v3rm3nt", "4giv3", "b00k$", "l3tt3r"};

	//Game State
	private int level; 
	private Screen currentScreen;
    private string password;

    enum Screen 
	{
		MainMenu,
		Password,
		Win
	}

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnUserInput(string input)
	{
		if(input == "menu" || input == "exit" || input == "quit")
		{
			ShowMainMenu();
		}
		else if(currentScreen == Screen.MainMenu)	
		{
			RunMainMenu(input);
		}
		else if(currentScreen == Screen.Password)
		{
			CheckPassword(input);
		}
	}

	private void RunMainMenu(string input)
	{
		level = 0;
		switch(input)
		{
			case "1":
				level = 1;
				password = level1Password[Random.Range(0,level1Password.Length)];
				break;
			case "2":
				level = 2;
				password = level2Password[Random.Range(0,level2Password.Length)];
				break;
			case "3":
				level = 3;
				password = level3Password[Random.Range(0,level3Password.Length)];
				break;
			default:
				Terminal.WriteLine("Error: invalid command");
				break;		
		}

		if(level > 0)
		{
			StartGame();
		}
	}    

	private void ShowMainMenu()
	{
		currentScreen = Screen.MainMenu;		
		Terminal.ClearScreen();
		Terminal.WriteLine(mainMenu);
	}

	private void StartGame()
    {
		currentScreen = Screen.Password;
        Terminal.WriteLine("Please enter password, hint: " + password.Anagram());
    }

	private void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreeen();
        }
        else
		{
			Terminal.WriteLine("Incorrect");
			StartGame();
		}
    }

    private void DisplayWinScreeen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
		switch(level)
		{
			case 1:
				Terminal.WriteLine("Grtz! You steal a book");	
				Terminal.WriteLine("Type menu to select another place");
				Terminal.WriteLine(book);	
				break;
			case 2:
				Terminal.WriteLine("Grtz! You steal a weapon");
				Terminal.WriteLine("Type menu to select another place");		
				Terminal.WriteLine(sword);
				break;
			case 3:
				Terminal.WriteLine("Grtz! you steal pc");
				Terminal.WriteLine("Type menu to select another place");		
				Terminal.WriteLine(pc);
				break;
		}
    }    
}
