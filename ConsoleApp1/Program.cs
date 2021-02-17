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
                var DirectoryPath = @"D:\IFilter Test Documents";

                var filesToProcess = Directory.EnumerateFiles(DirectoryPath);

                foreach (var fileName in filesToProcess)
                {
                    var file = new FileInfo(fileName);

                    Console.WriteLine($"Reading {file.Name}");

                    // Try and read the stream from the file
                    TryReadFile(file);
                }

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
