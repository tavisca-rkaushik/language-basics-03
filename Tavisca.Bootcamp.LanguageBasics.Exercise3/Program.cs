using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"fat = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int size = protein.Length;
            int[] calories = new int[size];

            for(int i = 0; i < size; i++)
                calories[i] = ( (protein[i] + carbs[i]) * 5 ) + (fat[i] * 9);
            
            int[] result =  new int[dietPlans.Length];

            for(int i = 0; i < dietPlans.Length; i++)
            {
                bool[] indices = new bool[size];
                for(int j = 0; j < size; j++)
                    indices[j] = true;
                
                string temp = dietPlans[i];

                for(int j = 0; j < temp.Length; j++)
                {
                    switch(temp[j])
                    {
                        case 't':
                        Helper.minimum(indices, calories, size);
                        break;

                        case 'T':
                        Helper.maximum(indices, calories, size);
                        break;

                        case 'f':
                        Helper.minimum(indices, fat, size);
                        break;

                        case 'F':
                        Helper.maximum(indices, fat, size);
                        break;

                        case 'c':
                        Helper.minimum(indices, carbs, size);
                        break;

                        case 'C':
                        Helper.maximum(indices, carbs, size);
                        break;

                        case 'p':
                        Helper.minimum(indices, protein, size);
                        break;

                        case 'P':
                        Helper.maximum(indices, protein, size);
                        break;
                    }
                }
                for(int l = 0; l < size; l++)
                    if(indices[l])
                    {
                        result[i] = l;
                        break;
                    }
        }
        return result;

            
            throw new NotImplementedException();
        }

    }
}
