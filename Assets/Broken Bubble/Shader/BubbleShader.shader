// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BubblesMat"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.03
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_BaseColor("BaseColor", Color) = (0,0,0,0)
		_InsideColor("InsideColor", Color) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha noshadow nolightmap  vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			float4 vertexColor : COLOR;
			half2 uv_texcoord;
		};

		uniform half4 _InsideColor;
		uniform half4 _BaseColor;
		uniform sampler2D _TextureSample0;
		uniform float _Cutoff = 0.03;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertexNormal = v.normal.xyz;
			float3 appendResult185 = (half3(ase_vertexNormal.x , 0.0 , ase_vertexNormal.z));
			float4 temp_output_155_0 = ( ( ( v.color * 2 ) + -1.0 ) + v.color.a );
			float4 lerpResult151 = lerp( float4( 1,1,1,0 ) , float4( 0,0,0,1 ) , saturate( temp_output_155_0 ));
			float3 ase_vertex3Pos = v.vertex.xyz;
			v.vertex.xyz = ( ( ( half4( appendResult185 , 0.0 ) * ( 1.0 - lerpResult151 ) ) * float4( 0.1981132,0.1981132,0.1981132,0 ) ) + half4( ase_vertex3Pos , 0.0 ) ).rgb;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			half3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			half3 ase_worldNormal = i.worldNormal;
			float fresnelNdotV190 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode190 = ( 0.3 + 0.3 * pow( 1.0 - fresnelNdotV190, 1.0 ) );
			o.Emission = ( ( fresnelNode190 * _InsideColor ) + _BaseColor ).rgb;
			o.Smoothness = 1.0;
			o.Alpha = 1;
			float4 temp_output_155_0 = ( ( ( i.vertexColor * 2 ) + -1.0 ) + i.vertexColor.a );
			float4 lerpResult151 = lerp( float4( 1,1,1,0 ) , float4( 0,0,0,1 ) , saturate( temp_output_155_0 ));
			clip( ( lerpResult151 * ( ( 1.0 - temp_output_155_0 ) * tex2D( _TextureSample0, i.uv_texcoord ) ) ).r - _Cutoff );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
