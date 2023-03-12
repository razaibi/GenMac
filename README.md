# GenMac
CLI driven code generator.

## Installation

```bash
dotnet tool install --global GenMac
```

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

### For Boolean Attribute

```bash
bool:<attribute-name>:<required>:<label:optional>:<default:optional>
```

### For DateTime Attribute

```bash
datetime:<attribute-name>:<required>:<label:optional>:<default:optional>
```

Something like a created on attribute can look like this.
```bash
datetime:created-on:req:CreatedOn:12,3,2022
```

This will generate an attribute like below.

```csharp
[Required()]
[Display(Name = "CreatedOn")]
public DateTime CreatedOn { get; set; }  = new DateTime(12,3,2005);
```

## How to Use

Example

```bash
genmac csp.model models sample string:title string:desc:required:Description:40:NA:3:40 int:count:required:Count:10:5:50 hasmany:locations:Locations belongsto:organization:organization-id:Organization bool:is-archived:req:"Is Archived":false datetime:created-on:req:CreatedOn
```

## Status

Work in progress: clean up and enhancements coming soon.
