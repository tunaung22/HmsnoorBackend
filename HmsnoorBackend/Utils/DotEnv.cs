namespace HmsnoorBackend.Utils;

// https://dusted.codes/dotenv-in-dotnet
public static class DotEnv
{

    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        foreach (var i in File.ReadAllLines(filePath))
        {
            var part = i.Split('=', StringSplitOptions.RemoveEmptyEntries);
            if (part.Length != 2) continue;

            Environment.SetEnvironmentVariable(part[0], part[1]);
        }
    }

}
