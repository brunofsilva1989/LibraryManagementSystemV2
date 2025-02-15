using LibraryManagementSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _request;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _request = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new
            {
                Messaage = "An unexpected error occurred! Please try again later.",
                message = exception.Message,
                statusCode = response.StatusCode
            };

            response.StatusCode = exception switch
            {
                // Erro de parâmetro inválido
                ArgumentException => StatusCodes.Status400BadRequest,

                // Erro de validação de argumentos (como um campo obrigatório não preenchido)
                //ArgumentNullException => StatusCodes.Status400BadRequest,

                // Erro de dado não encontrado (quando um recurso não existe no banco de dados)
                KeyNotFoundException => StatusCodes.Status404NotFound,
                NotFoundException => StatusCodes.Status404NotFound,

                // Erro de permissão (quando um usuário tenta acessar algo sem permissão)
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                // Erro de autenticação (quando o token JWT está inválido ou expirado)
                SecurityTokenException => StatusCodes.Status401Unauthorized,

                // Erro de acesso negado (quando o usuário não tem autorização para executar uma ação)
                AccessViolationException => StatusCodes.Status403Forbidden,

                // Erro de violação de banco de dados (quando ocorre erro ao tentar inserir um registro duplicado)
                DbUpdateException => StatusCodes.Status409Conflict,

                // Erro de conflito (como uma tentativa de atualização concorrente)
                InvalidOperationException => StatusCodes.Status409Conflict,

                // Erro de tempo limite (quando uma requisição demora muito)
                TaskCanceledException => StatusCodes.Status408RequestTimeout,

                // Erros de serialização/desserialização (quando o JSON enviado está incorreto)
                JsonException => StatusCodes.Status400BadRequest,

                // Qualquer outra exceção não tratada cairá aqui como erro interno do servidor
                _ => StatusCodes.Status500InternalServerError
            };

            return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
