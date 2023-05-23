﻿using Infrastructure.IO;

namespace BL.Book.Types.Online
{
    public class ELiteratureBook : AeBook
    {
        public ELiteratureBook(IBook book, Guid libraryId, double size, string format) 
            : base(book, libraryId, size, format)
        { }
        public override void ValidateReturn(DateTime returnDate, IWriter writer)
        {
            ValidateReturn(returnDate, 30, writer);
        }
    }
}