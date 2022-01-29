using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlickering : MonoBehaviour
{
    // Start is called before the first frame update
    private float _interval;
    private float _NextFlickerTime;
    [SerializeField] private Animator _lightAnim;
    void Start()
    {
        _NextFlickerTime = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        _NextFlickerTime -= Time.deltaTime;
        if (_NextFlickerTime < 0f)
        {
            Flicker();
        }
    }

    void Flicker()
    {
        _interval = Random.Range(10, 20);
        _NextFlickerTime += Time.deltaTime + _interval;
        _lightAnim.SetTrigger("Flicker");
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(_interval);
        Flicker();
    }
}
