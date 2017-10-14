
// Author: Scott Blyth

// Name: Portal

// Date Finished: 14/10/17

Shader "Custom/Portal" {

   Properties {

     _MainTex("Texture", 2D) = "white" {}
   
     _Color("Tint Colour", Color) = (1,1,1,1)

     _Brightness("Brightness", Range(1, 10)) = 1

     _NoiseTex("Noise Texture", 2D) = "white" {}

     freq("Frequency", Range(1,30)) = 10

     Smoothness("Smoothness", Range(1,20)) = 10

      _OuterTexture("Outer Texture", 2D) = "white" {}

      _OuterColour("Outer Tint Colour", Color) = (1,1,1,1)

      _OuterRingSize("Ring Size", Range(1, 25)) = 1.5

   }

   SubShader {

     Tags {"Queue" = "Transparent"}

     Zwrite Off

     // outside pass

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

     uniform float _OuterRingSize;

     uniform sampler2D _OuterTexture;

     uniform fixed4 _OuterColour;

     v2f vert(appdata v) {

     v2f o;

     o.uv = v.uv;

     float x = v.vertex.x;

     float y = v.vertex.y;

     float z = v.vertex.z;

     float Pi = 3.14;

     v.vertex.x *= (sin(length(x/Pi)*_Time[1]*10) + 2) / 2;

     v.vertex.y *= (sin(length(y/Pi)*_Time[1]*10) + 2) / 2;

     v.vertex.z *= (sin(length(z/Pi)*_Time[1]*10) + 2) / 2;

     v.vertex.xyz *= _OuterRingSize;

     o.vertex = UnityObjectToClipPos(v.vertex);

     return o;

     }

     fixed4 frag(v2f i) :  SV_Target {

     fixed4 col = tex2D(_OuterTexture, i.uv) * _OuterColour;
 
     return col;

     }

     ENDCG

     }

     Blend SrcAlpha OneMinusSrcAlpha

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

     uniform float Smoothness;

     uniform sampler2D _NoiseTex;

     uniform sampler2D _MainTex;

     uniform fixed4 _Color;

     uniform fixed _Brightness;

     uniform float freq;

     v2f vert(appdata v) {

     v2f o; 

     o.uv = v.uv;

     float x = v.vertex.x;

     float y = v.vertex.y;

     float z = v.vertex.z;

     float3 tc = v.vertex.xyz;

     float len = length(tc);

     float3 newPos = (len * 5.0 * cos(len*24.0-_Time[1]*4.0) * 0.03);

     v.vertex.x += len*cos(len*24.0-_Time[1]*4.0)*tc.x*sin(x*_Time[1])/Smoothness * tex2Dlod(_NoiseTex, float4(x,0,0,0)).r;

     v.vertex.y += len*cos(len*24.0-_Time[1]*4.0)*tc.y*sin(y*_Time[1])/Smoothness * tex2Dlod(_NoiseTex, float4(x,0,0,0)).r;

     v.vertex.z += len*cos(len*24.0-_Time[1]*4.0)*tc.z*sin(z*_Time[1])/Smoothness * tex2Dlod(_NoiseTex, float4(x,0,0,0)).r;

     o.vertex = UnityObjectToClipPos(v.vertex);

     return o;

     }

     fixed4 frag(v2f i) : SV_Target {

     float2 tc = i.uv;

     float2 p = -1.0 + 2.0 * tc;

     float len = length(p);

     float2 newPos = tc + (p/len)*freq*cos(len*24.0-_Time[1]*4.0)*0.03;

     fixed4 col = tex2D(_MainTex, newPos);

     float averageColour = (col.r+col.b+col.g)/3.0;

     col.r = averageColour;

     col.b = averageColour;

     col.g = averageColour;

     col *= _Color;

     col.rgb *= distance(i.uv, float2(0.5,0.5))*_Brightness;

     return col;

     }

     ENDCG

     }

   }

}
