
using System.Text;
{
    using StreamReader reader = new StreamReader(new FileStream("Languages.txt", FileMode.Open), Encoding.Latin1);
    using StreamWriter writer = new StreamWriter(File.Create("Languages.cs"), Encoding.UTF8);

    writer.WriteLine("namespace TheTVDBWebApi;");
    writer.WriteLine();
    writer.WriteLine("public enum Languages");
    writer.WriteLine("{");

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        if (line.Contains(':'))
        {
            string[] items = line.Split(':', 2);
            string name = items[0].Trim().Trim(',').Trim('\'');
            string enu = name.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            string id = items[1].Trim().Trim(',').Trim('\'');

            writer.WriteLine("    /// <summary>");
            writer.WriteLine($"    /// {name}");
            writer.WriteLine("    /// </summary>");
            writer.WriteLine($"    [EnumMember(Value = \"{id}\")]");
            writer.WriteLine($"    [Description(\"{name}\")]");
            writer.WriteLine($"    {enu},");
            writer.WriteLine();
        }
    }
    writer.WriteLine("}");
}
{
    using StreamReader reader = new StreamReader(new FileStream("Countries.txt", FileMode.Open), Encoding.Latin1);
    using StreamWriter writer = new StreamWriter(File.Create("Countries.cs"), Encoding.UTF8);

    writer.WriteLine("namespace TheTVDBWebApi;");
    writer.WriteLine();
    writer.WriteLine("public enum Countries");
    writer.WriteLine("{");

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        if (line.Contains(':'))
        {
            string[] items = line.Split(':', 2);
            string name = items[1].Trim().Trim(',').Trim('\'');
            string enu = name.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            string id = items[0].Trim().Trim(',').Trim('\'');

            writer.WriteLine("    /// <summary>");
            writer.WriteLine($"    /// {name}");
            writer.WriteLine("    /// </summary>");
            writer.WriteLine($"    [EnumMember(Value = \"{id}\")]");
            writer.WriteLine($"    [Description(\"{name}\")]");
            writer.WriteLine($"    {enu},");
            writer.WriteLine();
        }
    }
    writer.WriteLine("}");
}

