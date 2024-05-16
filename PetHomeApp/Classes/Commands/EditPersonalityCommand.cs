﻿using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class EditPersonalityCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
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
                Console.WriteLine("\nEnter a nickname of pet whose personality description you want to edit:");

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
                            do
                            {
                                Console.WriteLine($"Enter the a new personality description for {animal.Nickname}");
                                readResult = Console.ReadLine();
                                if (!string.IsNullOrEmpty(readResult))
                                {
                                    animal.PersonalityDescription = readResult;
                                    validEntry = true;
                                    break;
                                }
                            } while (validEntry == false);
                        }
                    }
                }
            } while (validEntry == false);

            Console.WriteLine($"You successfully changed animal's personality description.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}