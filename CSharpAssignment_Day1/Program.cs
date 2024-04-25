// See https://aka.ms/new-console-template for more information
using CSharpAssignment_Day1.Helpers;
using CSharpAssignment_Day1.Models;

#region Init data source
List<Member> memberList = new();

for (int i = 1; i <= 20; i++)
{
    memberList.Add(new()
    {
        FirstName = $"First name {i}",
        LastName = $"Last name {i}",
        BirthPlace = i < 15 ? $"Birth place {i}" : "Ha Noi",
        DateOfBirth = DateTime.Today.AddYears(-10 - i),
        Gender = i % 2 == 0 ? CX.Genders.Male : CX.Genders.Female,
        IsGraduated = i % 3 == 0,
        PhoneNumber = $"03456789{i}"
    });
}

#endregion

#region Main
var maleMembers = GetMaleMembers(memberList);
PrintMemberListOnConsole(maleMembers, title: "LIST OF MAIL MEMBER:");

var oldestMemberByAge = GetOldestMemberByAge(memberList);
PrintMemberOnConsole(oldestMemberByAge, "OLDEST MEMBER BY AGE: ");

var oldestMemberByDob = GetOldestMemberByDob(memberList);
PrintMemberOnConsole(oldestMemberByDob, "OLDEST MEMBER BY DOB: ");

var onlyFullnameList = GetOnlyFullnameList(memberList);
Console.WriteLine("ONLY FULLNAME LIST: ");
foreach (var fullname in onlyFullnameList)
{
    Console.WriteLine(fullname);
}

var membersWithBirthYearEqualTo2000 = GetMembersWithBirthYear(memberList, CX.Comparer.Equal, 2000);
PrintMemberListOnConsole(membersWithBirthYearEqualTo2000, title: "MEMBERS WITH BIRTH YEAR 2000:");

var membersWithBirthYearGreaterThan2000 = GetMembersWithBirthYear(memberList, CX.Comparer.GreaterThan, 2000);
PrintMemberListOnConsole(membersWithBirthYearGreaterThan2000, title: "MEMBERS WITH BIRTH YEAR GREATER THAN 2000:");

var membersWithBirthYearLessThan2000 = GetMembersWithBirthYear(memberList, CX.Comparer.LessThan, 2000);
PrintMemberListOnConsole(membersWithBirthYearLessThan2000, title: "MEMBERS WITH BIRTH YEAR LESS THAN 2000:");

var firstPersonByBirthPlace = GetFirstPersonByBirthPlace(memberList, "Ha Noi");
PrintMemberOnConsole(firstPersonByBirthPlace, "FIRST PERSON BY BIRTH PLACE: ");

#endregion

#region Real logic implementations
static void PrintMemberOnConsole(Member? member, string title = "")
{
    if (member is null)
    {
        return;
    }
    if (!string.IsNullOrEmpty(title))
    {
        Console.WriteLine(title);
    }
    Console.WriteLine(member.ToString());
}
static void PrintMemberListOnConsole(List<Member> members, string title = "")
{
    if (!string.IsNullOrEmpty(title))
    {
        Console.WriteLine(title);
    }
    foreach (var member in members)
    {
        Console.WriteLine(member.ToString());
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
    switch (comparer)
    {
        // I cannot use my constants in CX for comparers here because it is not allowed in case [expression].
        case ">":
            foreach (var member in members)
            {
                if (member.DateOfBirth.Year > year)
                {
                    result.Add(member);
                }
            }
            break;
        case "<":
            foreach (var member in members)
            {
                if (member.DateOfBirth.Year < year)
                {
                    result.Add(member);
                }
            }
            break;
        case "=":
            foreach (var member in members)
            {
                if (member.DateOfBirth.Year == year)
                {
                    result.Add(member);
                }
            }
            break;
        default:
            return [];
    }
    return result;
}

static Member? GetFirstPersonByBirthPlace(List<Member> members, string birthPlace)
{
    var i = 0;
    while (true)
    {
        if (i >= members.Count)
        {
            return null;
        }
        if (string.Equals(members[i].BirthPlace, birthPlace))
        {
            return members[i];
        }
        i++;
    }
}

#endregion