Shader "Unlit/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness("Thickness", Float) = 1.0
        _Active("Active", Int ) = 0
        _Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull off
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

            float _Thickness;
            int _Active;
            float4 _Color;

            v2f vert (appdata v)
            {
                v.vertex.x *= _Thickness;
                v.vertex.y *= _Thickness;
                v.vertex.z *= _Thickness;

                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                //MOVE VERTICES
                float3 pos = (0,0,0);
                pos *= _Thickness;

                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {                

                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                
                col.w = _Active;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }

            fixed4 frag(fixed facing : VFACE) : SV_Target
            {
                // VFACE input positive for frontbaces,
                // negative for backfaces. Output one
                // of the two colors depending on that.
                if (_Active) {
                    fixed4 col = _Color;
                    if (facing > 0) {
                        col.w = 0;
                    }
                    else {
                        col.w = 1;
                    }
                    return col;
                }
                else {
                    return (0,0,0,0);
                }
            }
            ENDCG
        }
    }
}
