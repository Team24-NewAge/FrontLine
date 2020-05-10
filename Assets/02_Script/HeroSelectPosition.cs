using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectPosition : MonoBehaviour
{
    Transform t, st;
    public GameObject saveP;
    public void Rerot()
    {
        st = saveP.GetComponent<Transform>();
        t = gameObject.GetComponent<Transform>();

        t.rotation = Quaternion.Euler(0, 130, 0);
        t.position =st.position;
    }
}
