using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

//LerCSVComDynamic();
//LerCSVComClasse();
//LerCSVComOutroDelimitador();
EscreverCsv();


Console.WriteLine("Digite enter para finalizar:");
Console.ReadLine();

static void EscreverCsv()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Saida");

    var di = new DirectoryInfo(path);

    if (!di.Exists)
        di.Create();

    path = Path.Combine(path, "usuarios.csv");

    var pessoas = new List<Pessoa>()
    {
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "js@gmail.com",
            Telefone = 123456,
        },
        new Pessoa()
        {
            Nome = "Pedro Paiva",
            Email = "pp@gmail.com",
            Telefone = 456789,
        },
        new Pessoa()
        {
            Nome = "Maria Antonia",
            Email = "ma@gmail.com",
            Telefone = 123456,
        },
        new Pessoa()
        {
            Nome = "Carla Moraes",
            Email = "cms@gmail.com",
            Telefone = 9987411,

        },
    };

    using var sr = new StreamWriter(path);
    using var csvWriter = new CsvWriter(sr,CultureInfo.InvariantCulture);
    csvWriter.WriteRecords(pessoas);

}

static void LerCSVComOutroDelimitador()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "Livros-com-ponto-virgula.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe");


    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };

    using var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>();
    var registros = csvReader.GetRecords<Livros>().ToList();

    foreach (var registro in registros)
    {
        Console.WriteLine($"Título:{registro.Titulo}");
        Console.WriteLine($"Preço:{registro.Preco}");
        Console.WriteLine($"Autor:{registro.Autor}");
        Console.WriteLine($"Lançamento:{registro.Lancamento}");
        Console.WriteLine("--------");

    }
}


static void LerCSVComClasse()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "novos-usuarios.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<Usuario>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome:{registro.Nome}");
        Console.WriteLine($"Email:{registro.Email}");
        Console.WriteLine($"Telefone:{registro.Telefone}");
        Console.WriteLine("--------");

    }
}


static void LerCSVComDynamic()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "Produtos.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} não existe");


    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<dynamic>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome:{registro.Produto}");
        Console.WriteLine($"marca:{registro.Marca}");
        Console.WriteLine($"preço:{registro.Preco}");
        Console.WriteLine("--------");

    }
}