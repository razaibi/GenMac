namespace Logic;

public class StringTypeHandler{
    public StringTypeHandler(){}

    public static string BuildAttribute(string[] segments){
        string attributeName="";
        string required="";
        string label="";
        string stringLength="";
        string defaultValue ="";
        string minLength="";
        string maxLength="";
        if(segments.ElementAtOrDefault(0) != null)
        {
            attributeName = Common.Capitalize(segments[0]);
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
            label = $"\t[Display(Name = \"{segments.ElementAtOrDefault(2)}\")]\n";
        }

        if(segments.ElementAtOrDefault(3) != null){
            stringLength = $"\t[StringLength({segments.ElementAtOrDefault(3)})]\n";
        }

        if(segments.ElementAtOrDefault(4) != null){
            defaultValue = $"= \"{segments[4]}\";";
        }

        if(segments.ElementAtOrDefault(5) != null){
            minLength = $"\t[MinLength({segments.ElementAtOrDefault(5)})]\n";
        }

        if(segments.ElementAtOrDefault(6) != null){
            maxLength = $"\t[MaxLength({segments.ElementAtOrDefault(6)})]\n";
        }

        return GenerateAttributeString(
            "string",
            attributeName,
            required,
            label,
            stringLength,
            defaultValue,
            minLength,
            maxLength
        );
    }

    public static string GenerateAttributeString(
        string attributeType,
        string attributeName,
        string required,
        string label="",
        string stringLength="",
        string defaultValue="",
        string minLength="",
        string maxLength=""
    ){
        return $"{required}{label}{stringLength}{minLength}{maxLength}\tpublic {attributeType} {attributeName} {{ get; set; }} { defaultValue }";
    }
}