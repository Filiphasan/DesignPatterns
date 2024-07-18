namespace OptionsDp.Common.Options;

public class RuntimeSettingOptiponModel
{
    public const string SectionName = "Settings";

    public required string Environment { get; init; }
    public required string Version { get; init; }
}