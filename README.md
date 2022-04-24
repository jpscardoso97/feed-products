## SaaS Products Import

### Execution of code
- To run tests simply execute:  `dotnet test on the solution file`
- To run code execute: `dotnet run --project ProductsImporter/ProductsImporter import capterra input/capterra.yaml` or `dotnet run --project ProductsImporter/ProductsImporter import software-advice input/softwareadvice.json`

### Considerations
    - Codebase is under ProductsImporter folder
    - The answers for the Database Questions are in the answers.md under database folder.  
    - First time writing command line commands for a .NET application (used to build Web APIs) 
    - If I had more time I'd try to improve the importer factory to use something better than Enum to resolve each provider.
    - Regarding tests it would also be good to have a sample of each type of input file so that the parsers were also being tested.
