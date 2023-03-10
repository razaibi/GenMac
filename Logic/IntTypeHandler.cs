namespace Logic;

public class IntTypeHandler{
    public IntTypeHandler(){}

    public static string BuildAttribute(string[] segments){
        string attributeName="";
        string required="";
        string label="";
        string defaultValue ="";
        string range="";
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
            defaultValue = $" = \"{segments[3]}\"";
        }

        if(segments.ElementAtOrDefault(4) != null){
            if(segments.ElementAtOrDefault(5) != null){
                range = $"[Range({segments.ElementAtOrDefault(4)}, {segments.ElementAtOrDefault(5)})]";
            }else{
                range = $"[Range({segments.ElementAtOrDefault(4)}, Int32.MaxValue)]";
            }
            
        }

        

        return GenerateAttributeString(
            "int",
            attributeName,
            required,
            label,
            defaultValue,
            range
        );

    }

    public static string GenerateAttributeString(
        string attributeType,
        string attributeName,
        string required,
        string label="",
        string defaultValue="",
        string range=""
    ){
        return @$"
        {required}
        {label}
        {range}
        public {attributeType} {attributeName} {{ get; set; }} { defaultValue }";
    }
}