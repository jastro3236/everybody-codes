
using CommandLine;

namespace EverybodyCodes.Worker
{
    public class CLIArguments
    {
        [Option('n', "name", Required = true, HelpText = "Pass name (or part of a name) of the camera you are looking for")]
        public string SearchName { get; set; } = string.Empty;
    }
}
