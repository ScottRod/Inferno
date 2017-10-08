using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaterialChange : MonoBehaviour {

	public Material newMaterial;

	void OnRenderImage(RenderTexture src, RenderTexture dest) {


		Graphics.Blit (src, dest, newMaterial);

	}

}
