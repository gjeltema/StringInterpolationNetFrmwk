# String Interpolation Enhancements for non-.Net 6.0 projects

This set of classes enables the use of the C# 10 feature "string interpolation enhancements", described in detail in [Stephen Toub's blog post](https://devblogs.microsoft.com/dotnet/string-interpolation-in-c-10-and-net-6/), in projects that do not target .Net 6.0.

To utilize the feature, take the "DefaultInterpolatedStringHandler.cs" file from the "StringInterpolationNetFrmwk" project and drop it into your desired project(s),
and then set the project(s) to target C# 10 or newer.  There are several ways to do this, such as adding this file to a single project that it referenced by many other projects, or by linking to this single
file from many of the projects, or just copy-pasting this file into each project.  It is a personal preference as to how the consumer desires to structure their solution(s).

The other files, "LoggerConditionalInterpolator.cs", and "SimpleLoggerAbstraction.cs", are here purely as examples on how to create custom string interpolators for a common scenario.  The method utilized here 
(creating separate interpolators for each logging level) is the one recommended by Stephen to a commenter on his above linked blog post.

The `CharArrayPoolTests` class actually also tests the custom `DefaultInterpolatedStringHandler` indirectly.