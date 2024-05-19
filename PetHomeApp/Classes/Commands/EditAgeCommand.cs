﻿using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class EditAgeCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            UserInputReader userInputReader = new UserInputReader();
            string? readResult;
            bool validEntry = false;

            Console.WriteLine("List of available animals' nicknames:");
            foreach (var animal in animals)
            {
                if (animal.Nickname != "" && animal.Nickname != DefaultValues.NICKNAME)
                    Console.WriteLine($"> {animal.Nickname}");
            }

            do
            {
                Console.WriteLine("\nEnter a nickname of pet whose age you want to edit:");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    readResult = readResult.ToLower().Trim();

                    foreach (var animal in animals)
                    {
                        if (animal.Nickname == "" || animal.Nickname == DefaultValues.NICKNAME)
                            continue;

                        if (animal.Nickname.ToLower().Equals(readResult))
                        {
                            userInputReader.GetAge(animal);
                            validEntry = true;
                            break;
                        }
                    }
                }
            } while (validEntry == false);
            
            Console.WriteLine($"You successfully changed animal's age.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}
