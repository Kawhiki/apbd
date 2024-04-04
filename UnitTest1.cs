using System;
using JetBrains.Annotations;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTests
{
    [Fact]
    public void Should_Add_VeryImportantClient_Without_CreditCheck()
    {
        var userService = new UserService();
        var isSuccessful = userService.AddUser("Dennis", "Rodman", "denrod@example.com", DateTime.Parse("1977-12-12"), 2);
        Assert.True(isSuccessful, "A Very Important Client should be added regardless of credit limit.");
    }

    [Fact]
    public void Should_Fail_ToAddUser_When_LastName_Is_Missing()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("Krzychu", "", "k0rz3n@ail.com", DateTime.Parse("1955-02-11"), 1);
        Assert.False(isSuccess);
    }

    [Fact]
    public void Should_Fail_ToAddUser_When_Email_Is_Invalid()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("John", "Depp", "kdsaljd", DateTime.Parse("1999-10-26"), 1);
        Assert.False(isSuccess);
    }

    [Fact]
    public void Should_Fail_ToAddUser_If_Age_Is_Below_21()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("Lebron", "James", "king@gmail.com", DateTime.Now, 1);
        Assert.False(isSuccess);
    }

    [Fact]
    public void Should_Add_VeryImportantClient_Without_CreditLimit_Check()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("Lou", "Williams", "louww@gmail.com", DateTime.Parse("1992-07-06"), 2);
        Assert.True(isSuccess);
    }

    [Fact]
    public void Should_SuccessfullyAdd_StandardClient_With_Adequate_Credit()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("Lou", "Williams", "louww@gmail.com", DateTime.Parse("1992-07-06"), 2);        Assert.True(isSuccess);
    }

    [Fact]
    public void Should_SuccessfullyAdd_ImportantClient_With_Doubled_CreditLimit()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("Lou", "Williams", "louww@gmail.com", DateTime.Parse("1992-07-06"), 2);        Assert.True(isSuccess);
    }

    [Fact]
    public void Should_AddUser_When_Age_Is_Exactly_21()
    {
        var userService = new UserService();
        var today = DateTime.Today;
        var birthDate = today.AddYears(-21);
        var isSuccess = userService.AddUser("Stanley", "Johnson", "stjohn@gmail.com", birthDate, 1);
        Assert.True(isSuccess);
    }

    [Fact]
    public void Should_AddUser_With_Sufficient_CreditLimit()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("John", "Jordan", "jojo@gmail.com", DateTime.Parse("1981-11-11"), 3);
        Assert.True(isSuccess);
    }

    [Fact]
    public void Should_Successfully_Add_User_Meeting_All_Requirements()
    {
        var userService = new UserService();
        var isSuccess = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.True(isSuccess);
    }

    [Fact]
    public void Should_Throw_ArgumentException_For_Nonexistent_ClientId()
    {
        var userService = new UserService();
        Assert.Throws<ArgumentException>(() =>
            userService.AddUser("Michal", "Zak", "michzak@gmail.com", DateTime.Parse("1982-03-21"), 7));
    }

    [Fact]
    public void Should_Throw_ArgumentException_For_Invalid_Client_LastName()
    {
        var userService = new UserService();
        var exception = Record.Exception(() =>
            userService.AddUser("Michal", "w", "michzak@gmail.com", DateTime.Parse("1912-09-09"), 1));
        Assert.IsType<ArgumentException>(exception);
    }
}
