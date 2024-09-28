using System;
using UnityEngine;

[Serializable]
public class TranslationResponse
{
    public Translation[] translations;
}

[Serializable]
public class Translation
{
    public string text;
}

[Serializable]
public class LanguageResponse
{
    public Language[] languages;
}

[Serializable]
public class Language
{
    public string language;
    public string name;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string newJson = "{\"Items\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.Items;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}