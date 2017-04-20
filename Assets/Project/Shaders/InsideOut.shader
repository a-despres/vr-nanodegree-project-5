Shader "Unlit/InsideOut"
{
	Properties {
		_Color ("Main Color", COLOR) = (1, 1, 1, 0)
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	}
	Category {
		Lighting Off
		Cull Front
		Tags { "Queue" = "Transparent" }
		SubShader {
			Pass {
				Blend SrcAlpha OneMinusSrcAlpha
				SetTexture[_MainTex] {
					constantColor [_Color]
					Combine texture * constant
				}
			}
		}
	}

}
