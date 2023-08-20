using gamebasics_test_project.controller;
using gamebasics_test_project.models;
using gamebasics_test_project.view;
using System.Text.Json;

internal class Program
{
    static string jsonPath = "groupsConfig.json";

    private static void Main(string[] args)
    {
        Rootobject? rootObject = DeserializeJson(jsonPath);
        SimulatorController simulator;

        if (rootObject == null)
        {
            Console.WriteLine("No data");
        }
        else
        {
            simulator = new(rootObject.Teams);

            PrinterView.PrintInitialization();
            PrinterView.PrintFakeLoading();

            simulator.InitializeSimulation();

            PrinterView.PrintFinalization();           
        }

        Console.ReadKey();
    }

    private static Rootobject? DeserializeJson(string path)
    {
        try
        {
            string jsonStr = File.ReadAllText(path);

            Rootobject? ro = JsonSerializer.Deserialize<Rootobject>(jsonStr);

            return ro;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}