# GenMac
CLI driven code generator.

## Syntax

### For String Attribute

```bash
string:<attribute-name>:<required>:<label:optional>:<length:optional>:<default:optional>:<minlength:optional>:<maxlength:optional>
```

### For Integer Attribute

```bash
int:<attribute-name>:<required>:<label:optional>:<default:optional>:<minvalue:optional>:<maxvalue:optional>
```

### For Has Many (Relation) Attribute

```bash
hasmany:<attribute-name>:<label:optional>
```

### For Belongs To (Relation) Attribute

```bash
belongsto:<entity-name>:<attribute-name>:<label:optional>
```


## How to Use

Example

```bash
dotnet run csp.model models sample string:title string:desc:required:Description:40:NA:3:40 int:count:required:Count:10:5:50 hasmany:locations:Locations belongsto:organization:organization-id:Organization
```

## Status

Work in progress: clean up and enhancements coming soon.
