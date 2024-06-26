﻿using BL.Book;
using BL.Book.Types;
using BL.Book.Types.Online;
using BL.Book.Types.Physical;
using BL.Lib;
using BL.People;
using Moq;

namespace BLTests.Library;

public class LibraryTests
{
    #region Tests
        
    [Theory]
    [MemberData(nameof(LT_0001_MemberData))]
    public void LT_0001_Given_NullParameter_When_LendBookCalled_Then_ThrowsException(ILibraryBook book, DateTime date, ILibrary lib)
    {
        var ex = Record.Exception(() => lib.LendBook(book, date, new Guid()));
        
        Assert.IsType<ArgumentNullException>(ex);
    }
    #endregion
        
    #region MemeberData
    public static IEnumerable<object[]> LT_0001_MemberData()
    {
        var lib = LibGen.GetTestLibrary();
        yield return new object[]
        {
            null!,  
            DateTime.Today,
            lib
        };
        yield return new object[]
        {
            new ScienceBook(new PublishedBook("asd", "asd", 2, DateTime.Today,Mock.Of<IAuthor>()), Guid.NewGuid(), 100), 
            default(DateTime),
            lib
        };
    }
    #endregion
}