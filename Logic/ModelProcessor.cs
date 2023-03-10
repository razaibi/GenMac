namespace Logic;

public class ModelProcessor{
    public ModelProcessor(){}

    public static string GetProjectName(string Name){
        return char.ToUpper(Name[0])  + Name.Substring(1);
    }

    public static string GetNamespace(string Name){
        return char.ToUpper(Name[0])  + Name.Substring(1);
    }

    public static string Capitalize(string Name){
        return char.ToUpper(Name[0])  + Name.Substring(1);
    }



    public static string GetNormalizedType(
        string attributeType
    ){
        string typeString;
        attributeType=Capitalize(attributeType);
        switch(attributeType) 
        {
        case "Bool":
            typeString = "Boolean";
            break;
        case "Boolean":
            typeString = "Boolean";
            break;
        case "True":
            typeString = "Boolean";
            break;
        case "False":
            typeString = "Boolean";
            break;
        case "Byt":
            typeString = "Byte";
            break;
        case "Byte":
            typeString = "Byte";
            break;
        case "Char":
            typeString = "Char";
            break;
        case "Decimal":
            typeString = "Decimal";
            break;
        case "Dec":
            typeString = "Decimal";
            break;
        case "Dbl":
            typeString = "Double";
            break;
        case "Double":
            typeString = "Double";
            break;
        case "Sgl":
            typeString = "Single";
            break;
        case "Single":
            typeString = "Single";
            break;
        case "Int":
            typeString = "Int32";
            break;
        case "Int32":
            typeString = "Int32";
            break;
        case "Int64":
            typeString = "Int64";
            break;
        case "Obj":
            typeString = "Object";
            break;
        case "Object":
            typeString = "Object";
            break;
        case "Dyn":
            typeString = "Object";
            break;
        case "Dynamic":
            typeString = "Object";
            break;
        case "Str":
            typeString = "String";
            break;
        case "String":
            typeString = "Object";
            break;

        default:
            typeString = "String";
            break;
        }

        return typeString;
    }


    public static void Process(
        string projectName,
        string namespaceName,
        string modelName,
        IReadOnlyList<string> attributesList
    ){
        projectName = Capitalize(projectName);
        namespaceName = Capitalize(namespaceName);
        modelName = Capitalize(modelName);

        foreach (var a in attributesList){
            string[] segments = a.Split(":", StringSplitOptions.TrimEntries);


            TypeHandler.HandleType(
                segments
            );
            
        }
    }


}