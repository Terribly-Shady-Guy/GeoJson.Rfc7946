namespace Tk.GeoJson.Rfc7946.Generators;

internal readonly record struct ModifierTypeInfo
{
    public ModifierTypeInfo(string modifierNamespace, string modifierClassName)
    {
        Namespace = modifierNamespace;
        Name = modifierClassName;
    }

    public string Namespace { get; }
    public string Name { get; }
}
