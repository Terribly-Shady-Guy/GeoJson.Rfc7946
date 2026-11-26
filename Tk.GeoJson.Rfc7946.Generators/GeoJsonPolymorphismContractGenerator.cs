using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Tk.GeoJson.Rfc7946.Generators;

[Generator]
internal sealed class GeoJsonPolymorphismContractGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<ModifierTypeInfo?> modifierProvider = context.SyntaxProvider
            .ForAttributeWithMetadataName<ModifierTypeInfo?>(
            fullyQualifiedMetadataName: "Tk.GeoJson.Rfc7946.GeneratedGeoJsonModifierAttribute",
            predicate: static (node, _) => node is ClassDeclarationSyntax { BaseList.Types.Count: > 0 },
            transform: static (context, token) =>
            {
                var modifierClassDeclaration = (ClassDeclarationSyntax)context.TargetNode;
                if (context.SemanticModel.GetDeclaredSymbol(modifierClassDeclaration, token) is not INamedTypeSymbol modifierClassSymbol)
                {
                    return null;
                }

                INamedTypeSymbol? targetBaseType = context.SemanticModel.Compilation
                    .GetTypeByMetadataName("Tk.GeoJson.Rfc7946.GeoJsonDerivedTypesModifierBase");

                INamedTypeSymbol? currentBaseType = modifierClassSymbol.BaseType;
                while (currentBaseType != null && !SymbolEqualityComparer.Default.Equals(currentBaseType, targetBaseType))
                {
                    currentBaseType = currentBaseType.BaseType;
                }

                if (currentBaseType is null)
                {
                    return null;
                }

                return new ModifierTypeInfo(modifierClassSymbol.ContainingNamespace.ToDisplayString(), modifierClassSymbol.Name);
            })
            .Where(value => value is not null);

        IncrementalValuesProvider<GeoJsonDerivedTypeInfo> derivedTypesProvider = context.SyntaxProvider
            .CreateSyntaxProvider(
            predicate: static (node, _) => node is ClassDeclarationSyntax { BaseList.Types.Count: > 0 }, 
            transform: static (context, token) =>
            {
                
            });
    }
}
