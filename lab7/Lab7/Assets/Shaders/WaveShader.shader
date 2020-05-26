Shader "Custom/Waves"{
	Properties{
	   _Color("Color", Color) = (0, 0, 0, 1)
	   _Strength("Strength", Range(0,4)) = 1.0
	   _Speed("Speed", Range(-200, 200)) = 100
	   _Offset("Offset", Range(0, 1)) = 0.6
	}

		SubShader{
		   Tags{
		      "Queue" = "Transparent"
			  "RenderType" = "transparent"
		   }
		   GrabPass
		   {
			 Name "BASE"
			 Tags { "LightMode" = "ForwardAdd" }
		   }
		   Pass
		   {
		   Cull Off
		   //Zwrite Off
		   Blend SrcAlpha OneminusSrcAlpha

		   CGPROGRAM

		   #pragma vertex vertexFunc
		   #pragma fragment fragFunc
           #include "UnityCG.cginc"

		   float4 _Color;
		   float _Strength;
		   float _Speed;
		   float _Offset;
		   sampler2D _GrabTexture;

		   struct vertexInput {
			  float4 vertex : POSITION;
		   };

		   struct vertexOutput {
			  float4 pos : SV_POSITION;
			  float4 screenUV : TEXCOORD0;
		   };

		   vertexOutput vertexFunc(vertexInput IN) {
			  vertexOutput o;

			  float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);

			  float displacement = (cos(worldPos.y) + cos(worldPos.x + (_Speed * _Time)));
			  worldPos.y = worldPos.y + (displacement * _Strength);

			  o.pos = mul(UNITY_MATRIX_VP,  worldPos);
			  o.screenUV = ComputeGrabScreenPos(IN.vertex);

			  return o;
		   }

		   float4 fragFunc(vertexOutput IN) : COLOR{
			  float4 newcolor = float4(_Color.xyz, 1.0);
			  float4 grab = tex2Dproj(_GrabTexture, IN.screenUV);

			  return newcolor * grab;
		   }

		   ENDCG
		   }
	}

}
