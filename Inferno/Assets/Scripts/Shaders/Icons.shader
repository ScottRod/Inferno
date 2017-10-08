
// Name: Icons 
// Author: Scott Blyth
// Date Finished: 8/10/17

Shader "Custom/Markers/Icons" {

   Properties {

   _Texture("Texture", 2D) = "white" {}

   _Color("Colour", Color) = (1,1,1,1)

   }

   SubShader {

   Tags {"Queue" = "Transparent"}

   Pass {

   Cull Back

   Ztest Always // makes the image always visible

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

   uniform sampler2D _Texture;

   uniform fixed4 _Color;

   fixed4 frag(v2f i) : SV_Target {

   fixed4 col = tex2D(_Texture, i.uv) * _Color;

   return col;

   }

   ENDCG

   }

   }

}