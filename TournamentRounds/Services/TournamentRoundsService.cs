using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TournamentRounds.Services;
public class TournamentRoundsService
{
    public List<int> GetNumberOfRoundsWithRecursion(int[] skills)
    {
        //int[] arr = { 4, 2, 7, 3, 1, 8, 6, 5 };

        var rounds = new List<int>();

        for (int i = 0; i < skills.Length; i++)
        {
            var counter = 1;
            FindRounds(skills[i], skills.ToArray(), ref counter);

            rounds.Add(counter);
        }

        return rounds;
    }

    public List<int> GetNumberOfRoundsWithDictionary(int[] skills)
    {
        //var arr = new int[] { 4, 2, 7, 3, 1, 8, 6, 5 };

        var level = 1;

        var players = skills.Length;
        var tournamentDict = new Dictionary<int, List<int>>();
        tournamentDict.Add(level, skills.ToList());
        var winningPlayers = skills.ToList();

        while (players >= 1)
        {
            var playing = new List<int>();
            winningPlayers = GetWinningPlayers(winningPlayers);

            players = winningPlayers.Count;

            if (winningPlayers.Count > 1)
            {
                tournamentDict.Add(++level, winningPlayers);
            }
        }

        var results = new List<int>();

        foreach (var skill in skills)
        {
            for (var i = tournamentDict.Count; i > 0; i--)
            {
                if (tournamentDict[i].Exists(x => x == skill))
                {
                    results.Add(i);
                    break;
                }
            }
        }

        List<int> GetWinningPlayers(List<int> arr)
        {
            var winners = new List<int>();

            for (int i = 0; i < arr.Count - 1; i += 2)
            {
                if (arr[i] > arr[i + 1])
                {
                    winners.Add(arr[i]);
                }
                else
                {
                    winners.Add(arr[i + 1]);
                }
            }

            return winners;
        }

        return results;
    }

    private void FindRounds(int element, int[] array, ref int counter)
    {
        var winners = new HashSet<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if ((i % 2) == 0)
            {
                if (array[i] > array[i + 1])
                {
                    winners.Add(array[i]);
                }
            }
            else
            {
                if (array[i] > array[i - 1])
                {
                    winners.Add(array[i]);
                }
            }
        }

        if (winners.Count > 1 && winners.Contains(element))
        {
            counter++;

            FindRounds(element, winners.ToArray(), ref counter);
        }
    }
}
