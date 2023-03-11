using CaseExtensions;
namespace Logic;

public class BelongsToTypeHandler{
    public BelongsToTypeHandler(){}

    public static string BuildAttribute(string[] segments){
        string entityName="";
        string attributeName="";
        string foreignKeyTag="";
        string label="";

        if(segments.ElementAtOrDefault(0) != null)
        {
            entityName = segments[0].ToPascalCase();
            
        }

        if(segments.ElementAtOrDefault(1) != null)
        {
            attributeName = segments[1].ToPascalCase();
            foreignKeyTag = $"[ForeignKey(\"{attributeName}\")]";
        }

        if(segments.ElementAtOrDefault(2) != null){
            label = $"[Display(Name = \"{segments.ElementAtOrDefault(2)}\")]";
        }

        return GenerateAttributeString(
            entityName,
            attributeName,
            foreignKeyTag,
            label
        );

    }

    public static string GenerateAttributeString(
        string entityName,
        string attributeName,
        string foreignKeyTag,
        string label
    ){
        return @$"
        {label}
        {foreignKeyTag}
        public int {attributeName} {{ get; set; }}
        {label}
        public virtual {entityName}? {entityName} {{ get; set; }}";
    }
}