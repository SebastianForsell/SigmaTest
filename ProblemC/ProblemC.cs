using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            string caseInput;
            int caseIndex = 1;
            int lineIndex = 0;
            Case currentCase = null;

            while ((caseInput = Console.ReadLine()) != null && caseIndex <= 5)
            {
                int caseKvalue;
                if (lineIndex == 0 && int.TryParse(caseInput, out caseKvalue))
                {
                    currentCase = new Case(caseIndex);
                    if(caseKvalue < 1 || caseKvalue > 11)
                    {
                        Console.WriteLine($"Case {currentCase.Index}: IMPOSSIBLE");
                    }
                    else
                    {
                        lineIndex = caseKvalue;
                    }
                    caseIndex++;
                }
                else if (lineIndex != 0 && currentCase != null && currentCase.TryAddCaseLine(caseInput))
                {
                    lineIndex--;
                    if (lineIndex == 0)
                    {
                        string output = CalculateOutput(currentCase);
                        Console.WriteLine($"Case {currentCase.Index}: {output}");
                    }
                }
            }
        }

        private static string CalculateOutput(Case currentCase)
        {
            if (!currentCase.IsValid || currentCase.ListOfA.GroupBy(s => s).Any(gs => gs.Count() > 1) || currentCase.ListOfB.GroupBy(s => s).Any(gs => gs.Count() > 1))
            {
                return "IMPOSSIBLE";
            }

            var permutationsIndexList = GetPermutationIndexList(currentCase.ListOfA.Count);

            List<string> solutions = new List<string>();
            foreach (var currentIndexList in permutationsIndexList)
            {
                var listA = GetReorderedList(currentCase.ListOfA, currentIndexList.ToList());
                var listB = GetReorderedList(currentCase.ListOfB, currentIndexList.ToList());

                var result = CompareLists(listA, listB);
                if (result != null)
                {
                    solutions.Add(result);
                }
            }

            if (solutions.Count > 0)
            {
                return solutions.OrderBy(s => s.Length).ThenBy(s => s).First();
            }

            return "IMPOSSIBLE";
        }

        private static List<IEnumerable<int>> GetPermutationIndexList(int k)
        {
            var indexList = new List<int>();
            for (int i = 0; i < k; i++)
            {
                indexList.Add(i);
            }
            return GetPermutations(indexList, indexList.Count).ToList();
        }

        private static List<string> GetReorderedList(List<string> list, List<int> indexList)
        {
            var reorderedList = new List<string>();
            foreach (var index in indexList)
            {
                reorderedList.Add(list[index]);
            }
            return reorderedList;
        }

        private static string CompareLists(List<string> listA, List<string> listB)
        {
            for (int i = 1; i <= listA.Count; i++)
            {
                var stringA = ConcatenateList(listA, i);
                var stringB = ConcatenateList(listB, i);
                if (stringA == stringB)
                    return stringA;
            }
            return null;
        }

        private static string ConcatenateList(List<string> stringList, int maxItems)
        {
            var output = "";
            for (int i = 0; i < maxItems; i++)
            {
                output += stringList[i];
            }
            return output;
        }

        static IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> list, int length)
        {
            if (length == 1)
                return list.Select(s => new[] { s });

            return GetPermutations(list, length - 1).SelectMany(s => list.Where(e => !s.Contains(e)), (s1, s2) => s1.Concat(new[] { s2 }));
        }
    }

    internal class Case
    {
        public Case(int index)
        {
            Index = index;
            ListOfA = new List<string>();
            ListOfB = new List<string>();
            IsValid = true;
        }

        public int Index { get; set; }
        public List<string> ListOfA { get; set; }
        public List<string> ListOfB { get; set; }
        public bool IsValid { get; set; }

        public bool TryAddCaseLine(string caseLine)
        {
            var splitLine = caseLine.Split(' ');
            if (splitLine.Length < 2)
                return false;

            if (splitLine[0].Length > 100 || splitLine[1].Length > 100)
                IsValid = false;

            ListOfA.Add(splitLine[0]);
            ListOfB.Add(splitLine[1]);
            return true;
        }

    }
}
