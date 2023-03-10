namespace Logic;

public class TypeHandler
{
    public TypeHandler() { }



    public static string GetNormalizedType(
        string attributeType
    )
    {
        string typeString;
        attributeType = Common.Capitalize(attributeType);
        switch (attributeType)
        {
            case "Bool":
                typeString = "Boolean";
                break;
            case "Boolean":
                typeString = "Boolean";
                break;
            case "True":
                typeString = "Boolean";
                break;
            case "False":
                typeString = "Boolean";
                break;
            case "Byt":
                typeString = "Byte";
                break;
            case "Byte":
                typeString = "Byte";
                break;
            case "Char":
                typeString = "Char";
                break;
            case "Decimal":
                typeString = "Decimal";
                break;
            case "Dec":
                typeString = "Decimal";
                break;
            case "Dbl":
                typeString = "Double";
                break;
            case "Double":
                typeString = "Double";
                break;
            case "Sgl":
                typeString = "Single";
                break;
            case "Single":
                typeString = "Single";
                break;
            case "Int":
                typeString = "Int32";
                break;
            case "Int32":
                typeString = "Int32";
                break;
            case "Int64":
                typeString = "Int64";
                break;
            case "Obj":
                typeString = "Object";
                break;
            case "Object":
                typeString = "Object";
                break;
            case "Dyn":
                typeString = "Object";
                break;
            case "Dynamic":
                typeString = "Object";
                break;
            case "Str":
                typeString = "String";
                break;
            case "String":
                typeString = "Object";
                break;

            default:
                typeString = "String";
                break;
        }

        return typeString;
    }

    public static string GetDefaultValue(
        string attributeType,
        string defaultValue
    )
    {
        string defaultString;
        switch (attributeType)
        {
            case "String":
                defaultString = $"\"{defaultValue}\"";
                break;
            case "Float":
                defaultString = $"{defaultValue}";
                break;
            default:
                defaultString = $"{defaultValue}";
                break;
        }

        return defaultString;

    }

    public static string HandleType(
            string[] segments
        )
    {
        string attributeType = "";
        if (segments.ElementAtOrDefault(0) != null)
        {
            attributeType = GetNormalizedType(segments[0]);
        }

        string attributeString;
        switch (attributeType)
        {
            case "String":
                attributeString = StringTypeHandler.BuildAttribute(segments[1..]);
                break;
            case "Float":
                attributeString = StringTypeHandler.BuildAttribute(segments[1..]);
                break;
            default:
                attributeString = StringTypeHandler.BuildAttribute(segments[1..]);
                break;
        }
        Console.WriteLine(attributeString);
        return "x";
    }
}