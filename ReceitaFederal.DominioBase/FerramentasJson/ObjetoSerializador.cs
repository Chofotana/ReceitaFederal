using ReceitaFederal.DominioBase.Extensoes;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReceitaFederal.DominioBase.FerramentasJson
{
    public static class ObjetoSerializador<T>
    {
        private readonly static JsonSerializerOptions _jsonSerializarOptions = new()
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public static string Serializar(T objeto) =>
            JsonSerializer.Serialize(objeto, _jsonSerializarOptions);

        public static T Desserializar(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException jsonException)
            {
                throw new Exception(jsonException.ObterMensagensExceptionConcatenadas());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
