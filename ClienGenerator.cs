using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;

public class SwaggerClientGenerator{
    public async Task GenerateClient(){
        var httpClient= new HttpClient();
        var swaggerJosn= await httpClient.GetStringAsync("http://localhost:5047/swagger/v1/swagger.json");
        var document= await OpenApiDocument.FromJsonAsync(swaggerJosn);
        var settings= new CSharpClientGeneratorSettings{
            ClassName= "PersonApiClient",
            CSharpGeneratorSettings= {
                Namespace= "PersonApi"
            }
        };
        var generator= new CSharpClientGenerator(document, settings);
        var code= generator.GenerateFile();
        await File.WriteAllTextAsync("PersonApiClient.cs", code);
    }
}