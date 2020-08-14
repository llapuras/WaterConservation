Shader "Lapu/Water002"
{
	Properties
	{
		_Tint("Tint", Color) = (1, 1, 1, .5)
		_Amount("Wave Amount", Range(0,1)) = 0.5
		_Height("Wave Height", Range(0,1)) = 0.5
		_Speed("Wave Speed", Range(0,1)) = 0.5
		_FoamThickness("Foam Thickness", Range(0,5)) = 0.5
		_DepthRamp("Depth Ramp", 2D) = "white"{}
		_EdgeColor("Edge Color", Color) = (1, 1, 1, .5)
	}


		SubShader
		{
			Tags { "RenderType" = "Opaque"  "Queue" = "Transparent" }
			LOD 100
			Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag	
				#include "UnityCG.cginc"

				sampler2D _CameraDepthTexture;//unity内置变量，无需在Properties中声明

				float4 _Tint, _EdgeColor;
				float _Speed, _Amount, _Height, _FoamThickness;
				sampler2D _DepthRamp;
				float4 _DepthRamp_ST; //当使用TRANSFORM_TEX时需要加上贴图同名+_ST后缀的变量声明

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
					float4 screenPos : TEXCOORD1;
					float2 depthtex : TEXCOORD2;
				};

				v2f vert(appdata v)
				{
					v2f o;
					v.vertex.y += sin(_Time.z * _Speed + (v.vertex.x * v.vertex.z * _Amount)) * _Height;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.screenPos = ComputeScreenPos(o.vertex);
					//o.depthtex = TRANSFORM_TEX(v.uv, _DepthRamp);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float4 depthSample = SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, (i.screenPos));
					float depth = LinearEyeDepth(depthSample).r;
					//float foamLine = 1 - saturate(_FoamThickness * (depth - i.screenPos.w));
					//float4 foamRamp = float4(tex2D(_DepthRamp, float2(foamLine, 0.5)).rgb, 1.0);
					half4 col = _Tint;

					float4 foamLine = col * float4(depth, depth, depth, 1) * 0.3;

					//col += foamLine * _Tint;

					return foamLine;
				}
				ENDCG
			}
		}

}