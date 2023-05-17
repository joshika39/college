﻿namespace LibraryCore
{
    public static class Constants
    {
        public static class BookTypes
        {
            public const string SCIENCE_BOOK = "természettudományi";
            public const string LITERATURE_BOOK = "szépirodalmi";
            public const string YOUTH_BOOK = "ifijúsági";
        }
        public static class EscapeColors
        {
            public const string RED = "\u001b[31;1m";
            public const string GREEN = "\u001b[32;1m";
            public const string YELLOW = "\u001b[33;1m";
            public const string CYAN = "\u001b[36;1m";
            public const string RESET = "\u001b[0m";
        }
    }
}