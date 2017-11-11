Shader "Custom/Magic/Teleport" {

   Properties {

   _MainTex("Texture", 2D) = "white" {}

   _Color("Colour", Color) = (1,1,1,1)

   PatternTexture("Pattern Texture", 2D) = "white" {}

   _NoiseTex("Noise Texture", 2D) = "white" {}

   _Speed("Speed", Range(0.1, 5)) = 1

   _Lights("Lights", Range(0, 10)) = 4

   _Darkness("Darkness", Range(0, 10)) = 1

   }

   SubShader {

   Pass {

   Tags {"Queue" = "Transparent"}

   Blend SrcAlpha OneMinusSrcAlpha

   Zwrite Off

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

   uniform sampler2D _MainTex;

   uniform fixed4 _Color;

   uniform sampler2D PatternTexture;

   uniform sampler2D _NoiseTex;

   uniform float _Speed;

   uniform float _Lights;

   uniform float _Darkness;

   v2f vert(appdata v) {

   v2f o;

   o.uv = v.uv;

   if(tex2Dlod(PatternTexture, float4(o.uv.x,v.vertex.y,0,0)).r < 0.1 && tex2Dlod(PatternTexture, float4(o.uv.x,v.vertex.y,0,0)).b < 0.1 && tex2Dlod(PatternTexture, float4(o.uv.x,v.vertex.y,0,0)).g < 0.1) {

  // v.vertex.y += sin(_Time[1]*v.vertex.x);

   }

   o.vertex = UnityObjectToClipPos(v.vertex);

   return o;

   }

   fixed4 frag(v2f i) : SV_Target {

   fixed4 pCol = tex2D(PatternTexture, i.uv);

   fixed4 col = tex2D(_MainTex, i.uv) * _Color;

   fixed4 NoiseCol = tex2D(_NoiseTex, i.uv);

   if(pCol.a < 0.1) {

   col.a  = 0;

   }

   for(float x = -_Lights/2; x < _Lights/2; x++) {

   float y = x / _Lights;
  
   col.rgb /= distance(y+NoiseCol.r, i.uv.x + sin(_Time[1] * _Lights / _Speed)/_Lights) * _Darkness;

   }
    
   return col;

   }

   ENDCG

   }

   }

}