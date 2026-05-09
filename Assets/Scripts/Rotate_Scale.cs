using System.Collections;
using UnityEngine;

public class Rotate_Scale : MonoBehaviour
{
    public float sacleTime;
    public float scale;
    public float rotateAmount;
    public float scaleAmount;



    void Start()
    {
        StartCoroutine(ScaleObject());
    }


    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateAmount);
        transform.localScale += new Vector3(1f, 1f, 1f) * scale * scaleAmount;
    }

    private IEnumerator ScaleObject()
    {
        while (true)
        {


            yield return new WaitForSeconds(sacleTime);
            scale = -scale;
        }
    }
}
//setactive.audiiovlip ruido volvn
//yield return new WaitForSeconds(4);

