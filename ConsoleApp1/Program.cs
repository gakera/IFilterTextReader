using IFilterTextReader;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = @"C:\Sicos1977.doc";
                var file = new FileInfo(fileName);

                Console.WriteLine($"Reading {file.Name}");
                var reader = new FilterReader(fileName);
                var txt = reader.ReadToEnd();

                // Try and read the stream from the file
                TryReadFile(file);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void TryReadFile(FileInfo file)
        {
            var stream = file.OpenRead();
            FilterReader reader = null;
            try
            {
                FilterReaderOptions filterReaderOptions = new FilterReaderOptions();
                reader = new FilterReader(stream, file.Extension, filterReaderOptions);
                var result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader?.Close();
                stream?.Close();
            }
        }
    }
}
