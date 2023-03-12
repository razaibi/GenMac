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
            foreignKeyTag = $"\t[ForeignKey(\"{attributeName}\")]\n";
        }

        if(segments.ElementAtOrDefault(2) != null){
            label = $"\t[Display(Name = \"{segments.ElementAtOrDefault(2)}\")]\n";
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
        var firstLine = $"{label}{foreignKeyTag}\tpublic int {attributeName} {{ get; set; }}";
        var secondLine = $"\n{label}\tpublic virtual {entityName}? {entityName} {{ get; set; }}";
        return firstLine + secondLine;
    }
}