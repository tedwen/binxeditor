BinxEd - A BinXML GUI Editor
============================

### Introduction

BinX is a language to markup binary data streams using XML, and BinxEd is a GUI editor to create BinX document. (This is the unreleased C# version.)

### Features

Create a new BinX document by adding types and data elements through wizard
Save created BinX document
Open a BinX document for editing
Save the document as another file
View BinX data elements in a tree view
User-defined types listed in the left window and dataset in the right
Toolbar buttons as well as menus
Right click on tree view windows pop up context menus
Editing includes append, insert a sibling or child node, delete a node
Validate a BinX file against BinX schema

### Restrictions

Support BinX 1.1 published data types only, for example, no Quadruple-128.
No embedded struct, array or union types in definitions section
No direct struct, array or union data elements in dataset section
No node modify function (use delete and insert new)
Can load BinX document not created by the editor, but further operation may lead to error.

### Contact

**Ted Wen**

+ http://twitter.com/tedwen
+ http://github.com/tedwen

### License

This software is released under the Apache License, Version 2.0. See the LICENSE file for details.