using CaseExtensions;
namespace Logic;

public class DateTimeTypeHandler{
    public DateTimeTypeHandler(){}

    public static string BuildAttribute(string[] segments){
        string attributeName="";
        string required="";
        string label="";
        string defaultValue ="";
        if(segments.ElementAtOrDefault(0) != null)
        {
            attributeName = segments[0].ToPascalCase();
        }

        string requiredTag="";
        if(segments.ElementAtOrDefault(1) != null){
            requiredTag = segments.ElementAtOrDefault(1) ?? "";
            if (
                requiredTag == "req" ||
                requiredTag == "true" ||
                requiredTag == "required"
            )
            required = $"\t[Required()]\n";
        }

        if(segments.ElementAtOrDefault(2) != null){
            label = $"\t[Display(Name = \"{segments.ElementAtOrDefault(2).ToPascalCase()}\")]\n";
        }

        if(segments.ElementAtOrDefault(3) != null){
            defaultValue = $" = new DateTime({segments[3].ToLower()});";
        }

        return GenerateAttributeString(
            "DateTime",
            attributeName,
            required,
            label,
            defaultValue
        );

    }

    public static string GenerateAttributeString(
        string attributeType,
        string attributeName,
        string required,
        string label="",
        string defaultValue=""
    ){
        return $"{required}{label}\tpublic {attributeType} {attributeName} {{ get; set; }} { defaultValue }";
    }
}