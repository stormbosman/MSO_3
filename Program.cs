using mso_2;
using mso_3;
using System;
using System.Numerics;
using Xunit;
class Program
{
    [STAThread]
    static void Main()
    {
        /*ICommand command = new CompositeCommand();
        Grid grid = new Grid(0, 0);
        MoveEntity entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

        Console.Write("Choose (example/file): ");
        var inputType = Console.ReadLine();

        try
        {
            var input = InputFactory.Create(inputType);
            command = input.Read();
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException(ex.ToString());
        }

        Console.WriteLine("Choose (steps/metric): ");
        switch (Console.ReadLine())
        {
            case "steps":
                Console.WriteLine("\n" + command.Execute(entity));
                Console.WriteLine(entity.GetStatusString());
                break;

            case "metric":
                Metrics metrics = new Metrics(command);
                metrics.Analyze();
                Console.WriteLine(metrics.getStringData());
                break;

            default: throw new ArgumentException("Unknown output type");
        }
        Console.WriteLine("press enter to exit");
        Console.ReadLine();*/

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm()); // start jouw Form
    }
}
