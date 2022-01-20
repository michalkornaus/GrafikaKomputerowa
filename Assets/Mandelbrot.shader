Shader "Explorer/Mandelbrot"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Area("Area", vector) = (0, 0, 4, 4)
		_MaxIter("Iterations", range(4, 15000)) = 255
		_Symmetry("Symmetry", range(0,1)) = 1
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				float4 _Area;
				float _MaxIter, _Symmetry;
				sampler2D _MainTex;

				float2 rot(float2 p, float2 pivot, float a)
				{
					float s = sin(a);
					float c = cos(a);
					p -= pivot;
					p = float2(p.x*c - p.y*s, p.x*s + p.y*c);
					p += pivot;
					return p;
				}

				float4 frag(v2f i) : SV_Target
				{
					float2 uv = i.uv;
					uv = abs(uv);
					uv = rot(uv, 0, .5*3.1415);
					//uv = abs(uv);
					//uv = lerp(i.uv - .5, uv, _Symmetry);
					float2 c = _Area.xy + i.uv*_Area.zw;
					float r = 2;
					float r2 = r * r;
					float2 z;
					float iter;
					for (iter = 0; iter < _MaxIter; iter++)
					{
						z = float2(z.x*z.x - z.y*z.y, 2 * z.x*z.y) + c;
						if (dot(z, z) > r2) break;
					}
					if (iter >= _MaxIter)
						return 0;
					float dist = length(z);
					float fracIter = (dist - r) / (r2 - r); //liniowa interpolacja
					fracIter = log2(log(dist) / log(r));
					iter -= fracIter;

					float m = sqrt(iter / _MaxIter);
					float4 col = sin(float4(.55 , .4, .3 , 1) * m * 15)*.5 + .5;
					float angle = atan2(z.y, z.x);
					//col *= smoothstep(6,0,fracIter);
					//col *= 1+ sin(angle*1)*.1;
					return col;
				}
				ENDCG
			}
		}
}
