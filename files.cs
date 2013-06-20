using System.IO;
using System;
namespace FileApp{
	class FilesShow{
		static void Main(string[] args){
			if (args.Length == 0) {
			    string[] files = Directory.GetFiles("d:\\my_projects\\c#", "*.cs", SearchOption.AllDirectories);
			    File.WriteAllLines("filecache.snarf", files);
			} else {
				string[] cache = File.ReadAllLines("filecache.snarf");
			    foreach(string file in cache) {
			        if (file.Contains(args[0])) {
			            Console.Write(File.ReadAllText(file));
					}
				}
			}
		}
	}
}
//string textFile = File.ReadAllText("hello.cs") ;
//textFile += "\n //some comment" ;
//File.WriteAllText("hello.cs", textFile);
//System.Console.Write(textFile);
//System.Console.ReadLine();