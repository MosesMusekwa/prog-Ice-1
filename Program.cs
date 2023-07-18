using System;

namespace WorkDistribution
{
    class Scripts
    {
        static void Main(string[] args)
        {
            //  user to input the total number of scripts
            Console.Write("Enter the total number of scripts to be marked: ");
            int totalScripts = Convert.ToInt32(Console.ReadLine());

            //  user to input the number of questions in the test
            Console.Write("Enter the number of questions in the test (1-10): ");
            int numQuestions = Convert.ToInt32(Console.ReadLine());

            //  user to input the subtotal of each question
            int[] subtotals = new int[numQuestions];
            for (int i = 0; i < numQuestions; i++)
            {
                Console.Write("Enter the subtotal for question  " + (i+1) +" : ");
                subtotals[i] = Convert.ToInt32(Console.ReadLine());
            }

            //  user to input the number of lecturers
            Console.Write("Enter the number of lecturers who are going to mark the scripts: ");
            int numLecturers = Convert.ToInt32(Console.ReadLine());

            // Calculating the number of scripts each lecturer will mark
            int[] numScriptsPerLecturer = new int[numLecturers];
            int remainingScripts = totalScripts;
            for (int i = 0; i < numLecturers; i++)
            {
                numScriptsPerLecturer[i] = remainingScripts / (numLecturers - i);
                remainingScripts -= numScriptsPerLecturer[i];
            }

            // Calculatingg the estimated time to mark the scripts for each lecturer
            Console.WriteLine("\nScripts Allocation:");
            for (int i = 0; i < numLecturers; i++)
            {
                int numTicks = 0;
                for (int j = 0; j < numQuestions; j++)
                {
                    numTicks += numScriptsPerLecturer[i] * subtotals[j];
                }

                int minutes = numTicks * 2 / 60;
                int seconds = numTicks * 2 % 60;
                if (seconds >= 30)
                {
                    minutes += 1;
                }

                Console.WriteLine("Lecturer " + (i + 1) + " will mark" + " " + (numScriptsPerLecturer[i]) +" scripts, estimated time : " + " " + (minutes) + " " + "minutes");
            }

            Console.ReadLine();
        }
    }
}


