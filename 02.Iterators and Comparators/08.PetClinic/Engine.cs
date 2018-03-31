using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private PetClinicController controller;

    public Engine(PetClinicController controller)
    {
        this.controller = controller;
    }

    public void Run()
    {
        var commandsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsCount; i++)
        {
            var commandTokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var commandType = commandTokens[0];
            commandTokens.RemoveAt(0);

            switch (commandType)
            {
                case "Create":
                    try
                    {
                        controller.CreateEntity(commandTokens);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Add":
                    Console.WriteLine(controller.AddPetToClinic(commandTokens[0], commandTokens[1]));
                    break;
                case "Release":
                    Console.WriteLine(controller.ReleasePetFromClinic(commandTokens[0]));
                    break;
                case "HasEmptyRooms":
                    Console.WriteLine(controller.CheckForEmptyRooms(commandTokens[0]));
                    break;
                case "Print":
                    Console.WriteLine(controller.PrintClinicInfo(commandTokens));
                    break;

            }
        }
    }
}
