// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ZedStreamer.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Zedstreamer {
  public static partial class ZedStreamer
  {
    static readonly string __ServiceName = "zedstreamer.ZedStreamer";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Zedstreamer.Image> __Marshaller_zedstreamer_Image = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Zedstreamer.Image.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Zedstreamer.Received> __Marshaller_zedstreamer_Received = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Zedstreamer.Received.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Zedstreamer.Depth> __Marshaller_zedstreamer_Depth = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Zedstreamer.Depth.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Zedstreamer.Params> __Marshaller_zedstreamer_Params = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Zedstreamer.Params.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Zedstreamer.Image, global::Zedstreamer.Received> __Method_SendImage = new grpc::Method<global::Zedstreamer.Image, global::Zedstreamer.Received>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendImage",
        __Marshaller_zedstreamer_Image,
        __Marshaller_zedstreamer_Received);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Zedstreamer.Image, global::Zedstreamer.Received> __Method_SendVideo = new grpc::Method<global::Zedstreamer.Image, global::Zedstreamer.Received>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "SendVideo",
        __Marshaller_zedstreamer_Image,
        __Marshaller_zedstreamer_Received);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Zedstreamer.Depth, global::Zedstreamer.Received> __Method_SendDepth = new grpc::Method<global::Zedstreamer.Depth, global::Zedstreamer.Received>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "SendDepth",
        __Marshaller_zedstreamer_Depth,
        __Marshaller_zedstreamer_Received);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Zedstreamer.Params, global::Zedstreamer.Received> __Method_SendParams = new grpc::Method<global::Zedstreamer.Params, global::Zedstreamer.Received>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendParams",
        __Marshaller_zedstreamer_Params,
        __Marshaller_zedstreamer_Received);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Zedstreamer.ZedStreamerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ZedStreamer</summary>
    [grpc::BindServiceMethod(typeof(ZedStreamer), "BindService")]
    public abstract partial class ZedStreamerBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Zedstreamer.Received> SendImage(global::Zedstreamer.Image request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Zedstreamer.Received> SendVideo(grpc::IAsyncStreamReader<global::Zedstreamer.Image> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Zedstreamer.Received> SendDepth(grpc::IAsyncStreamReader<global::Zedstreamer.Depth> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Zedstreamer.Received> SendParams(global::Zedstreamer.Params request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ZedStreamer</summary>
    public partial class ZedStreamerClient : grpc::ClientBase<ZedStreamerClient>
    {
      /// <summary>Creates a new client for ZedStreamer</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ZedStreamerClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ZedStreamer that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ZedStreamerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ZedStreamerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ZedStreamerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Zedstreamer.Received SendImage(global::Zedstreamer.Image request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendImage(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Zedstreamer.Received SendImage(global::Zedstreamer.Image request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendImage, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Zedstreamer.Received> SendImageAsync(global::Zedstreamer.Image request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendImageAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Zedstreamer.Received> SendImageAsync(global::Zedstreamer.Image request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendImage, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::Zedstreamer.Image, global::Zedstreamer.Received> SendVideo(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendVideo(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::Zedstreamer.Image, global::Zedstreamer.Received> SendVideo(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_SendVideo, null, options);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::Zedstreamer.Depth, global::Zedstreamer.Received> SendDepth(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendDepth(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::Zedstreamer.Depth, global::Zedstreamer.Received> SendDepth(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_SendDepth, null, options);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Zedstreamer.Received SendParams(global::Zedstreamer.Params request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendParams(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Zedstreamer.Received SendParams(global::Zedstreamer.Params request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendParams, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Zedstreamer.Received> SendParamsAsync(global::Zedstreamer.Params request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendParamsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Zedstreamer.Received> SendParamsAsync(global::Zedstreamer.Params request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendParams, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ZedStreamerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ZedStreamerClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ZedStreamerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendImage, serviceImpl.SendImage)
          .AddMethod(__Method_SendVideo, serviceImpl.SendVideo)
          .AddMethod(__Method_SendDepth, serviceImpl.SendDepth)
          .AddMethod(__Method_SendParams, serviceImpl.SendParams).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ZedStreamerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendImage, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Zedstreamer.Image, global::Zedstreamer.Received>(serviceImpl.SendImage));
      serviceBinder.AddMethod(__Method_SendVideo, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::Zedstreamer.Image, global::Zedstreamer.Received>(serviceImpl.SendVideo));
      serviceBinder.AddMethod(__Method_SendDepth, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::Zedstreamer.Depth, global::Zedstreamer.Received>(serviceImpl.SendDepth));
      serviceBinder.AddMethod(__Method_SendParams, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Zedstreamer.Params, global::Zedstreamer.Received>(serviceImpl.SendParams));
    }

  }
}
#endregion