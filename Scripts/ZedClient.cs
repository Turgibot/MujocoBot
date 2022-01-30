using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zedstreamer;
using Grpc.Core;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

public class ZedClient
{
    private readonly ZedStreamer.ZedStreamerClient _client;
    private readonly Channel _channel;
    private readonly string _server = "127.0.0.1:50051";

    internal ZedClient()
    {
        _channel = new Channel(_server, ChannelCredentials.Insecure);
        _client = new ZedStreamer.ZedStreamerClient(_channel);
    }

    internal async void SendImage(Image img)
    {
        try
        {
            //non blocking single image sending
            Task<Received> task = new Task<Received>(() => _client.SendImage(img));
            task.Start();
            var received = await task;
        }
        catch (RpcException e)
        {
            Debug.Log("RPC failed : " + e);
            throw;
        }
    }
    
    internal async void SendParams(Params myParams)
    {
        try
        {
            //non blocking single image sending
            Task<Received> task = new Task<Received>(() => _client.SendParams(myParams));
            task.Start();
            var received = await task;
        }
        catch (RpcException e)
        {
            Debug.Log("RPC failed : " + e);
            throw;
        }
    }

    internal async Task<Received> SendVideo()
    {
        try
        {
            using (var call = _client.SendVideo())
            {
                foreach (var image in StreamManager.GetImages())
                {
                    if (!StreamManager.isStreaming)
                        break;
                    if (image != null)
                        await call.RequestStream.WriteAsync(image);
                }

                await call.RequestStream.CompleteAsync();
                return await call.ResponseAsync;
            }
        }
        catch (RpcException e)
        {
            Debug.Log("RPC failed : " + e);
            throw;
        }
    }
    
    
    internal async Task<Received> SendDepth()
    {
        try
        {
            using (var call = _client.SendDepth())
            {
                foreach (var depth in StreamManager.GetDepthImages())
                {
                    if (!StreamManager.isStreaming)
                        break;
                    if (depth != null)
                        await call.RequestStream.WriteAsync(depth);
                }

                await call.RequestStream.CompleteAsync();
                return await call.ResponseAsync;
            }
        }
        catch (RpcException e)
        {
            Debug.Log("RPC failed : " + e);
            throw;
        }
    }


    private void OnDisable()
    {
        _channel.ShutdownAsync().Wait();
    }
}