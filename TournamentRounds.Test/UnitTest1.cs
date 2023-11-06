using System.Linq.Expressions;
using TournamentRounds.Services;

namespace TournamentRounds.Test;

public class UnitTest1
{
    [Theory]
    [MemberData(nameof(Data))]
    public void TestUsingDictionary(int[] skills, int[] expected)
    {
        var sut = new TournamentRoundsService();

        var result = sut.GetNumberOfRoundsWithDictionary(skills);

        Assert.Equal(result, expected);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void TestUsingRecursion(int[] skills, int[] expected)
    {
        var sut = new TournamentRoundsService();

        var result = sut.GetNumberOfRoundsWithRecursion(skills);

        Assert.Equal(result, expected);
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[] { new int[] { 4, 2, 7, 3, 1, 8, 6, 5 }, new int[] {2,1,3,1,1,3,2,1} };
    }
}