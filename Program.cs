using System.Text.Json;

namespace TravelThroughTimeData;

class Program
{
    private static readonly DateTime ExecuteNow = new(2023, 7, 1);

    static void Main()
    {
        Present();
        Past();
        Future();

        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    private static void Present()
    {
        var employee = ReadJsonFile<Employee>("present.json");
        if (employee?.Salary == null)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("--- Present ---");
        WriteTimeValues(employee.Salary);

        Console.WriteLine();
        WriteTimeValue(employee.Salary, new(2022, 12, 1));
        WriteTimeValue(employee.Salary, new(2023, 1, 1));
        WriteTimeValue(employee.Salary, new(2023, 3, 1));
        WriteTimeValue(employee.Salary, ExecuteNow);
        WriteTimeValue(employee.Salary, new(2023, 9, 1));
    }

    private static void Past()
    {
        var employee = ReadJsonFile<Employee>("past.json");
        if (employee?.Salary == null)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("--- Past ---");
        WriteTimeValues(employee.Salary);

        Console.WriteLine();
        WriteTimeValue(employee.Salary, new(2022, 12, 1));
        WriteTimeValue(employee.Salary, new(2023, 1, 1));
        WriteTimeValue(employee.Salary, new(2023, 3, 1));
        WriteTimeValue(employee.Salary, new(2023, 4, 16));
        WriteTimeValue(employee.Salary, ExecuteNow);
    }

    private static void Future()
    {
        var employee = ReadJsonFile<Employee>("future.json");
        if (employee?.Salary == null)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("--- Future ---");
        WriteTimeValues(employee.Salary);

        Console.WriteLine();
        WriteTimeValue(employee.Salary, new(2022, 12, 1));
        WriteTimeValue(employee.Salary, new(2023, 1, 1));
        WriteTimeValue(employee.Salary, ExecuteNow);
        WriteTimeValue(employee.Salary, new(2023, 8, 1));
        WriteTimeValue(employee.Salary, new(2024, 10, 16));
    }

    private static void WriteTimeValue<T>(TimeField<T> timeField, DateTime evaluationDate)
    {
        var timeValue = timeField.GetTimeValue(evaluationDate);
        Console.WriteLine($"Time value for {evaluationDate:d}: {(timeValue != null ? timeValue.Value : "-")}");
    }

    private static void WriteTimeValues<T>(TimeField<T> timeField)
    {
        foreach (var value in timeField)
        {
            Console.WriteLine(value.ToString());
        }
    }

    private static T? ReadJsonFile<T>(string fileName)
    {
        var json = File.ReadAllText(fileName);
        var result = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return result;
    }
}
