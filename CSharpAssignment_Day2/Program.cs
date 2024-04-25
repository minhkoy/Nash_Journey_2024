// See https://aka.ms/new-console-template for more information
using CSharpAssignment_Day2.Helpers;
using CSharpAssignment_Day2.Models;

//Console.WriteLine("Hello, World!");
#region Init data source
List<Member> memberList = new();

for (int i = 1; i <= 20; i++)
{
    memberList.Add(new()
    {
        FirstName = $"First name {i}",
        LastName = $"Last name {i}",
        Age = 10 + i,
        BirthPlace = i < 15 ? $"Birth place {i}" : "Ha Noi",
        DateOfBirth = DateTime.Today.AddYears(-10 - i),
        Gender = i % 2 == 0 ? CX.Genders.Male : CX.Genders.Female,
        IsGraduated = i % 3 == 0,
        PhoneNumber = $"03456789{i}"
    });
}

#endregion

#region Main

// Exercise 1
var maleMembers = GetMaleMembers(memberList);
PrintMemberListOnConsole(maleMembers, title: "LIST OF MAIL MEMBER:");

var oldestMemberByAge = GetOldestMemberByAge(memberList);
Console.WriteLine("OLDEST MEMBER BY AGE: \n{0}", oldestMemberByAge);

var oldestMemberByDob = GetOldestMemberByDob(memberList);
Console.WriteLine("OLDEST MEMBER BY DOB: \n{0}", oldestMemberByDob);

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
Console.WriteLine("FIRST PERSON BY BIRTH PLACE: \n{0}", firstPersonByBirthPlace);

// Exercise 2
var primeNumbers = await GetPrimeNumbers(1, 100);
Console.WriteLine("PRIME NUMBERS: ");
foreach (var primeNumber in primeNumbers)
{
    Console.Write($"{primeNumber} ");
}
#endregion

#region Exercise 1
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
    return members.Where(member => string.Equals(member.Gender, CX.Genders.Male)).ToList();
}

static Member? GetOldestMemberByAge(List<Member> members)
{
    return members.MaxBy(member => member.Age);
}

static Member? GetOldestMemberByDob(List<Member> members)
{
    return members.MinBy(member => member.DateOfBirth);
}

static List<string> GetOnlyFullnameList(List<Member> members)
{
    return members.Select(member => string.Concat(member.LastName, " ", member.FirstName)).ToList();
}

static List<Member> GetMembersWithBirthYear(List<Member> members, string comparer, int year)
{
    if (string.Equals(comparer, CX.Comparer.GreaterThan))
    {
        return members.Where(member => member.DateOfBirth.Year > year).ToList();
    }
    else if (string.Equals(comparer, CX.Comparer.LessThan))
    {
        return members.Where(member => member.DateOfBirth.Year < year).ToList();
    }
    else if (string.Equals(comparer, CX.Comparer.Equal))
    {
        return members.Where(member => member.DateOfBirth.Year == year).ToList();
    }
    else return [];
}

static Member? GetFirstPersonByBirthPlace(List<Member> members, string birthPlace)
{
    return members.FirstOrDefault(member => string.Equals(member.BirthPlace, birthPlace));
}

#endregion

#region Exercise 2
static bool IsPrime(int number)
{
    if (number < 2) return false;
    var maxToFind = Math.Sqrt(number);
    for (int i = 2; i < maxToFind; i++)
    {
        if (number % i == 0) return false;
    }
    return true;
}

static Task<List<int>> GetPrimeNumbers(int start, int end)
{
    //return Enumerable.Range(start, end - start + 1).Where(number => IsPrime(number)).ToList();
    List<int> result = new();
    foreach (var i in Enumerable.Range(start, end - start + 1))
    {
        if (IsPrime(i))
        {
            result.Add(i);
        }
    }
    return Task.FromResult(result);
}

#endregion