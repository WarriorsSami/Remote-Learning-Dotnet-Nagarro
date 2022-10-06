using System;

namespace iQuest.BigTree.ThirdPartyLibrary
{
    public static class ThirdPartyCalculator
    {
        public static int[] Calculate()
        {
            const int count = 5000;
            Random random = new Random();

            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
                numbers[i] = random.Next();

            return numbers;
        }
    }
}