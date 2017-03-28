Shader "Unlit/No Z"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	
	SubShader
	{
		LOD 100

		Tags
		{
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			/*ZWrite Off
			ZTest Off
			Fog { Mode Off }
			Offset -1, -1
			ColorMask RGB*/
			
			SetTexture [_MainTex]
			{
				Combine Texture
			}
		}
	}
}