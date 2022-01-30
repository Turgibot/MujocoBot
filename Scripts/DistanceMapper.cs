using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DistanceMapper : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    public Shader uberReplacementShader;
    void Start()
    {
        _camera = GetComponent<Camera>();
        //_camera = CreateHiddenCamera("Distance");
        _camera.farClipPlane = 1.25f;
        _camera.depthTextureMode = DepthTextureMode.Depth;
        if (!uberReplacementShader)
            uberReplacementShader = Shader.Find("Hidden/UberReplacement");
        SetupCameraWithReplacementShader(_camera, uberReplacementShader, 5, Color.black);

    }

    private Camera CreateHiddenCamera(string name)
    {
        var go = new GameObject (name, typeof (Camera));
        go.hideFlags = HideFlags.HideAndDontSave;
        go.transform.parent = transform;

        var newCamera = go.GetComponent<Camera>();
        return newCamera;
    }
    private static void SetupCameraWithReplacementShader(Camera cam, Shader shader, int mode, Color clearColor)
    {
        var cb = new CommandBuffer();
        cb.SetGlobalFloat("_OutputMode", mode); // @TODO: CommandBuffer is missing SetGlobalInt() method
        cam.AddCommandBuffer(CameraEvent.BeforeForwardOpaque, cb);
        cam.AddCommandBuffer(CameraEvent.BeforeFinalPass, cb);
        cam.SetReplacementShader(shader, "");
        cam.backgroundColor = clearColor;
        cam.clearFlags = CameraClearFlags.SolidColor;
    }
}
