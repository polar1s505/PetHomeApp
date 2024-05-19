using Microsoft.VisualBasic;
using PetHomeApp.Classes.Commands;
using PetHomeApp.Classes.Models;
using PetHomeApp.Classes.Utils;
using PetHomeApp.Interfaces;
using System.Text.Json;

namespace PetHomeApp.Classes
{
    public class App
    {
        public void Run()
        {
            List<PetBase> ourAnimals = new List<PetBase>();
            string filePath = "db.json";

            ourAnimals = FileManager.ReadFromJsonFile(filePath);


            string? readResult;
            string menuSelection = "";

            do
            {
                DisplayMainMenu();

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                switch (menuSelection)
                {
                    case "1":
                        // List all current pet information
                        ICommand displayInfoCommand = new DisplayInfoCommand();
                        displayInfoCommand.Execute(ourAnimals);
                        break;

                    case "2":
                        // Add a new animal friend to the ourAnimals array
                        ICommand addAnimalCommand = new AddPetCommand();
                        addAnimalCommand.Execute(ourAnimals);
                        break;

                    case "3":
                        // Ensure animal ages and physical descriptions are complete
                        ICommand completeAgeAndPhysycalDescrCommand = new CompleteAgeAndPhysicalDescrCommand();
                        completeAgeAndPhysycalDescrCommand.Execute(ourAnimals);
                        break;

                    case "4":
                        // Ensure animal nicknames and personality descriptions are complete
                        ICommand completeAgeAndPersonalityCommand = new CompleteNicknameAndPersonalityCommand();
                        completeAgeAndPersonalityCommand.Execute(ourAnimals);
                        break;

                    case "5":
                        // Edit an animal's age by nickname
                        ICommand editAgeCommand = new EditAgeCommand();
                        editAgeCommand.Execute(ourAnimals);
                        break;

                    case "6":
                        // Edit an animal's personality description by nickname
                        ICommand editPersonalityCommand = new EditPersonalityCommand();
                        editPersonalityCommand.Execute(ourAnimals);
                        break;

                    case "7":
                        ICommand searchAnimalCommand = new SearchAnimalByCharacteristicsCommand();
                        searchAnimalCommand.Execute(ourAnimals);
                        break;

                    default:
                        break;
                }
            } while (menuSelection != "exit");

            FileManager.WriteToJsonFile(ourAnimals, filePath);
        }

        private void DisplayMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the PetHome app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current animals information");
            Console.WriteLine(" 2. Add a new pet");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal’s age");
            Console.WriteLine(" 6. Edit an animal’s personality description");
            Console.WriteLine(" 7. Search a pet by characteristics");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
        }
    }
}