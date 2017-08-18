## Gym
There are a lot of extensions for instance and tools the we always use in our logical code. It represents by extension methods and same namespace with System, so it is very easy to use without write any other namespaces and references.

## Install Package from Nuget
> Install-Package Gym

## Examples

    var str = "sample";
    
    //use traditional way
    if(stirng.IsNullOrEmpty(str)){ ... }
    
    //use Gym
    if(str.IsNullOrEmpty()){ ... }
    
    //use traditional
    string.Format("this is {0}, maybe has {1}....", name, person);
    
    //use Gym
    "this is {0}, maybe has {1} ....".StringFormat(name,person);
    
    of course you can use C#6.0 grammer
    $"this is {name}, maybe has {person}";
    
    //convert a string to base64 string
    "sample".ToBase64String();
    
    //convert a string from base64 string
    "YWRtaW5pc3RyYXRvcg==".FromBase64String();
    
    //to MD5
    "administrator".CryptoForMD5();
    
    //to SHA256
    "microsoft".CryptoForSHA256();
    
    //extend ForEach for IEnumerable<T>
    new[]{ 1,2,3,4,5,6,7}.ForEach(item => Console.WriteLine(item));
    
### For more help please see [Wiki](wiki)

## Latest Version 3.5
* Upgrade to .NET Standard 2.0
* remove DescriptionAttribute becaulse .NET Standard 2.0 had been added from System.ComponentModel
* add IPagedCollection and default instance PagedCollection
* add Linq Extension for Paged with IPagedCollection
* add NameValueCollection extension for GetOrDefault
* add Serialize/Deserialize for xml string in XmlExtension

## Platform Support
* .NET Framework 4.6.1+
* .NET Core 2.0+
* .NET Standard 2.0+

