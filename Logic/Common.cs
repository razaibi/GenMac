namespace Logic;
public class Common{
    public Common(){}

    public static string Capitalize(string Name)
    {
        return char.ToUpper(Name[0]) + Name.Substring(1);
    }
}