using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageObject : MonoBehaviour
{
    // Start is called before the first frame update
    private MirageManager miri;
    private MeshRenderer _mesh;
    private Collider _collider;
    void Start()
    {
        miri = MirageManager.Instance;
        EnableInteraction();
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _collider = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Materialize()
    {
        _mesh.enabled = !_mesh.enabled;
        _collider.enabled = !_collider.enabled;

    }

    public void EnableInteraction() {
        miri.Mirage += Materialize;
    }

    public void DisableInteraction() {
        miri.Mirage -= Materialize;
    }

}
