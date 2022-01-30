using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoors : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool _locked;
    [SerializeField] private Animator _anim;
    private bool _open;
    private float _defaultPos;
    private Vector3 translation;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_locked)
        {
            Debug.Log("Entrou");
            _anim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _anim.SetBool("Open", false);
        Debug.Log("Saiu");
    }

    void OpenDoor()
    {
        translation = new Vector3(-2.3f, 0, 0);
        _open = true;
    }

    /*void CloseDoor()
    {
        translation = new Vector3(0, 0, 0);
        _doors.transform.Translate(translation * Time.deltaTime);
        _open = false;
    }

    IEnumerator MoveDoor(Vector3 translation)
    {
        _doors.transform.Translate(translation * Time.deltaTime);
        _open = !_open;
        yield return 0;
    }*/
}
