using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ReceitaFederal.DominioBase.Extensoes
{
    public static class ExtensaoException
    {

        public static IEnumerable<string> ObterMensagensException(this Exception exception)
        {
            do
            {
                yield return exception.Message;
                exception = exception.InnerException;
            }
            while (exception is not null);
        }


        public static string ObterMensagensExceptionConcatenadas(this Exception exception, string separador = " | ") =>
            string.Join(separador, exception.ObterMensagensException());


        public static string ObterMensagensExceptionConcatenadas(this JsonException exception, string separador = " | ")
        {
            List<string> mensagens = [$"Linha [{exception.LineNumber}]", $"Caminho [{exception.Path}]"];
            mensagens.AddRange(exception.ObterMensagensException());
            return string.Join(separador, exception.ObterMensagensException());
        }
    }
}
