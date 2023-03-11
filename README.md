# GenMac
CLI driven code generator.

## Syntax

### For String Attribute

```bash
string:<name>:<required>:<label:optional>:<length:optional>:<default:optional>:<minlength:optional>:<maxlength:optional>
```

### For Integer Attribute

```bash
int:<name>:<required>:<label:optional>:<default:optional>:<minvalue:optional>:<maxvalue:optional>
```

### For Has Many (Relation) Attribute

```bash
hasmany:<name>:<label:optional>
```


## How to Use

Example

```bash
dotnet run gen.model sample samplens project string:title string:desc:required:Description:40:NA:3:40 int:count:required:Count:10:5:50 hasmany:locations:Locations
```

## Status

Work in progress: clean up and enhancements coming soon.
