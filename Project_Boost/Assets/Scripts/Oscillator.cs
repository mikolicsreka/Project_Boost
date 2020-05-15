using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] float movementFactor;

    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);

    Vector3 startingPos;
 
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float miatt nem vizsgálhatjuk h period == 0, mert akár egy kicsivel is de eltér
        //az epszilon pedig a legkisebb szám ami..
        if(period <= Mathf.Epsilon) { return; }
        //set movement factor
        float cycles = Time.time / period; //grows contiunally from 0

        const float tau = Mathf.PI * 2; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); //[-1,+1]

        movementFactor = rawSinWave / 2f + 0.5f; //[0,1]

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
