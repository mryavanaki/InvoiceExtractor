using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient chatClient = new OllamaApiClient(
    new Uri("http://localhost:11434/"),
    "llama3.2"
);

var email = """
  
  Hi, invoice INV-2041 from Acme traders dated 12 Oct 2026 for 
  45000 INR is due by 30 Oct 2026. Please process.  
  """;
  
var response = await chatClient.GetResponseAsync<Invoice>($"Extract the invoice details from this email:\\n{email}");

Console.WriteLine(response.Result);

record Invoice(
  string InvoiceNumber, 
  string Vendor, 
  DateTime InvoiceDate, 
  decimal Amount, 
  string Currency, 
  DateTime DueDate);
