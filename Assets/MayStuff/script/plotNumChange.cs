using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotNumChange : MonoBehaviour
{
    [SerializeField] Renderer render1;
    [SerializeField] Renderer render2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(render1.material.color == Color.red && render2.material.color == Color.red)
        {
            GetComponent<dialogues>().myPlotNum = 2;
        }
        if (render1.material.color == Color.red && render2.material.color == Color.red)
        {
            GetComponent<dialogues>().myPlotNum = 2;
        }
    }
}
