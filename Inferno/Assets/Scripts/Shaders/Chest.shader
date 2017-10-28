Shader "Custom/Objects/Chest" {
	Properties {
		_Color ("Colour", Color) = (1,1,1,1)

		_MainTex ("Texture", 2D) = "white" {}

		_LitPattern("Lit Pattern", 2D) = "white" {}

		_NoiseTex("Noise Texture", 2D) = "white" {}

		_BumpMap("Normal", 2D) = "bump" {}

		_NewColour("Lit Colour", Color) = (1,1,1,1)

		_Darkness("Darkness", Range(1, 10)) = 3

		_Speed("Speed", Range(1, 10)) = 3

		_Lights("Lights", Range(0, 25)) = 3

		_Glossiness ("Smoothness", Range(0,1)) = 0.5

		_Metallic ("Metallic", Range(0,1)) = 0.0

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		uniform sampler2D _LitPattern;

		uniform fixed4 _NewColour;

		uniform float _Darkness;

		uniform float _Speed;

		uniform float _Lights;

		uniform sampler2D _NoiseTex;

		uniform sampler2D _BumpMap;

		UNITY_INSTANCING_CBUFFER_START(Props)

		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {

			fixed4 col = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			fixed4 PatternCol = tex2D(_LitPattern, IN.uv_MainTex);

			fixed4 NoiseCol = tex2D(_NoiseTex, IN.uv_MainTex);

			fixed4 NormalColour = tex2D(_BumpMap, IN.uv_BumpMap);

			if(PatternCol.r > 0.1 && PatternCol.b > 0.1 && PatternCol.g > 0.1) {

			col = ((sin(_Time[1])+2) * (_NewColour * 10))/2;

			for(float i = -_Lights/2.0; i < _Lights/2.0; i++) {

			float x = i / _Lights; 

			col.rgb /= distance(x + NoiseCol.r, IN.uv_MainTex.x + (sin(_Time[1] * _Lights / _Speed)/_Lights)) * _Darkness;

			}

			NormalColour = float4(0,0,0,0);

			}

			o.Normal = UnpackNormal(NormalColour);

			o.Albedo = col.rgb;

			o.Metallic = _Metallic;

			o.Smoothness = _Glossiness;

			o.Alpha = col.a;

		}
		ENDCG
	}
	FallBack "Diffuse"
}
