using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt.Gateway.MiddleWares
{
    //参考： https://www.cnblogs.com/ShenNan/p/10197231.html

    public enum ApiCustomExceptionHandleType
    {
        JsonHandle = 0,
        PageHandle = 1,
        Both = 2
    }
    public class ApiCustomExceptionMiddleWareOption
    {
        public ApiCustomExceptionMiddleWareOption(
            ApiCustomExceptionHandleType handleType = ApiCustomExceptionHandleType.JsonHandle,
            IList<PathString> jsonHandleUrlKeys = null,
            string errorHandingPath = "")
        {
            HandleType = handleType;
            JsonHandleUrlKeys = jsonHandleUrlKeys;
            ErrorHandingPath = errorHandingPath;
        }
        public ApiCustomExceptionHandleType HandleType { get; set; }
        public IList<PathString> JsonHandleUrlKeys { get; set; }
        public PathString ErrorHandingPath { get; set; }
    }
    public class ApiCustomExceptionMiddleWare
    {
        private RequestDelegate _next;
        private ApiCustomExceptionMiddleWareOption _option;
        private IDictionary<int, string> _exceptionStatusCodeDic;

        public ApiCustomExceptionMiddleWare(RequestDelegate next, ApiCustomExceptionMiddleWareOption option)
        {
            _next = next;
            _option = option;
            _exceptionStatusCodeDic = new Dictionary<int, string>
            {
                { 401, "未授权的请求" },
                { 404, "找不到该页面" },
                { 403, "访问被拒绝" },
                { 500, "服务器发生意外的错误" }
                //其余状态自行扩展
            };
        }

        public async Task Invoke(HttpContext context)
        {
            Exception exception = null;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 200;//手动设置状态码(总是成功)
                exception = ex;
            }
            finally
            {
                if (_exceptionStatusCodeDic.ContainsKey(context.Response.StatusCode) &&
                    !context.Items.ContainsKey("ExceptionHandled"))
                {
                    var errorMsg = string.Empty;
                    if (context.Response.StatusCode == 500 && exception != null)
                    {
                        errorMsg = $"{_exceptionStatusCodeDic[context.Response.StatusCode]}\r\n{(exception.InnerException != null ? exception.InnerException.Message : exception.Message)}";
                    }
                    else
                    {
                        errorMsg = _exceptionStatusCodeDic[context.Response.StatusCode];
                    }
                    exception = new Exception(errorMsg);
                }
                if (exception != null)
                {
                    var handleType = _option.HandleType;
                    if (handleType == ApiCustomExceptionHandleType.Both)
                    {
                        var requestPath = context.Request.Path;
                        handleType = _option.JsonHandleUrlKeys != null && _option.JsonHandleUrlKeys.Count(
                            k => requestPath.StartsWithSegments(k, StringComparison.CurrentCultureIgnoreCase)) > 0 ?
                            ApiCustomExceptionHandleType.JsonHandle :
                            ApiCustomExceptionHandleType.PageHandle;
                    }

                    if (handleType == ApiCustomExceptionHandleType.JsonHandle)
                        await JsonHandle(context, exception);
                    else
                        await PageHandle(context, exception, _option.ErrorHandingPath);
                }
            }
        }
        private Jwt.Gateway.Models.ApiResponse GetApiResponse(Exception ex)
        {
            return new Jwt.Gateway.Models.ApiResponse() { status = 0, message = ex.Message };
        }
        private async Task JsonHandle(HttpContext context, Exception ex)
        {
            var apiResponse = GetApiResponse(ex);
            var serialzeStr = Newtonsoft.Json.JsonConvert.SerializeObject(apiResponse);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(serialzeStr, System.Text.Encoding.UTF8);
        }
        private async Task PageHandle(HttpContext context, Exception ex, PathString path)
        {
            context.Items.Add("Exception", ex);
            var originPath = context.Request.Path;
            context.Request.Path = path;
            try
            {
                await _next(context);
            }
            catch { }
            finally
            {
                context.Request.Path = originPath;
            }
        }
    }
    public static class ApiCustomExceptionMiddleWareExtensions
    {
        public static IApplicationBuilder UseApiCustomException(this IApplicationBuilder app, ApiCustomExceptionMiddleWareOption option)
        {
            return app.UseMiddleware<ApiCustomExceptionMiddleWare>(option);
        }
    }
}