﻿using Implementation.IO.Factories;
using Implementation.Logger.Factories;
using System.Linq;
using ZH1;

namespace ZH1_Jeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var id = Guid.NewGuid();
            var loggerFactory = new LoggerFactory();
            var ioFactory = new IOFactory();

            using var logger = loggerFactory.CreateLogger(id);
            var writer = ioFactory.CreateWriter(logger);
            var reader = ioFactory.CreateReader(logger, writer);

            var strmReader = new StreamReader(@"Resources\inp.txt");

            var testStudents = reader.ReadLine<Student>(strmReader, Student.TryParse).ToList();

            var highestStud = testStudents
                .Where(stud => stud.CreditSum == testStudents.Max(s => s.CreditSum))
                .FirstOrDefault();

            var test = testStudents.Any(s => s.Subjects[0].Grade >= 0) ? "igen" : "nem";

            Console.WriteLine($"{test} {highestStud?.NeptunId} {highestStud?.CreditSum}");

        }
    }
}