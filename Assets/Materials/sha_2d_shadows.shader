Shader "Unlit/sha_2d_shadows"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_LightColor("LightColor", Color) = (0,1,0,1)
		_LightPos("LightPos", Vector) = (0,0,0)
		_LightDir("LightDir", Vector) = (0,-1,0)
		_LightTheta("LightTheta", Float) = 2.0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			static const int NUM_SAMPLES = 100;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 pixCoord : TEXCOORD1;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float2 pixCoord : TEXCOORD1;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _LightColor;
			float3 _LightPos;
			float3 _LightDir;
			float _LightTheta;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.pixCoord = o.vertex;
				//UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float4 col;
				float2 a = i.pixCoord - _LightPos; a = normalize(a);
				float2 b = float2(_LightDir.x, _LightDir.y);
				float cosPhi = dot(a, b);
				bool isEnlighted = (cosPhi < _LightTheta);

				/*for (int i = 0; i < NUM_SAMPLES; i++) {
				}*/

				//UNITY_APPLY_FOG(i.fogCoord, col);

				if (isEnlighted)
					col = _LightColor;
				else 
					col = float4(0, 0, 1, 1); // bleu = outside

				//return col;
				return float4(i.pixCoord.x, i.pixCoord.y, 0, 1);
			}
			ENDCG
		}
	}
}
