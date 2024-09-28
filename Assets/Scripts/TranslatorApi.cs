using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class TranslatorApi
{
    private static readonly string _apiKey = "bd7732c2-83c8-44d2-a619-eed7697c18a2:fx";
    private readonly string _apiTranslateUrl = "https://api-free.deepl.com/v2/translate";
    private static readonly string _apiLanguagesUrl = "https://api-free.deepl.com/v2/languages";
    private readonly string _sourceLanguage;
    private readonly string _targetLanguage;

    public TranslatorApi(string sourceLanguage, string targetLanguage)
    {
        _sourceLanguage = sourceLanguage;
        _targetLanguage = targetLanguage;
    }

    public async Task<Dictionary<string, string>> Translate(IEnumerable<string> words)
    {
        using var client = new HttpClient();
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("text", string.Join(",", words)),
            new KeyValuePair<string, string>("target_lang", _targetLanguage),
            new KeyValuePair<string, string>("source_lang", _sourceLanguage),
        });
        
        var request = new HttpRequestMessage(HttpMethod.Post, _apiTranslateUrl)
        {
            Content = requestContent
        };

        request.Headers.Add("Authorization", $"DeepL-Auth-Key {_apiKey}");
        HttpResponseMessage response = await client.SendAsync(request);
        var jsonResponseString = await response.Content.ReadAsStringAsync();
        
        var translationResponse = JsonUtility.FromJson<TranslationResponse>(jsonResponseString);
        var translations = translationResponse.translations
            .SelectMany(t => t.text.Split(","))
            .ToList();

        return words.Zip(translations, (word, translation) => new { word, translation })
            .ToDictionary(x => x.word, x => x.translation);
    }

    public static async Task<Dictionary<string, string>> GetAvailableLanguages()
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, _apiLanguagesUrl);
        request.Headers.Add("Authorization", $"DeepL-Auth-Key {_apiKey}");
        HttpResponseMessage response = await client.SendAsync(request);
        var jsonResponseString = await response.Content.ReadAsStringAsync();

        var languages = JsonHelper.FromJson<Language>(jsonResponseString);
        return languages.ToDictionary(l => l.language, l => l.name);
    }
}