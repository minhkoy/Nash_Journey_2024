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
        BirthPlace = i < 15 ? $"Birth place {i}" : "Ha Noi",
        DateOfBirth = DateTime.Today.AddYears(-10 - i),
        Gender = i % 2 == 0 ? CX.Genders.Male : CX.Genders.Female,
        IsGraduated = i % 3 == 0,
        PhoneNumber = $"03456789{i}"
    });
}
//memberList = new();
if (memberList is null)
{
    return;
}
#endregion

#region Main

// Exercise 1
var maleMembers = GetMaleMembers(memberList);
PrintMemberListOnConsole(maleMembers, title: "--1. LIST OF MALE MEMBERS--");

var oldestMemberByAge = GetOldestMemberByAge(memberList);
PrintMemberOnConsole(oldestMemberByAge, "--2. OLDEST MEMBER BY AGE--");

var oldestMemberByDob = GetOldestMemberByDob(memberList);
PrintMemberOnConsole(oldestMemberByDob, "--2B. OLDEST MEMBER BY DOB: --");

var onlyFullnameList = GetOnlyFullnameList(memberList);
Console.WriteLine("--3. ONLY FULLNAME LIST--");
foreach (var fullname in onlyFullnameList)
{
    Console.WriteLine(fullname);
}
Console.WriteLine();

var membersWithBirthYearEqualTo2000 = GetMembersWithBirthYear(memberList, CX.Comparer.Equal, 2000);
PrintMemberListOnConsole(membersWithBirthYearEqualTo2000, title: "--4. MEMBERS WITH BIRTH YEAR 2000--");

var membersWithBirthYearGreaterThan2000 = GetMembersWithBirthYear(memberList, CX.Comparer.GreaterThan, 2000);
PrintMemberListOnConsole(membersWithBirthYearGreaterThan2000, title: "--4B. MEMBERS WITH BIRTH YEAR GREATER THAN 2000--");

var membersWithBirthYearLessThan2000 = GetMembersWithBirthYear(memberList, CX.Comparer.LessThan, 2000);
PrintMemberListOnConsole(membersWithBirthYearLessThan2000, title: "--4C. MEMBERS WITH BIRTH YEAR LESS THAN 2000--");

var firstPersonByBirthPlace = GetFirstPersonByBirthPlace(memberList, "Ha Noi");
PrintMemberOnConsole(firstPersonByBirthPlace, "--5. FIRST PERSON BY BIRTH PLACE--");

// Exercise 2
var primeNumbers = await GetPrimeNumbers(1, 100);
Console.WriteLine("--PART 2. PRIME NUMBERS FROM 1 TO 100--");
foreach (var primeNumber in primeNumbers)
{
    Console.Write($"{primeNumber} ");
}
#endregion

#region Exercise 1
static void PrintMemberOnConsole(Member? member, string title = "")
{
    if (!string.IsNullOrEmpty(title))
    {
        Console.WriteLine(title);
    }
    if (member is null)
    {
        return;
    }
    Console.WriteLine(member.ToString());
    Console.WriteLine();
}
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
    Console.WriteLine();
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