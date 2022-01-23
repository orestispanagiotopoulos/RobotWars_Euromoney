using Microsoft.Extensions.DependencyInjection;
using RobotWars.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            // DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IValidator>(new Validator())
                .AddSingleton<IRobotFactory>(new RobotFactory())
                .BuildServiceProvider();

            var manager = new Manager(serviceProvider.GetRequiredService<IValidator>(), serviceProvider.GetRequiredService<IRobotFactory>());

            Console.WriteLine("Please enter 3 values separated by comma. The first two should be integers to specify robots co-ordinates and the third one a char to specify the robot's direction (N, E, S, W). (Example:0,0,N) Then press Enter:");
            string initialPosition = Console.ReadLine();
            var validationResultInitilPosition = manager.ValidateInitialState(initialPosition);

            if (ReportErrors(validationResultInitilPosition.errors))
            {
                return;
            }

            Console.WriteLine("Please enter any number of mars rover moves. 'L' left, 'R' right, 'M' move foreword. (Example:LMMRMLMMM)  Then press Enter:");
            string moves = Console.ReadLine();
            var validationResultMoves = manager.ValidateMoves(moves);
            if (ReportErrors(validationResultMoves))
            {
                return;
            }

            Console.WriteLine("");
            Console.WriteLine(manager.GetRobotResult(validationResultInitilPosition.initX,
                validationResultInitilPosition.initY, validationResultInitilPosition.direction, moves));

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static bool ReportErrors(List<string> validations)
        {
            if (validations.Any())
            {
                foreach (var v in validations)
                {
                    Console.WriteLine(v);
                }
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
}
