Shader "Unlit/WireElectricity"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color1("Color1", Color) = (1,1,1,1)
        _Color2("Color2", Color) = (1,1,1,1)
        _ScaleX("ScaleX", Float) = 1.0
        _ScaleY("ScaleY", Float) = 1.0        
        _Speed("Speed", Float) = 1.0
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float _ScaleX;
            float _ScaleY;
            float _Speed;
            float4 _Color1;
            float4 _Color2;

            fixed4 frag(v2f i) : SV_Target
            {
                i.uv.x *= _ScaleX;
                i.uv.y *= _ScaleY;
                // sample the texture
                i.uv.y += _Time * _Speed;

                fixed4 lerpCol = tex2D(_MainTex, i.uv);

                //make gradient here
                fixed4 lerpedColor = lerp(_Color1, _Color2, lerpCol);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, lerpedColor);
                return lerpedColor;
            }
            ENDCG
        }
    }
}
