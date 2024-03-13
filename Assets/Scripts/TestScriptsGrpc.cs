using Cysharp.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        startAsync();
    }


    async void startAsync()
    {
        using var handler = new YetAnotherHttpHandler();


        var httpClient = new HttpClient(handler);


        var result = await httpClient.GetStringAsync("https://www.example.com");
        Debug.Log(result);
    }
    async void startAsync2Grpc()
    {
        using var handler = new YetAnotherHttpHandler();


        var httpClient = new HttpClient(handler);


        var result = await httpClient.GetStringAsync("https://www.example.com");
        Debug.Log(result);
    }

}
