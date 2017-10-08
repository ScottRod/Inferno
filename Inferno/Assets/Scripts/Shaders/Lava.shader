
// Name: Lava 
// Author: Scott Blyth
// Data Finished: 6/10/17
//
//

Shader "Custom/Enviroment/Lava" {

   Properties {

   _MainTex("Main Texture", 2D) = "white" {}

   _Color("Main Colour", Color) = (1,1,1,1)

   _AuraColour("Aura Colour", Color) = (1,1,1,1)

   _AuraSize("Aura Size", Range(1,3)) = 1.1 

   _AuraTexture("Aura Texture", 2D) = "white" {}

   _AuraStrength("Aura Strength", Range(0.25,5)) = 1

   _NoiseTex("Noise Texture", 2D) = "white" {}

   _MovingFire("Fire Movement", Vector) = (1,1,1)

   Position("Position", Vector) = (0,0,0)
  
   }

   SubShader {

   Tags {"Queue" = "Transparent"}

   Zwrite Off

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

   uniform float _AuraSize;

   uniform float3 Position;

   uniform sampler2D _AuraTexture;

   uniform float _AuraStrength;

   uniform sampler2D _NoiseTex;

   uniform float3 _MovingFire;

   v2f vert(appdata v) {

   v2f o;

   v.vertex.x += (sin(v.vertex.x*_Time[1]*10)/10*tex2Dlod(_NoiseTex, float4(v.vertex.x,0,0,0)).r)*_MovingFire.x;

   v.vertex.y += (sin(v.vertex.y*_Time[1]*10)/10*tex2Dlod(_NoiseTex, float4(v.vertex.x,0,0,0)).r)*_MovingFire.y;

   v.vertex.z += (sin(v.vertex.z*_Time[1]*10)/10*tex2Dlod(_NoiseTex, float4(v.vertex.x,0,0,0)).r)*_MovingFire.z;

   v.vertex.xyz *= _AuraSize;

   o.vertex = UnityObjectToClipPos(v.vertex);

   o.uv = v.uv;

   return o;

   }

   uniform fixed4 _AuraColour;

   fixed4 frag(v2f i) : SV_Target {

   fixed4 col = tex2D(_AuraTexture, i.uv) * _AuraColour;

   col.rgb /= distance(i.uv,float2(0.5,0.5))*_AuraStrength;

   return col;

   }

   ENDCG

   }

   Pass {

   Zwrite On

   Blend SrcAlpha OneMinusSrcAlpha

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

   uniform fixed4 _Color;

   uniform sampler2D _MainTex;

   fixed4 frag(v2f i) : SV_Target {

   fixed4 col = tex2D(_MainTex, i.uv) * _Color;

   return col;

   }

   ENDCG

   }

   }

}