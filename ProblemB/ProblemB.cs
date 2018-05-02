using System;

namespace ProblemB
{
    class Program
    {
        private static int firstAdjustments = 0, secondAdjustment = 0, thirdAdjustment = 0;
        private static char firstModelState, secondModelState, thirdModelState;

        static void Main(string[] args)
        {
            string toiletInput;

            while ((toiletInput = Console.ReadLine()) != null)
            {
                if(toiletInput.Length < 2 || toiletInput.Length > 1000)
                {
                    continue;
                }

                SetInitialToiletStates(toiletInput);

                for (int i = 1; i < toiletInput.Length; i++)
                {
                    EnterToilet(toiletInput[i]);
                    ExitToilet();
                }

                WriteAndResetAdjustmentCounts();
            }
        }

        private static void SetInitialToiletStates(string toiletInput)
        {
            firstModelState = toiletInput[0];
            secondModelState = toiletInput[0];
            thirdModelState = toiletInput[0];
        }

        private static void EnterToilet(char toiletPreference)
        {
            if(firstModelState != toiletPreference)
            {
                firstModelState = toiletPreference;
                firstAdjustments++;
            }
            if (secondModelState != toiletPreference)
            {
                secondModelState = toiletPreference;
                secondAdjustment++;
            }
            if (thirdModelState != toiletPreference)
            {
                thirdModelState = toiletPreference;
                thirdAdjustment++;
            }
        }

        private static void ExitToilet()
        {
            if (firstModelState != 'U')
            {
                firstModelState = 'U';
                firstAdjustments++;
            }
            if (secondModelState != 'D')
            {
                secondModelState = 'D';
                secondAdjustment++;
            }
        }

        private static void WriteAndResetAdjustmentCounts()
        {
            Console.WriteLine(firstAdjustments);
            Console.WriteLine(secondAdjustment);
            Console.WriteLine(thirdAdjustment);
            firstAdjustments = 0;
            secondAdjustment = 0;
            thirdAdjustment = 0;
        }
    }
}

