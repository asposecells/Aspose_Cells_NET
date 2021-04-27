﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using Aspose.Cells.API.Internal;
using Aspose.Cells.API.Internal.RequestHandlers;
using Aspose.Cells.API.Models;
using Aspose.Cells.API.Models.Requests;
using Aspose.Cells.API.Requests;
using Newtonsoft.Json;
using FileInfo = Aspose.Cells.API.Models.FileInfo;
using TextInfo = System.Globalization.TextInfo;

namespace Aspose.Cells.API.Api
{
    public class TranslationApi
    {
        private readonly ApiInvoker _apiInvoker;
        private readonly Configuration _configuration;

        public TranslationApi(string apiKey, string appSid) : this(new Configuration {ClientSecret = apiKey, ClientId = appSid})
        {
        }

        public TranslationApi(string jwtToken) : this(new Configuration {JwtToken = jwtToken, ApiVersion = ApiVersion.V1, AuthType = AuthType.JWT})
        {
        }

        public TranslationApi(Configuration configuration)
        {
            _configuration = configuration;
            var requestHandlers = new List<IRequestHandler>();

            if (_configuration.AuthType == AuthType.JWT) requestHandlers.Add(new JwtRequestHandler(_configuration));

            requestHandlers.Add(new DebugLogRequestHandler(_configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            _apiInvoker = new ApiInvoker(requestHandlers);
        }

        public TranslateDocumentRequest CreateDocumentRequest(
            string name,
            string folder,
            string pair,
            string format,
            string outformat,
            string storage,
            string savefile,
            string savepath,
            bool masters,
            List<int> elements
        )
        {
            var fileInfo = new FileInfo
            {
                Folder = folder,
                Format = format,
                OutFormat = outformat,
                Name = name,
                Pair = pair,
                SaveFile = savefile,
                SavePath = savepath,
                Storage = storage,
                Masters = masters,
                Elements = elements
            };
            var userRequest = $"'[{JsonConvert.SerializeObject(fileInfo)}]'";
            var request = new TranslateDocumentRequest(userRequest);
            return request;
        }

        public TranslateTextRequest CreateTextRequest(string pair, string text)
        {
            var textInfo = new Models.TextInfo {Pair = pair, Text = text};
            var userRequest = $"'[{JsonConvert.SerializeObject(textInfo, Formatting.None, new JsonSerializerSettings {StringEscapeHandling = StringEscapeHandling.EscapeHtml})}]'";
            var request = new TranslateTextRequest(userRequest);
            return request;
        }

        public TranslationResponse RunTranslationTask(TranslateDocumentRequest request)
        {
            if (request.UserRequest == null)
            {
                throw new ApiException(400, "Empty request");
            }

            var resourcePath = _configuration.GetApiRootUrl() + "/document";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");

            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "POST",
                    request.UserRequest);
                if (response != null)
                {
                    return (TranslationResponse) SerializationHelper.Deserialize(response, typeof(TranslationResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        public TextResponse RunTranslationTextTask(TranslateTextRequest request)
        {
            if (request.UserRequest == null)
            {
                throw new ApiException(400, "Empty request");
            }

            var resourcePath = _configuration.GetApiRootUrl() + "/text";


            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");

            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "POST",
                    request.UserRequest);
                if (response != null)
                {
                    return (TextResponse) SerializationHelper.Deserialize(response, typeof(TextResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        public TranslationResponse RunHealthCheck()
        {
            var resourcePath = _configuration.GetApiRootUrl() + "/hc";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");


            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "GET");
                if (response != null)
                {
                    return (TranslationResponse) SerializationHelper.Deserialize(response, typeof(TranslationResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        public FileInfo GetDocumentRequestStructure()
        {
            var resourcePath = _configuration.GetApiRootUrl() + "/info/document";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");


            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "GET");
                if (response != null)
                {
                    return (FileInfo) SerializationHelper.Deserialize(response, typeof(FileInfo));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        public TextInfo GetTextRequestStructure()
        {
            var resourcePath = _configuration.GetApiRootUrl() + "/info/text";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");

            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "GET");
                if (response != null)
                {
                    return (TextInfo) SerializationHelper.Deserialize(response, typeof(TextInfo));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        public Dictionary<string, string[]> GetLanguagePairs()
        {
            var resourcePath = _configuration.GetApiRootUrl() + "/info/pairs";
            resourcePath = Regex
                .Replace(resourcePath, "\\*", string.Empty)
                .Replace("&amp;", "&")
                .Replace("/?", "?");

            try
            {
                var response = _apiInvoker.InvokeApi(
                    resourcePath,
                    "GET");
                if (response != null)
                {
                    return (Dictionary<string, string[]>) SerializationHelper.Deserialize(response, typeof(Dictionary<string, string[]>));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }
    }
}