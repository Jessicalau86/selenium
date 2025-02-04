using OpenQA.Selenium.BiDi.Modules.Script;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace OpenQA.Selenium.BiDi.Communication.Json.Converters;

internal class HandleConverter : JsonConverter<Handle>
{
    private readonly BiDi _bidi;

    public HandleConverter(BiDi bidi)
    {
        _bidi = bidi;
    }

    public override Handle? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var id = reader.GetString();

        return new Handle(_bidi, id!);
    }

    public override void Write(Utf8JsonWriter writer, Handle value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Id);
    }
}
