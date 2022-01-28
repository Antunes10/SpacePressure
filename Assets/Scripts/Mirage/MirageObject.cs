using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageObject : MonoBehaviour
{
    // Start is called before the first frame update
    private MirageManager miri;
    private MeshRenderer _mesh;
    private BoxCollider _boxcollider;
    void Start()
    {
        miri = MirageManager.Instance;
        miri.Mirage += Materialize;
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _boxcollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Materialize()
    {
        _mesh.enabled = !_mesh.enabled;
        _boxcollider.enabled = !_boxcollider.enabled;

    }

}
