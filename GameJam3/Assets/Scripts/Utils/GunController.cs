using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinned;
    [SerializeField] private Mesh meshToChangeTo ;
    void Start() {
        
    }

    void Update() {
       skinned.sharedMesh = meshToChangeTo;
    }
}
