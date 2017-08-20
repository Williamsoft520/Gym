## Gym
easy use,easy stronger. easy extend. One step install and enjoy  all. It just exntensions for developer instead of using static class or tools in so called 'Utility'. No other thirdparty dependencies or assemblies. 
简单应用，易于扩展，一键安装，享受全部。用扩展的方式替代了曾经的静态方法或工具类，无任何第三方的额外依赖程序集。

## Install Package from Nuget（使用 Nuget 安装）
> Install-Package Gym

## Examples（示例）

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
        
    //extend ForEach for IEnumerable<T>
    new[]{ 1,2,3,4,5,6,7}.ForEach(item => Console.WriteLine(item));
    
### For more help please see [Wiki](wiki)
### 点击 [Wiki](wiki) 查看文档

## Latest Version v1.0（最新版本v1.0）
>Support Framework4.5+, Core1.0+, Standard 1.0+

>支持 Framework4.5+, Core1.0+, Standard 1.0+


