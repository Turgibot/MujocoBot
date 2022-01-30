using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Grpc.Core;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Zedstreamer;
using Image = Zedstreamer.Image;


public class StreamManager : MonoBehaviour
{
    private ZedClient _zedClient;
    public static RenderTexture leftRT;
    public static RenderTexture rightRT; 
    public static RenderTexture leftDepthRT;
    public static RenderTexture rightDepthRT;
    public TextMeshProUGUI txt;
    public RenderTexture leftRTP;
    public RenderTexture rightRTP;
    public RenderTexture leftDepthRTP;
    public RenderTexture rightDepthRTP;
    public static List<Image> images = new List<Image>();
    public static bool isStreaming = false;
    public static DoubleBuffer doubleBuffer = new DoubleBuffer();
    public static DoubleDepthBuffer doubleDepthBuffer = new DoubleDepthBuffer();
    private bool isInitial = true;
    private int[] myParams;
    public Slider posSlider;
    public Slider negSlider;
    private void Start()
    {
        myParams = new int[] {50, 50, 0};
        leftRT = leftRTP;
        rightRT = rightRTP;
        leftDepthRT = leftDepthRTP;
        rightDepthRT = rightDepthRTP;
        
        _zedClient = new ZedClient();
        
        StartCoroutine(AddImageToBuffer());
        StartCoroutine(AddDepthToBuffer());
        
    }

    private void Update()
    {
        if (isStreaming)
        {
            StartCoroutine(AddImageToBuffer());
            StartCoroutine(AddDepthToBuffer());
        }
    }


    public async void SendStreamToServer()
    {
        
       
        SendParamsToServer();

        if (isStreaming)
        {
            Debug.Log("Streaming");
            Received received = await _zedClient.SendVideo();
           
        }
        else
        {
            Debug.Log("Streaming Stopped");
        }
        
    }
    
    
    public async void SendDepthStreamToServer()
    {
        if (isStreaming)
        {
            Received received = await _zedClient.SendDepth();
        }
    }
    
    public async void SendParamsToServer()
    {
       
        if (isStreaming)
        {
            myParams[2] = 1;
        }
        else
        {
            myParams[2] = 0;
        }
        Params myParamsObj = new Params();
        foreach (var item in myParams)
        {
            myParamsObj.Data.Add(item);
        }
        Debug.Log("Sending Params");
        await Task.Run((() => _zedClient.SendParams(myParamsObj)));
    }

    public void ChangePosTH()
    {
        myParams[0] = (int)(posSlider.value);
        SendParamsToServer();
        Debug.Log(myParams[0]);
    }
    
    public void ChangeNegTH()
    {
        myParams[1] = (int)(negSlider.value);
        SendParamsToServer();
        Debug.Log(myParams[1]);

    }

    public static IEnumerable<Image> GetImages()
    {
        while (isStreaming)
        {
            yield return doubleBuffer.Load();
        }
    }
    
    public static IEnumerable<Depth> GetDepthImages()
    {
        while (isStreaming)
        {
            var depth = doubleDepthBuffer.Load();
            if(depth!=null)
                yield return doubleDepthBuffer.Load();
            else
                break;
        }
    }

    private IEnumerator AddImageToBuffer()
    {
        yield return new WaitForEndOfFrame();
        int width = leftRT.width;
        int height = leftRT.height;
        int depth = 3;
        int size = width * height * depth;
        byte[] bytesArr = new byte[size * 2];

        //read left to bytes array
        RenderTexture.active = leftRT;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        var tex_bytes = tex.GetRawTextureData();
        tex_bytes.CopyTo(bytesArr, 0);
        Destroy(tex);
        //read right to bytes array
        RenderTexture.active = rightRT;
        tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        tex_bytes = tex.GetRawTextureData();
        tex_bytes.CopyTo(bytesArr, tex_bytes.Length);
        Destroy(tex);

        if (bytesArr.Max() != 0)
        {
            ByteString bytestring;
            using (var str = new MemoryStream(bytesArr))
            {
                bytestring = ByteString.FromStream(str);
            }

            Image img = new Image
            {
                Width = width, Height = height, ImageData = bytestring
            };
            doubleBuffer.Save(img);
            if (isInitial)
            {
                doubleBuffer.Save(img);
                isInitial = false;
            }
        }
        else
        {
            Debug.Log("Found zeros");
        }
           
        yield return null;
    }

    private IEnumerator AddDepthToBuffer()
    {
        yield return new WaitForEndOfFrame();
        int width = leftDepthRT.width;
        int height = leftDepthRT.height;
        int depth = 3;
        int size = width * height * depth;
        byte[] bytesArr = new byte[size * 2];

        //read left to bytes array
        RenderTexture.active = leftDepthRT;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        var tex_bytes = tex.GetRawTextureData();
        tex_bytes.CopyTo(bytesArr, 0);
        Destroy(tex);
        //read right to bytes array
        RenderTexture.active = rightDepthRT;
        tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        tex_bytes = tex.GetRawTextureData();
        tex_bytes.CopyTo(bytesArr, tex_bytes.Length);
        Destroy(tex);

        if (bytesArr.Max() != 0)
        {
            ByteString bytestring;
            using (var str = new MemoryStream(bytesArr))
            {
                bytestring = ByteString.FromStream(str);
            }

            Depth _depth = new Depth()
            {
                Width = width, Height = height, ImageData = bytestring
            };
            doubleDepthBuffer.Save(_depth);
            if (isInitial)
            {
                doubleDepthBuffer.Save(_depth);
                isInitial = false;
            }
        }
        else
        {
            Debug.Log("Found zeros");
        }
           
        yield return null;
    }
    public void ToggleText()
    {
        string send = "Send Stream";
        string stop = "Stop Stream";
        isStreaming = !isStreaming;
        if (txt.text.Equals(send))
        {
            txt.text = stop;
            myParams[2] = 1;
           
        }
        else
        {
            txt.text = send;
            myParams[2] = 0;
           
        }
        //SendParamsToServer();
    }

    
}

public class DoubleBuffer
{
    int bufferIndex = 0;

    // An array of byte[]
    Image[]buffers = new Image[2];

    public int Save(Image inputBuffer)
    {
        if(bufferIndex == 0)
        {
            buffers[1] = inputBuffer;
            bufferIndex = 1;
        }
        else
        {
            buffers[0] = inputBuffer;
            bufferIndex = 0;
        }

        return bufferIndex;
    }
		
    public Image Load()
    {
        return buffers[bufferIndex];
    }
}

public class DoubleDepthBuffer
{
    int bufferIndex = 0;

    // An array of byte[]
    Depth[]buffers = new Depth[2];

    public int Save(Depth inputBuffer)
    {
        if(bufferIndex == 0)
        {
            buffers[1] = inputBuffer;
            bufferIndex = 1;
        }
        else
        {
            buffers[0] = inputBuffer;
            bufferIndex = 0;
        }

        return bufferIndex;
    }
		
    public Depth Load()
    {
        return buffers[bufferIndex];
    }
}