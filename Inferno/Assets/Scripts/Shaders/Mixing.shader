// Name: Mixing Shader
// Author: Scott Blyth
// Date Finished: 8/10/17
// 
//

Shader "Custom/General/Mixing" {

   Properties {

   _MainTex("Texture 1", 2D) = "white" {}

   _Color1("Colour 1", Color) = (1,1,1,1) 

   _Color2("Colour 2", Color) = (1,1,1,1)

   _MixingTex("Texture 2", 2D) = "white" {}

   _MixAmount("Mix Amount", Range(0,1)) = 0.5

   }

   SubShader {

   Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}

   LOD 200

   ZWrite Off

   Pass {

   CGPROGRAM 

   #pragma vertex vert

   #pragma fragment frag

   #include "UnityCG.cginc" 


   struct appdata {

   float4 vertex : POSITION;

   float2 uv : TEXCOORD0;

   };

   struct v2f {

   float4 vertex : SV_POSITION;

   float2 uv : TEXCOORD0;

   };

   v2f vert(appdata v) {

   v2f o;

   o.vertex = UnityObjectToClipPos(v.vertex);

   o.uv = v.uv;

   return o;

   }

   uniform sampler2D _MainTex;

   uniform sampler2D _MixingTex;

   uniform fixed4 _Color1;

   uniform fixed4 _Color2;

   uniform float _MixAmount;

   fixed4 frag(v2f i) : SV_Target {

   fixed4 col1 = tex2D(_MainTex, i.uv) * _Color1;

   fixed4 col2 = tex2D(_MixingTex, i.uv) * _Color2;

   fixed4 finalCol = lerp(col1, col2, _MixAmount);

   return finalCol;

   }

   ENDCG

   }

   }

}