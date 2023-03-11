using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Logic;


[Command("csp.gen.model")]
public class Generate : ICommand{
    [CommandParameter(0, Description = "Name of project.")]
    public string ProjectName { get; init; }="";
    [CommandParameter(1, Description = "Name of namespace.")]
    public string Namespace { get; init; }="Models";
    [CommandParameter(2, Description = "Name of model.")]
    public string ModelName { get; init; }="";
    [CommandParameter(3, Description = "List of attributes with datatype.")]
    public IReadOnlyList<String> Attributes { get; set; } = new List<string>();

    public ValueTask ExecuteAsync(IConsole console){
        // console.Output.WriteLine(Namespace);
        // console.Output.WriteLine(char.ToUpper(ModelName[0])  + ModelName.Substring(1));
        // foreach (var i in Attributes) {
        //     console.Output.WriteLine(i);
        // }
        ModelProcessor.Process(
            ProjectName,
            Namespace,
            ModelName,
            Attributes
        );
        return default;
    }
}