*This project is pretty much abandoned. But there is a fork on GitHub: https://github.com/Muraad/Mime-Detective These guys have a lot more types detectable, but no NuGet package yet -(*

# Description
Library to decide what type of file we are working with. Detects file types by header, not by file extension.

Every file has an extension and if it is a binary file, it has magic numbers in the header of the file that indicate what type of file it is. It is not always easy to work out programmatically what type of file it is, if there is no (or incorrect) extension. This library provides an easy way of identifying the file types.


At the moment library can detect files of types: 
Microsoft Word, Microsoft Excel, Microsoft PowerPoint, PDF, JPEG, ZIP, RAR, RTF, PNG, GIF

Great news. Nuget package is now available:

```
PM> Install-Package FileTypeDetective
```


Not many types are supported, I know!
But it is easy to extend and add new types yourself. If you require new types, please let me know.

Downloadable zip includes source code, compiled DLL file and help file with API description (generated from XML comments).
Or you can download the entire project from the source code and have a bash-on yourself. Source code also includes unit-tests.

The idea of the library is to be able to call isPdf(), isZip(), isDoc(), ect. on FileInfo objects:

 
```c#
FileInfo file = new FileInfo("C:\Hello.pdf");
if ( file.isPdf())
    Console.WriteLine("File is PDF");
```

There are some examples on Documentation page.
