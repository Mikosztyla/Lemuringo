using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class TranslatorTests : MonoBehaviour
{
    private readonly TranslatorApi _translatorApi;
    private async void Start()
    {
        await Test();
    }

    private async Task Test()
    {
        var results = await TranslatorApi.GetAvailableLanguages();
        foreach (var result  in results)
        {
            Debug.Log(result);
        }
    }
}
