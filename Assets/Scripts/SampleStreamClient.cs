//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using UnityEngine;

//using Cysharp.Net.Http;
//using Cysharp.Threading.Tasks;
//using Grpc.Core;
//using Grpc.Net.Client;
//using System.Net.Http;
//using Unity.VisualScripting;

//public class SampleStreamClient : MonoBehaviour
//{
//    static readonly string Address = "https://localhost:8080";

//    public delegate void ResponseRecieveHandler(SampleResponse response);
//    public event ResponseRecieveHandler OnResponseReceived;
//    public event Action<Exception> OnError;

//    CancellationTokenSource cancellationTokenSource = null;

//    public void StartStream()
//    {
//        if(cancellationTokenSource != null)
//        {
//            Debug.LogWarning("Stream is already running.");
//            return;
//        }
//        cancellationTokenSource = new CancellationTokenSource();
//        ReceiveStreamAsync(cancellationTokenSource.Token).Forget();
//    }

//    public void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    static UniTaskReceiveStreamAsync(CancellationToken cancellationToken)
//    {
//        try
//        {
//            using var httpHandler = new YetAnotherHttpHandler() { SkipCertificateVerification = true };
//            using var httpClient = new HttpClient(httpHandler);

//            using GrpcChannel channel = GrpcChannel.ForAddress(Address, new GrpcChannelOptions() { HttpHandler = httpHandler });
//            var gRPCClient = new SampleService.SampleServiceClient(channel);

//            var sampleRequest = new SampleRequest();
//            AsyncServerStreamingCall<SampleResponse> request = gRPCClient.Sample(sampleRequest);

//            while (await request.ResponseStream.MoveNext(cancellationToken))
//            {
//                var response = request.ResponseStream.Current;

//                await UniTask.SwitchToMainThread();
//                OnResponseReceived?.Invoke(response);
//            }

//        }
//        catch(RpcException rpcEx)
//        {
//            Debug.LogError($"gRPC error: {rpcEx.Status.Detail}");
//            OnError?.Invoke(rpcEx);
//        }
//        catch (Exception ex)
//        {
//            Debug.LogError($"Stream error: {ex.Message}");
//            OnError?.Invoke(ex);
//        }
//        finally
//        {
//            cancellationTokenSource.Dispose();
//            cancellationTokenSource = null;
//        }
//    }
//    public void StopStream()
//    {
//        if(cancellationTokenSource != null)
//        {
//            cancellationTokenSource.Cancel();
//        }
//    }
//}
