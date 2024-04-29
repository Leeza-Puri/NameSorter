# NameSorter
It sorts list of names. Given a set of names, order that set first by last name, then by any given names the
person may have. 

**Validations**
A name must have at least 1 given name and may have up to 3 given names.

**Output** 
File in the working directory called sorted-names-list.txt containing the sorted names.

# About the Project

**Controller** - Responsible for sorting the names list 
**Model** - Person model  
**Business Logic** - Manage/Handle the main functionality 
**Common** - Common Utility for reading and writing the files. 

# Installation
**Build**
If you build code directly, you need VS 2022 installed. For installation.

**Compile**
Clone or Download this git after that extract the code and compile it

**Build Pipeline**
Integrated with GitHub Actions to trigger the build on every checkin.
On every build Running Unit test cases to verify the functionality

https://github.com/Leeza-Puri/NamesSorter/actions

### Run

```html
name-sorter ./unsorted-names-list.txt
```
