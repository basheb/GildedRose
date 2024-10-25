# Gilded Rose starting position in C# xUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

```cmd
dotnet build GildedRose.sln -c Debug
```

For this, you need to have the .NET SDK installed on your machine.
https://dotnet.microsoft.com/en-us/download

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

```cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

```cmd
dotnet test
```

## Explanations:

- The `GildedRose` class is the main class, where the `UpdateQuality` method is called.
  - Then `UpdateQuality` method calls the ItemUpdaterFactory and creates a specific ItemUpdater based on each item.
- The `Item` class is the class that represents an item.
- The `Program` class is the class that contains the `Main` method.
- The `GildedRoseTest` class is the class that contains the unit tests.

## IMPORTANT CHANGE:

The requirements description found on https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/main/GildedRoseRequirements.md suggests that Conjured items decrease in quality twice as fast as the normal items. However, the original unit tests did not implement this. I have implemented this change in the unit tests then wrote the code accordingly.
