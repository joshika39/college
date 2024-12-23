﻿using Infrastructure.IO;

namespace BL.Book.Types.Online
{
    public class EYouthBook : AeBook
    {
        public EYouthBook(IBook book, Guid libraryId, double size, string format) 
            : base(book, libraryId, size, format)
        { }
        public override void ValidateReturn(DateTime returnDate, IWriter writer)
        {
            base.ValidateReturn(returnDate, 50, writer);
        }
    }
}