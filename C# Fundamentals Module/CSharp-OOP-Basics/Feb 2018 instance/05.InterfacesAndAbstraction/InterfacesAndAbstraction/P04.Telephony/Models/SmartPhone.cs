using System.Linq;

public class SmartPhone : ICellPhone
{
    public string Browse(string webSite)
    {
        if (webSite.Any(c => char.IsDigit(c)))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {webSite}!";
    }

    public string Call(string number)
    {
        if (!number.All(c => char.IsDigit(c)))
        {
            return "Invalid number!";
        }

        return $"Calling... {number}";
    }


}