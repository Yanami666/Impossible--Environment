Shader "Unlit/StripedTunnel"
{
    Properties
    {
        _StripeDensity ("Stripe Density", Float) = 20
        _Smoothness ("Edge Smoothness", Float) = 0.05
        _Color1 ("Color 1", Color) = (1,1,1,1)
        _Color2 ("Color 2", Color) = (0,0,0,1)
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

            float _StripeDensity;
            float _Smoothness;
            fixed4 _Color1;
            fixed4 _Color2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float stripes = sin(i.uv.y * _StripeDensity * 6.2831); // 2¦Ð = 6.2831
                stripes = smoothstep(0.0, _Smoothness, stripes); // Èí¹ý¶É

                return lerp(_Color2, _Color1, stripes);
            }
            ENDCG
        }
    }
}
