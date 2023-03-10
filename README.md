# GenMac
CLI driven code generator.

## Syntax

### For String Attributes

```bash
string:<name>:<required>:<label:optional>:<length:optional>:<default:optional>:<minlength:optional>:<maxlength:optional>
```

### For Integer Attributes

```bash
int:<name>:<required>:<label:optional>:<default:optional>:<minvalue:optional>:<maxvalue:optional>
```


## How to Use

Example

```bash
dotnet run gen.model sample samplens project string:title string:desc:required:Description:40:NA:3:40 int:count:required:Count:10:5:50
```

## Status

Work in progress: clean up and enhancements coming soon.
