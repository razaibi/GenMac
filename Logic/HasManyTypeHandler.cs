using Pluralize.NET;
namespace Logic;

public class HasManyTypeHandler{
    public HasManyTypeHandler(){}

    public static string BuildAttribute(string[] segments){
        IPluralize pluralizer = new Pluralizer();
        string attributeSingularName="";
        string attributePluralName="";
        string label="";

        if(segments.ElementAtOrDefault(0) != null)
        {
            attributePluralName = Common.Capitalize(segments[0]);
            attributeSingularName = pluralizer.Singularize(attributePluralName);
            
        }

        if(segments.ElementAtOrDefault(1) != null){
            label = $"[Display(Name = \"{segments.ElementAtOrDefault(1)}\")]";
        }

        return GenerateAttributeString(
            attributeSingularName,
            attributePluralName,
            label
        );

    }

    public static string GenerateAttributeString(
        string attributeSingularName,
        string attributePluralName,
        string label
    ){
        return @$"
        {label}
        public virtual List<{attributeSingularName}> {attributePluralName} {{ get; set; }} = new List<{attributeSingularName}>();";
    }
}