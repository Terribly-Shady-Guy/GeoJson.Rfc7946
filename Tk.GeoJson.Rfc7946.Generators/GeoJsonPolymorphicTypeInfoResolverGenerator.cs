using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace Tk.GeoJson.Rfc7946.Generators;

[Generator]
internal sealed class GeoJsonPolymorphicTypeInfoResolverGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        const string GeoJsonPolymorphicBaseAttributeName = "Tk.GeoJson.Rfc7946.GeoJsonPolymorphicBaseTypeAttribute";

        IncrementalValuesProvider<GeoJsonDerivedTypeInfo> attributeInfo = context.SyntaxProvider
            .ForAttributeWithMetadataName(GeoJsonPolymorphicBaseAttributeName, (_, _) => true, TransformInitialContext);

        IncrementalValueProvider<ImmutableArray<GeoJsonDerivedTypeInfo>> typeInfo = attributeInfo.Collect();
    }

    private static GeoJsonDerivedTypeInfo TransformInitialContext(GeneratorAttributeSyntaxContext ctx, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
