using Pluralize;
using Pluralize.NET;
using CaseExtensions;

namespace Logic;

public class TemplatesProcessor{
    public TemplatesProcessor(){}

    public async static ValueTask Process(
    string projectName,
    string modelName,
    IReadOnlyList<string> attributesList
    ){
        IPluralize pluralizer = new Pluralizer();
        await AddDbContext(
            projectName,
            modelName,
            pluralizer.Pluralize(modelName)
        );
    }

    public async static ValueTask AddDbContext(
        string projectName,
        string modelName,
        string modelPluralName
    ){
        modelName = modelName.ToPascalCase();
        modelPluralName = modelPluralName.ToPascalCase();
        var dbContextTemplate = @$"using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace {projectName}.Data
{{
    public class AppDBContext : DbContext
    {{
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {{

        }}
        public DbSet<{modelName}> {modelPluralName} {{ get; set; }}
    }}
}}
";
        await File.WriteAllTextAsync($"AppDbContext.cs", dbContextTemplate);
    }
    public async static ValueTask AddDataService(
        string projectName,
        string modelName,
        string modelNamePlural
    )
    {
        projectName = projectName.ToPascalCase();
        modelName = modelName.ToPascalCase();
        string modelNameLower = modelName.ToLower();
        var dbDataServiceTemplate = @$"using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace {projectName}.Data
{{
    public class {modelName}Service
    {{
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public {modelName}Service(AppDBContext appDBContext)
        {{
            _appDBContext = appDBContext;
        }}
        #endregion

        #region Get List of {modelNamePlural}
        public async Task<List<{modelName}>> GetAll{modelNamePlural}Async()
        {{
            return await _appDBContext.{modelNamePlural}.ToListAsync();
        }}
        #endregion

        #region Insert {modelName}
        public async Task<bool> Insert{modelName}Async({modelName} {modelNameLower})
        {{
            await _appDBContext.{modelNamePlural}.AddAsync({modelNameLower});
            await _appDBContext.SaveChangesAsync();
            return true;
        }}
        #endregion

        #region Get {modelName} by Id
        public async Task<{modelName}> Get{modelName}Async(int Id)
        {{
            {modelName} {modelNameLower} = await _appDBContext.{modelNamePlural}.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return {modelName};
        }}
        #endregion

        #region Update {modelName}
        public async Task<bool> Update{modelName}Async({modelName} {modelNameLower})
        {{
             _appDBContext.{modelNamePlural}.Update({modelNameLower});
            await _appDBContext.SaveChangesAsync();
            return true;
        }}
        #endregion

        #region Delete {modelName}
        public async Task<bool> Delete{modelName}Async({modelName} {modelNameLower})
        {{
            _appDBContext.Remove({modelNameLower});
            await _appDBContext.SaveChangesAsync();
            return true;
        }}
        #endregion
    }}
}}
";        
        await File.WriteAllTextAsync($"{modelName}Service.cs", dbDataServiceTemplate);
    }
    public async static void AddListScreen(
    ){
        await File.WriteAllTextAsync($"AppDbContext", "abc");
    }

    public async static void AddCreateScreen(
    ){
        await File.WriteAllTextAsync($"AppDbContext", "abc");
    }

    public async static void AddDeleteScreen(
    ){
        await File.WriteAllTextAsync($"AppDbContext", "abc");
    }

}