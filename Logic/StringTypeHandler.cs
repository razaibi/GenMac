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
            required = $"[Required()]";
        }

        if(segments.ElementAtOrDefault(2) != null){
            label = $"[Display(Name = \"{segments.ElementAtOrDefault(2)}\")]";
        }

        if(segments.ElementAtOrDefault(3) != null){
            stringLength = $"[StringLength({segments.ElementAtOrDefault(3)})";
        }

        if(segments.ElementAtOrDefault(4) != null){
            defaultValue = $"\"{segments[4]}\"";
        }

        if(segments.ElementAtOrDefault(5) != null){
            minLength = $"[MinLength({segments.ElementAtOrDefault(5)})]";
        }

        if(segments.ElementAtOrDefault(6) != null){
            maxLength = $"[MaxLength({segments.ElementAtOrDefault(6)})]";
        }

        return GenerateAttributeString(
            "String",
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
        return @$"
        {required}
        {label}
        {stringLength}
        {minLength}
        {maxLength}
        public {attributeType} {attributeName} {{ get; set; }} { defaultValue }";
    }
}