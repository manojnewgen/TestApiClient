// See https://aka.ms/new-console-template for more information
using System.Net.Http;

using PersonApi;
var httpClient= new HttpClient();
var apiBaseUrl= "http://localhost:5047";
var client= new PersonApi.PersonApiClient(apiBaseUrl, httpClient);

var persons= await client.PersonsAsync();

Console.WriteLine("Person List");
var count=1;
if(persons !=null){
foreach(var person in persons){
    
   Console.WriteLine($"{count}- Person Name:{person.UserName}\nPerson Age: {person.Age}");
   count+=1;
}
}


await new SwaggerClientGenerator().GenerateClient(); // this the code to generate the client



// Console.WriteLine("Hello, World!");

// var httpClient= new HttpClient();
// var apiBaseUrl= "http://localhost:5047";

// var httpsResult= await httpClient.GetAsync($"{apiBaseUrl}/persons");

// if(httpsResult.StatusCode!= System.Net.HttpStatusCode.OK){
//      Console.WriteLine("Failed to fetch person details");
//      return;
// }

// var personStream= await httpsResult.Content.ReadAsStreamAsync();
// var options= new System.Text.Json.JsonSerializerOptions{
//  PropertyNameCaseInsensitive=true
// };

// var persons= await System.Text.Json.JsonSerializer.DeserializeAsync<List<Person>>(personStream, options);

// if(persons is not null)
//     foreach(var person in persons){
//         Console.WriteLine($"Name- {person.UserName}\n Age: {person.Age}");
//     }

// public class Person{
//     required public string UserName{get;set;}
//     required public int Age{get;set;}


// }