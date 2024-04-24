// See https://aka.ms/new-console-template for more information
using CSharpAssignment_Day1.Helpers;
using CSharpAssignment_Day1.Models;

Console.WriteLine("Hello, World!");

static void PrintMemberListOnConsole(List<Member> members, string title = "")
{
    if (!string.IsNullOrEmpty(title))
    {
        Console.WriteLine(title);
    }
    foreach (var member in members)
    {
        Console.WriteLine(member);
    }
}
static List<Member> GetMaleMembers(List<Member> members)
{
    List<Member> result = new();
    foreach (var member in members)
    {
        if (string.Equals(member.Gender, CX.Genders.Male))
        {
            result.Add(member);
        }
    }
    return result;
}

static Member? GetOldestMemberByAge(List<Member> members)
{
    var maxAge = 0;
    Member? result = null;
    foreach (var member in members)
    {
        if (member.Age > maxAge)
        {
            maxAge = member.Age;
            result = member;
        }
    }
    return result;
}

static Member? GetOldestMemberByDob(List<Member> members)
{
    var maxDob = DateTime.Today;
    Member? result = null;
    foreach (var member in members)
    {
        if (member.DateOfBirth < maxDob)
        {
            maxDob = member.DateOfBirth;
            result = member;
        }
    }
    return result;
}

static List<string> GetOnlyFullnameList(List<Member> members)
{
    List<string> result = new();
    foreach (var member in members)
    {
        var fullname = string.Concat(member.LastName, " ", member.FirstName);
        result.Add(fullname);
    }
    return result;
}

static List<Member> GetMembersWithBirthYear(List<Member> members, string comparer, int year)
{
    List<Member> result = new();
    if (string.Equals(comparer, CX.Comparer.GreaterThan))
    {
        foreach(var member in members)
        {
            if (member.DateOfBirth.Year > year)
            {
                result.Add(member);
            }
        }
    }
    else if (string.Equals(comparer, CX.Comparer.LessThan))
    {
        foreach (var member in members)
        {
            if (member.DateOfBirth.Year < year)
            {
                result.Add(member);
            }
        }
    }
    else if (string.Equals(comparer, CX.Comparer.Equal))
    {
        foreach (var member in members)
        {
            if (member.DateOfBirth.Year == year)
            {
                result.Add(member);
            }
        }
    }
    else return [];
    return result;
}

static Member? GetFirstPersonByBirthPlace(List<Member> members, string birthPlace)
{
    //Member? result = null;
    foreach (var member in members)
    {
        if (string.Equals(member.BirthPlace, birthPlace))
        {
            return member;
        }
    }
    return null;
}