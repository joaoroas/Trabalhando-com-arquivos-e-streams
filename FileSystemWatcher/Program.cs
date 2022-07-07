

var path = @"C:\Temp\globo";
using var fsw = new FileSystemWatcher(path);


fsw.Created += OnCreated;
fsw.Created += OnDeleted;
fsw.Created += OnRenamed;

fsw.EnableRaisingEvents = true;
fsw.IncludeSubdirectories = true;

Console.ReadLine();
Console.WriteLine("Pressione enter para finalizar");

void OnCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Foi criado o arquivo {e.Name}");
}


void OnDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Foi excluido o arquivo {e.Name}"); 
}


void OnRenamed(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.Name}");
}