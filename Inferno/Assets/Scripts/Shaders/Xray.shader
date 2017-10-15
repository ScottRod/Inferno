Shader "Custom/General/Xray" {

  Properties {

  _MainTex("Texture", 2D) = "white" {}

  }

  SubShader {

  Tags {"Queue" = "Transparent"}

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

  v2f vert(appdata v) {

  v2f o;

  o.uv = v.uv;

  o.vertex = UnityObjectToClipPos(v.vertex);

  return o;

  }

  uniform sampler2D _MainTex;

  fixed4 frag(v2f i) : SV_Target {

  fixed4 col = tex2D(_MainTex, i.uv); 

  fixed average = (col.r+col.b+col.g)/3;

  col.r = average;

  col.b = average;

  col.g = average;

  col.rgb = 1 - col.rgb;

  return col;

  }

  ENDCG

  }

  }

}