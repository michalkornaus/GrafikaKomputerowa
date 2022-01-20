using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Numerics;

public class MandelbrotScript : MonoBehaviour
{
    public Canvas canvas;
    private Texture2D texture2D;
    private Color[] colors;
    public Vector2 pos;
    public double scale = 2.0;
    private Vector2 smoothPos;
    private float smoothScale;

    public double centerX = 0, centerY = 0;

    public double minX, minY;
    private int canvasWidth;
    private int canvasHeight;
    [Range(0, 5000)]
    public int MaxIter;
    void Start()
    {
        canvasWidth = (int)canvas.pixelRect.width;
        canvasHeight = (int)canvas.pixelRect.height;
        texture2D = new Texture2D(canvasWidth, canvasHeight, TextureFormat.RGBA32, false, true);
        colors = new Color[canvasWidth * canvasHeight];
        texture2D.name = "Tekstura";
        //minX = (centerX - zoom) / 2;
        //minY = (centerY - zoom) / 2;
        GenerateTexture();
    }
    private void GenerateTexture()
    {
        int index = 0;
        for (int i = 0; i < canvasHeight; i++)
        {
            for (int j = 0; j < canvasWidth; j++)
            {
                UnityEngine.Vector2 c = new Vector2((pos.x + i / canvasHeight * (float)scale), (pos.y + j / (canvasWidth * (float)scale)));
                float r = 2;
                float r2 = r * r;
                UnityEngine.Vector2 z = Vector2.zero;
                float iter;
                for (iter = 0; iter < MaxIter; iter++)
                {
                    z = new UnityEngine.Vector2(z.x * z.x - z.y * z.y, 2 * z.x * z.y);
                    z = z + c;
                    if (UnityEngine.Vector2.Dot(z, z) > r2) break;
                }
                if (iter >= MaxIter)
                {
                    colors[index] = new Color(0, 0, 0);
                    index++;
                    continue;
                }
                float dist = z.magnitude;
                float fracIter = (dist - r) / (r2 - r);
                fracIter = Mathf.Log(Mathf.Log(dist) / Mathf.Log(2));
                //iter -= fracIter;
                //float m = Mathf.Sqrt(iter / MaxIter);
                colors[index] = new Color((Mathf.Sin(.15f) * fracIter), (Mathf.Sin(.6f) * fracIter), (Mathf.Sin(.8f) * fracIter));
                index++;
                
            }
        }
        texture2D.SetPixels(colors, 0);
        texture2D.Apply(false, false);
        GetComponent<RawImage>().texture = texture2D;
    }
    /*
                float iter;
                double a = minX + (double)i / canvasHeight * zoom;
                double b = minY + (double)j / canvasWidth * zoom;
                Complex C = new Complex(b, a);
                Complex Z = new Complex(0, 0);
                for (iter = 0; iter < MaxIter; iter++)
                {
                    Z = Z * Z;
                    Z = Z + C;
                    if (Complex.Abs(Z) > 2.0) break;
                }
                if (iter >= MaxIter)
                {
                    colors[index] = new Color(0, 0, 0);
                    index++;
                    continue;
                }
                float dist = (float)Z.Magnitude;
                float fracIter = (dist - 2) / 4;
                fracIter = Mathf.Log(Mathf.Log(dist) / Mathf.Log(2));
                colors[index] = new Color((Mathf.Sin(.15f) * fracIter), (Mathf.Sin(.6f) * fracIter), (Mathf.Sin(.8f) * fracIter));
                index++;*/
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            scale *= 0.99f;
            GenerateTexture();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            scale *= 1.01f;
            GenerateTexture();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            pos.x -= 0.01f * (float)scale;
            GenerateTexture();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            pos.x += 0.01f * (float)scale;
            GenerateTexture();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            pos.y += 0.01f * (float)scale;
            GenerateTexture();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            pos.y -= 0.01f * (float)scale;
            GenerateTexture();
        }

        if (Input.GetMouseButton(0))
        {
            UnityEngine.Vector2 pos = RectTransformUtility.PixelAdjustPoint(Input.mousePosition, transform, canvas);
            minX = centerX - scale / 2;
            minY = centerY - scale / 2;
            centerX = minX + pos.x / canvasHeight * scale;
            centerY = minY + pos.y / canvasWidth * scale;
            scale *= .92f;
            GenerateTexture();
        }
    }
}
