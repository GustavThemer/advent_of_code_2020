using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Web.Infrastructure
{
    public static class BrowserFileExtensions
    {
        public static async Task<List<int>> GetNumbers(this IBrowserFile file)
        {
            var lines = await GetLines(file);
            var numbers = new List<int>();

            foreach (var line in lines)
            {
                var success = int.TryParse(line, out var number);
                if (success) numbers.Add(number);
            }

            return numbers;
        }

        public static async Task<List<string>> GetLines(this IBrowserFile file)
        {
            await using var inputStream = file.OpenReadStream();

            var streamReader = new StreamReader(inputStream, Encoding.UTF8);

            string line;
            var lines = new List<string>();

            while ((line = await streamReader.ReadLineAsync()) != null) lines.Add(line);

            await inputStream.DisposeAsync();
            streamReader.Dispose();

            return lines;
        }
    }
}