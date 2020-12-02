using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Web.Features._01
{
    public static class Day01Extensions
    {
        public static async Task<List<int>> GetNumbers(this IBrowserFile file)
        {
            await using var inputStream = file.OpenReadStream();

            var streamReader = new StreamReader(inputStream, Encoding.UTF8);

            string line;
            var numbers = new List<int>();

            while ((line = await streamReader.ReadLineAsync()) != null)
            {
                var success = int.TryParse(line, out var number);
                if (success) numbers.Add(number);
            }

            await inputStream.DisposeAsync();
            streamReader.Dispose();

            return numbers;
        }
    }
}