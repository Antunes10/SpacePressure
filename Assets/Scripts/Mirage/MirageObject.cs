using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageObject : MonoBehaviour
{
    // Start is called before the first frame update
    private MirageManager miri;
    private MeshRenderer _mesh;
    private Collider _collider;

    [SerializeField] bool firstdoor;
    [SerializeField] private MeshRenderer _mesh1;
    [SerializeField] private MeshRenderer _mesh2;

    void Start()
    {
        miri = MirageManager.Instance;
        EnableInteraction();

        if (!firstdoor){
            _mesh = gameObject.GetComponent<MeshRenderer>();
        }
        _collider = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Materialize()
    {

        if (firstdoor)
        {
            _mesh1.enabled = !_mesh1.enabled;
            _mesh2.enabled = !_mesh2.enabled;
        }
        else
        {
            _mesh.enabled = !_mesh.enabled;
        }
        _collider.enabled = !_collider.enabled;

    }

    public void EnableInteraction() {
        miri.Mirage += Materialize;
    }

    public void DisableInteraction() {
        miri.Mirage -= Materialize;
    }

}
