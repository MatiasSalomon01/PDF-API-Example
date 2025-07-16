namespace WebApi.Helpers;

public static class CssHelper
{
    public static string Load(string relativePath)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
        return File.ReadAllText(path);
    }
}