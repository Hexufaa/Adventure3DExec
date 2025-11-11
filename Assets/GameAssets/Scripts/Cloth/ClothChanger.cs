using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

namespace Cloth
{

    public class ClothChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer mesh;
        public Texture2D texture;
        public string ShaderIdName = "_EmissionMap";

        private Texture _defaultTexture;
        private void Awake()
        {
            _defaultTexture = mesh.sharedMaterials[0].GetTexture(ShaderIdName);
        }

        [NaughtyAttributes.Button]
       private void ChangeTexture()
        {
            mesh.materials[0].SetTexture(ShaderIdName, texture);
        }

        public void ChangeTexture(ClothSetup setup)
        {
            mesh.materials[0].SetTexture(ShaderIdName, setup.texture);
        }

        public void ResetTexture()
        {
            mesh.sharedMaterials[0].SetTexture(ShaderIdName, _defaultTexture);
        }
    }
}
