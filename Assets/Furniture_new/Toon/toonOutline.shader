Shader "Unlit/LapuOutline"
{
    Properties
    {
        _OutlineWidth("Outline Width", Range(0, 1)) = 0.24
        _OutLineColor("OutLine Color", Color) = (0.5,0.5,0.5,1)
        _Color("Main Color", Color) = (.5,.5,.5,1)
        _MainTex("Base (RGB)", 2D) = "white" { }
        _Atten("Intensity",Range(0,10)) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }


            pass
            {
               Tags { "RenderType" = "Opaque" "LightMode" = "ForwardBase"}
                Blend SrcAlpha OneMinusSrcAlpha
                Cull Off

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                half _OutlineWidth, _Atten;
                half4 _OutLineColor, _Color;
                sampler2D _MainTex;
                float4 _MainTex_ST;

                struct a2v
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 texcoord : TEXCOORD0;
                    float4 vertColor : COLOR;
                    float4 tangent : TANGENT;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 texcoord : TEXCOORD0;
                };

                v2f vert(appdata_base v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);// UnityCG.cginc file contains function to transform
                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }

                half4 frag(v2f i) : SV_TARGET
                {
                    fixed4 col = _Color * tex2D(_MainTex, i.texcoord);
                    fixed4 c = fixed4(_Atten * col.rgb, col.a);

                    return c;
                }

                ENDCG
            }

            Pass
        {
            Tags {"LightMode" = "ForwardBase"}

                Cull Front

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                half _OutlineWidth, _Atten;
                half4 _OutLineColor, _Color;
                sampler2D _MainTex;
                float4 _MainTex_ST;

                struct a2v
            {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                    float4 vertColor : COLOR;
                    float4 tangent : TANGENT;
                };

                struct v2f
           {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };


                v2f vert(a2v v)
                {
                    v2f o;
                    UNITY_INITIALIZE_OUTPUT(v2f, o);
                    float4 pos = UnityObjectToClipPos(v.vertex);
                    //float3 viewNormal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal.xyz);
                    float3 viewNormal = mul((float3x3)UNITY_MATRIX_IT_MV, v.tangent.xyz);
                    float3 ndcNormal = normalize(TransformViewToProjection(viewNormal.xyz)) * pos.w;//将法线变换到NDC空间
                    pos.xy += 0.01 * _OutlineWidth * ndcNormal.xy;
                    o.pos = pos;
                    return o;
                }

                half4 frag(v2f i) : SV_TARGET
                {
                    return _OutLineColor;
                }
                ENDCG


            }

        }


}