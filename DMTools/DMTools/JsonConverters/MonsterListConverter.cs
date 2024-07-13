using DMTools.Database.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DMTools.JsonConverters;

public class MonsterListConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(List<Monster>);
    }

    public override JsonConverter CreateConverter(
        Type type,
        JsonSerializerOptions options)
    {
        Type[] typeArguments = type.GetGenericArguments();
        Type keyType = typeArguments[0];
        Type valueType = typeArguments[1];

        JsonConverter converter = (JsonConverter)Activator.CreateInstance(
            typeof(MonsterListConverterInner),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: [options],
            culture: null)!;

        return converter;
    }

    private class MonsterListConverterInner : JsonConverter<List<Monster>>
    {
        private readonly JsonConverter<Monster> _valueConverter;

        public MonsterListConverterInner(JsonSerializerOptions options)
        {
            // For performance, use the existing converter.
            _valueConverter = (JsonConverter<Monster>)options
                .GetConverter(typeof(Monster));
        }

        public override List<Monster>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            List<Monster>? monsters = new();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return monsters;
                }

                // Get the key.
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }


            }

            throw new JsonException();

            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, List<Monster> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
