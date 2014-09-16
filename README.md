SharePoint Formula Builder 
==========================

Fluent API for building Sharepoint calculated fields programatically by using LINQ expressions with Visual Studo intellisense support. It is very useful if you want to automatically build your application structure (mainly SP lists) programatically. In the next section, you can find few examples. More can be found in SPFormulaBuilderTests project. Project is fully unit-tested.  

Simple Example
--------------

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

LINQ expressions
----------------

In following example we will build calculated field formula using LINQ expression. Again, imagine we want to build following formula programatically:

``=Column1+Column2+Column3``

And this transforms in SPFormulaBuilder`s fluent API to:

```csharp
SPFormulaBuilder.CreateFormula(
    new Expression(
        () => new ColumnReference("Column1") + new ColumnReference("Column2") + new ColumnReference("Column3")
    )
)
```

You could notice usage of '+' sign in the expression. 

License
-------
The MIT License (MIT)

Copyright (c) 2013 Marek Suscak
http://suscak.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
