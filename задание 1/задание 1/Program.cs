using задание_1;

AllUsings allUsings = new AllUsings();

allUsings.LoadListFromFile();

Console.WriteLine("exit для выхода");
while (true)
{
    string str = Console.ReadLine();
    if (str == "exit")
    {
        break;    
    }
    else // для примера 2008.04.30 "Место 6" 1,2
    {
        allUsings.StringToTemperature(str);
    }
}

allUsings.PrintTemperatures();
allUsings.SaveListToFile();
