// See https://aka.ms/new-console-template for more information

using NameSorter.Controller;
using Microsoft.Extensions.Configuration;


IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("AppSettings.json", false)
    .Build();

//input file name 

string  fileName= args.Length!=0? args[0] :string.Empty;

if (fileName == string.Empty)
{
    Console.WriteLine("Please Input the Filename as Parameter.");
    return;
}

//output file name
string outputFileName =configuration.GetSection("outputFileName").Value??string.Empty;


//controller to manage the name sorter functionallity
NameSorterController names = new();
names.NameSorter(fileName,outputFileName);

