# unity-table-from-json
An example of how to read data using Json.Net to fill a dynamic table on the UI of Unity applications.

Specially made to handle *JSON data with dynamic fields*, i.e. if a data item doesn't have the field `Role` but others do, it won't fail (look at the seconds item in the example below).

The JSON file in `/StreamingAssets/` should have 3 fields at least: Title, ColumnHeaders and Data, and the file name can be changed in the inspector through the object `Game Controller`. 

# JSON Example

```
{
    "Title": "Team Members",
    "ColumnHeaders":
    [
        "ID",
        "Name",
        "Role",
        "Nickname"
    ],
    "Data" :
    [
        {
            "ID" : "001",
            "Name" : "John Doe",
            "Role" : "Engineer",
            "Nickname" : "KillerJo",
        },
        {
            "ID" : "023",
            "Name" : "Claire Dawn",
            "Nickname" : "Claw",
        },
        {
            "ID" : "012",
            "Name" : "Paul Beef",
            "Role" : "Designer",
            "Nickname" : "BeefyPaul",
        },
        {
            "ID" : "056",
            "Name" : "Sally Sue",
            "Role" : "Artist",
            "Nickname" : "Sue5555",
        },
    ]
}
```

Note: This code will NOT fail if a data item does not have a field (for some column header).



