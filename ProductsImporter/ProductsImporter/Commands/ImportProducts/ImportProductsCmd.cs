namespace ProductsImporter.Commands.ImportProducts;

using McMaster.Extensions.CommandLineUtils;

[Command(Name = "import", OptionsComparison = StringComparison.InvariantCultureIgnoreCase)]
[Subcommand(
    typeof(CapterraImportCmd),
    typeof(SoftwareAdviceImportCmd))]
[HelpOption("--help")]
public class ImportProductsCmd
{
    public async Task OnExecute(CommandLineApplication app)
    {
        app.ShowHelp();
    }
}