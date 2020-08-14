Shader "Lapu/BlurUI003"
{
	Properties
	{
		_Color("Color", COLOR) = (1,1,1,1)
		_Radius("Blur Radius", Range(0, 300)) = 1
		_MainTex("Main Texture", 2D) = "white" {}
	}

		SubShader
	{
		Tags{ "Queue" = "Transparent"}

		GrabPass {}

	GrabPass{}
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
			float4 vertex : SV_POSITION;
			float4 screenPos : TEXCOORD0;
			float4 grabPos : TEXCOORD1;
			float2 uv : TEXCOORD2;
		};

		sampler2D _GrabTexture;
		float4 _GrabTexture_TexelSize;

		int _Radius;
		sampler2D _MainTex;
		float4 _Color, _MainTex_ST;

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.screenPos = ComputeScreenPos(o.vertex);
			o.grabPos = ComputeGrabScreenPos(o.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			return o;
		}

		half4 frag(v2f i) : SV_TARGET
		{
			if (tex2D(_MainTex, i.uv).a < 0.5f)
					discard;

			float4 result = tex2Dproj(_GrabTexture, i.screenPos);
			float4 grabPos;
     		grabPos.zw = i.screenPos.zw;
			for (int range = 1; range <= _Radius; range++)
			{
				float2 w1 = i.screenPos.xy + float2(_GrabTexture_TexelSize.x * 0, _GrabTexture_TexelSize.y * range);
				i.grabPos.xy = w1;
				result += tex2Dproj(_GrabTexture, i.screenPos + i.grabPos);

				float2 w2 = i.screenPos.xy + float2(_GrabTexture_TexelSize.x * 0, _GrabTexture_TexelSize.y * -range);
				i.grabPos.xy = w2;
				result += tex2Dproj(_GrabTexture, i.screenPos + i.grabPos);
			}

			float4 col = tex2D(_MainTex, i.uv);
			float2 texPos = i.uv;
			//i.grabPos.zw = i.screenPos.zw;
			for (int range = 1; range <= _Radius; range++)
			{
			
				float2 w1 = float2(i.uv.x * -range, i.uv.y * range);
				texPos.xy = w1;
				col += tex2D(_MainTex, texPos);

				float2 w2 = float2(i.uv.x * -range, i.uv.y * -range);
				texPos.xy = w2;
				col += tex2D(_MainTex, texPos);
			}

			//col /= _Radius * 2 + 1;
			result /= _Radius * 2 + 1; 		//除以_Radius*2取均值

			//return  result + col;
			return  result;
		}
		ENDCG
	}

		GrabPass{}
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
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD0;
				float4 grabPos : TEXCOORD1;
				float2 uv : TEXCOORD2;
			};

			sampler2D _GrabTexture;
			float4 _GrabTexture_TexelSize;

			int _Radius;
			sampler2D _MainTex;
			float4 _Color, _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				o.grabPos = ComputeGrabScreenPos(o.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}

			half4 frag(v2f i) : SV_TARGET
			{
				if (tex2D(_MainTex, i.uv).a < 0.5f)
					discard;

				float4 result = tex2Dproj(_GrabTexture, i.screenPos);
				i.grabPos.zw = i.screenPos.zw;
				for (int range = 1; range <= _Radius; range++)
				{
					float2 w3 = i.screenPos.xy + float2(_GrabTexture_TexelSize.x * range, _GrabTexture_TexelSize.y * 0);
					i.grabPos.xy = w3;
					result += tex2Dproj(_GrabTexture, i.screenPos + i.grabPos);

					float2 w4 = i.screenPos.xy + float2(_GrabTexture_TexelSize.x * -range, _GrabTexture_TexelSize.y * 0);
					i.grabPos.xy = w4;
					result += tex2Dproj(_GrabTexture, i.screenPos + i.grabPos);

				}
		
				result /= _Radius * 2 + 1;
				result = half4(_Color.a * _Color.rgb + (1 - _Color.a) * result.rgb, 1.0f);
				//col /= _Radius * 2 + 1;
				return result;
			}
			ENDCG

		}
	}

}