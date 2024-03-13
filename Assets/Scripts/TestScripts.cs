using Cysharp.Net.Http;
using Grpc.Net.Client;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Unity.VisualScripting;
using UnityEngine;

public class TestScriptsGrpc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        startAsync();
    }


    async void startAsync()
    {
        using var handler = new YetAnotherHttpHandler();
        using var channel = GrpcChannel.ForAddress("https://api.example.com", 
            new GrpcChannelOptions() 
            { 
                HttpHandler = handler
            }
        );

        //var greeter = new GreeterClient(channel);

        //var result = await greeter

        var httpClient = new HttpClient(handler);


        var result = await httpClient.GetStringAsync("https://www.example.com");
        Debug.Log(result);
    }

}
