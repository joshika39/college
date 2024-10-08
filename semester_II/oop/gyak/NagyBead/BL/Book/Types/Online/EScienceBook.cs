﻿using Infrastructure.IO;

namespace BL.Book.Types.Online
{
    public class EScienceBook : AeBook
    {
        public EScienceBook(IBook book, Guid libraryId, double size, string format) 
            : base(book, libraryId, size, format)
        { }
        public override void ValidateReturn(DateTime returnDate, IWriter writer)
        {
            base.ValidateReturn(returnDate, 100, writer);
        }
    }
}