using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Logic;
using Pluralize.NET;

[Command("csp.model")]
public class GenerateCspModel : ICommand{
    [CommandParameter(0, Description = "Name of namespace.")]
    public string Namespace { get; init; }="Models";
    [CommandParameter(1, Description = "Name of model.")]
    public string ModelName { get; init; }="";
    [CommandParameter(2, Description = "List of attributes with datatype.")]
    public IReadOnlyList<String> Attributes { get; set; } = new List<string>();

    public async ValueTask ExecuteAsync(IConsole console){
        // console.Output.WriteLine(Namespace);
        // console.Output.WriteLine(char.ToUpper(ModelName[0])  + ModelName.Substring(1));
        // foreach (var i in Attributes) {
        //     console.Output.WriteLine(i);
        // }
        await ModelProcessor.Process(
            Namespace,
            ModelName,
            Attributes
        );
    }
}

[Command("csp.data.context")]
public class GenerateCspDbContext : ICommand{
    [CommandParameter(0, Description = "Name of project.")]
    public string ProjectName { get; init; }="";
    [CommandParameter(1, Description = "Name of model.")]
    public string ModelName { get; init; }="";
    
    public async ValueTask ExecuteAsync(IConsole console){
        IPluralize pluralizer = new Pluralizer();
        await TemplatesProcessor.AddDbContext(
            ProjectName,
            ModelName,
            pluralizer.Pluralize(ModelName)
        );
    }
}


[Command("csp.data.service")]
public class GenerateCspDataService : ICommand{
    [CommandParameter(0, Description = "Name of project.")]
    public string ProjectName { get; init; }="";
    [CommandParameter(1, Description = "Name of model.")]
    public string ModelName { get; init; }="";
    
    public async ValueTask ExecuteAsync(IConsole console){
        IPluralize pluralizer = new Pluralizer();
        await TemplatesProcessor.AddDataService(
            ProjectName,
            ModelName,
            pluralizer.Pluralize(ModelName)
        );
    }
}