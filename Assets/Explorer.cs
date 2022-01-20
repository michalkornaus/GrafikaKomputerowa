using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale;
    public float maxIter;

    private Vector2 smoothPos;
    private float smoothScale;

    private void UpdateShader()
    {
        smoothPos = Vector2.Lerp(smoothPos, pos, .03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, .03f);
        
        float aspect = (float)Screen.width / Screen.height;

        float scaleX = smoothScale;
        float scaleY = smoothScale;
        if (aspect > 1f)
            scaleY /= aspect;
        else
            scaleX *= aspect;
        mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scaleX, scaleY));
    }
    private void HandleInputs()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            scale *= 0.995f;
        if (Input.GetKey(KeyCode.Space))
            scale *= 1.005f;
        if (Input.GetKey(KeyCode.A))
            pos.x -= 0.01f * scale;
        if (Input.GetKey(KeyCode.D))
            pos.x += 0.01f * scale;
        if (Input.GetKey(KeyCode.W))
            pos.y += 0.01f * scale;
        if (Input.GetKey(KeyCode.S))
            pos.y -= 0.01f * scale;
    }
    void FixedUpdate()
    {
		HandleInputs();  
        UpdateShader();
    }
}
