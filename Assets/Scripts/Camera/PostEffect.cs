using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Example of post-effect code by Will Weissman
   https://willweissman.wordpress.com/tutorials/shaders/unity-shaderlab-object-outlines/ */

public class PostEffect : MonoBehaviour
{
    /*private Camera camera;
    private Camera tempCamera;
    private Material postMaterial;

    public Shader postOutline;
    public Shader drawSimple;

	
	void Start ()
    {
        camera = GetComponent<Camera>();
        tempCamera = new GameObject().AddComponent<Camera>();
        tempCamera.enabled = false;
        postMaterial = new Material(postOutline);
	}

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Set up the temporary camera
        tempCamera.CopyFrom(camera);
        tempCamera.clearFlags = CameraClearFlags.Color;
        tempCamera.backgroundColor = Color.black;

        // Cull any layer that isn't the outline
        tempCamera.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        // Make the temporary RenderTexture
        RenderTexture tempRT = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.R8);

        // Put it to video memory
        tempRT.Create();

        // Set the camera's target texture when rendering
        tempCamera.targetTexture = tempRT;

        // Render all objects this camera can render, but with our custom shader
        tempCamera.RenderWithShader(drawSimple, "");

        // Copy the temporary RT to the final image
        Graphics.Blit(tempRT, destination, postMaterial);

        // Release the temporary RT
        tempRT.Release();
    }*/
}
