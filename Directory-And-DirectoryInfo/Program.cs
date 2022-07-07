CriarDiretoriosGlobo();
CriarArquivo();
var origem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
var destino = Path.Combine(Environment.CurrentDirectory,
        "globo",
        "América do Sul",
        "Brasil",
        "brasil.txt");
//MoverArquivo(origem, destino);
CopiarArquivo(origem, destino);


static void CopiarArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        System.Console.WriteLine("Arquivo não existe");
        return;

    }

    if (File.Exists(pathDestino))
    {
        System.Console.WriteLine("Arquivo Já Existe na pasta de destino");
        return;
    }
    File.Copy(pathOrigem, pathDestino);
}


static void MoverArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        System.Console.WriteLine("Arquivo não existe");
        return;

    }

    if (File.Exists(pathDestino))
    {
        System.Console.WriteLine("Arquivo Já Existe na pasta de destino");
        return;
    }

    File.Move(pathOrigem, pathDestino);
}


static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
    if (!File.Exists(path))
    {
        using var sw = File.CreateText(path);
        sw.WriteLine("População 213MM");
        sw.WriteLine("IDH: 0,901");
        sw.WriteLine("Dados Atualizados em: 23/06/2022");
    }



}

static void CriarDiretoriosGlobo()
{

    var path = Path.Combine(Environment.CurrentDirectory, "globo");
    if (!Directory.Exists(path))
    {
        var dirGlobo = Directory.CreateDirectory(path);
        var dirAmNorte = dirGlobo.CreateSubdirectory("América do Norte");
        var dirAmCentral = dirGlobo.CreateSubdirectory("América Central");
        var dirAmSul = dirGlobo.CreateSubdirectory("América do Sul");

        dirAmNorte.CreateSubdirectory("USA");
        dirAmNorte.CreateSubdirectory("México");
        dirAmNorte.CreateSubdirectory("Canada");

        dirAmCentral.CreateSubdirectory("Costa Rica");
        dirAmCentral.CreateSubdirectory("Panamá");

        dirAmSul.CreateSubdirectory("Brasil");
        dirAmSul.CreateSubdirectory("Argentina");
        dirAmSul.CreateSubdirectory("Paraguai");
    }


}




