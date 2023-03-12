# GenMac
CLI driven code generator.

## Installation

```bash
dotnet tool install --global GenMac
```

## Universal Syntax for Generating C# Models.

```bash 
genmac csp.model <dataType>:<attribute-name>:<required>:<label>
```

## Syntax for C# attributes

### For String Attribute

```bash
string:<attribute-name>:<required>:<label:optional>:<length:optional>:<default:optional>:<minlength:optional>:<maxlength:optional>
```

A Title attribute of type string can look like this.
```bash
string:title:required:Title:40:NA:3:40
```

This will generate an attribute like below.

```csharp
[Required()]
[Display(Name = "Title")]
[StringLength(40)]
[MinLength(3)]
[MaxLength(40)]
public string Title { get; set; } = "NA";
```

### For Integer Attribute

```bash
int:<attribute-name>:<required>:<label:optional>:<default:optional>:<minvalue:optional>:<maxvalue:optional>
```

A Count attribute of type integer can look like this.
```bash
int:count:required:Count:10:5:50
```

This will generate an attribute like below.

```csharp
[Required()]
[Display(Name = "Count")]
[Range(5, 50)]
public int Count { get; set; }  = 10;
```

### For Has Many (Relation) Attribute

```bash
hasmany:<attribute-name>:<label:optional>
```

Establishing a "has many" relation can be done like this.

```bash
hasmany:locations:Locations
```

This will generate an attribute like below.

```csharp
[Display(Name = "Locations")]
public virtual List<Location> Locations { get; set; } = new List<Location>();
```

### For Belongs To (Relation) Attribute

```bash
belongsto:<entity-name>:<attribute-name>:<label:optional>
```

A foreign key referencing another table can be done like this.

```bash
belongsto:organization:organization-id:Organization
```

This will generate an attribute like below.

```csharp
[Display(Name = "Organization")]
[ForeignKey("OrganizationId")]
public int OrganizationId { get; set; }
[Display(Name = "Organization")]
public virtual Organization? Organization { get; set; }
```


### For Boolean Attribute

```bash
bool:<attribute-name>:<required>:<label:optional>:<default:optional>
```

Something like an "Is Archived" attribute og type bool can look like this.
```bash
bool:is-archived:req:"Is Archived":false
```

This will generate an attribute like below.

```csharp
[Required()]
[Display(Name = "IsArchived")]
public bool IsArchived { get; set; }  = false;
```


### For DateTime Attribute

```bash
datetime:<attribute-name>:<required>:<label:optional>:<default:optional>
```

Something like a Created On attribute of type datetinme can look like this.
```bash
datetime:created-on:req:CreatedOn:12,3,2022
```

This will generate an attribute like below.

```csharp
[Required()]
[Display(Name = "CreatedOn")]
public DateTime CreatedOn { get; set; }  = new DateTime(12,3,2005);
```

# Usage Example

```bash
genmac csp.model models sample string:title string:desc:required:Description:40:NA:3:40 int:count:required:Count:10:5:50 hasmany:locations:Locations belongsto:organization:organization-id:Organization bool:is-archived:req:"Is Archived":false datetime:created-on:req:CreatedOn
```

## Status

New data types anf flags coming soon.
