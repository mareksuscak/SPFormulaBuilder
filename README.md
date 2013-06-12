SharePoint Formula Builder 
==========================

Fluent API for building Sharepoint calculated fields programatically by using LINQ expressions with Visual Studo intellisense support. It is very useful if you want to automatically build your application structure (mainly SP lists) programatically. In the next section, you can find few examples. More can be found in SPFormulaBuilderTests project. Project is fully unit-tested.  

Example
-------

Imagine, you want to build following calculated field formula programatically:

``=IF(ISNUMBER(FIND("v",Column1)),"OK","Not OK")``

With SPFormulaBuilder it's as easy as:

```csharp
SPFormulaBuilder.CreateFormula(
    new If(
        new IsNumber(
            new Find(
                new StringLiteral("v"),
                new ColumnReference("Column1")
            )
        ),
        new StringLiteral("OK"),
        new StringLiteral("Not OK")
    )
)
```