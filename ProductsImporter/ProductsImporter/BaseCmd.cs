namespace ProductsImporter;

using McMaster.Extensions.CommandLineUtils;
using ProductsImporter.Commands.ImportProducts;

[Command(OptionsComparison = StringComparison.InvariantCultureIgnoreCase)]
[Subcommand(typeof(ImportProductsCmd))]
public class BaseCmd
{
    public async Task OnExecute(CommandLineApplication app)
    {
        app.ShowHelp();
    }
}