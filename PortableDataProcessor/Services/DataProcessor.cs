using CsvHelper;
using Newtonsoft.Json;
using PortableDataProcessor.Contacts;
using PortableDataProcessor.Models;
using System.Globalization;

namespace PortableDataProcessor.Services
{
    public class DataProcessor : IDataProcessor
    {
        public string ProcessData(string csvFilePath, string jsonFilePath)
        {
            // Step 1: Read CSV data
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var employees = csv.GetRecords<Employee>().ToList();

                // Step 2: Process data (e.g., filter employees with Salary > 50000)
                var filteredEmployees = employees.Where(e => e.Salary > 50000).ToList();

                // Step 3: Write the processed data to JSON
                var jsonData = JsonConvert.SerializeObject(filteredEmployees, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonData);

                Console.WriteLine("Data processing complete. Output written to JSON file.");

                return jsonData;
            }
        }
    }
}
