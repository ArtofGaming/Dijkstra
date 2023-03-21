using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;
    public GameObject[] beggars;
    public int dirtiness;


    private void Start()
    {
        beggars = new GameObject[4];
        for (int i = 0; i < beggars.Length; i++)
        {
            beggars[i] = (GameObject.CreatePrimitive(PrimitiveType.Capsule));
            beggars[i].transform.position = new Vector3(this.transform.position.x + Random.Range(-.6f,.6f), this.transform.position.y, this.transform.position.z + Random.Range(-.5f, .5f));
        }
        GameObject mudPuddle = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Color custom = new Color(.4f, .2f, 0f, 1f);
        mudPuddle.GetComponent<Renderer>().material.color = custom;
        mudPuddle.transform.localScale = new Vector3(dirtiness * .1f,.0f,dirtiness * .1f);
        mudPuddle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, n.transform.position);
            Gizmos.DrawRay(transform.position, (n.transform.position-transform.position).normalized * 2);
        }
    }

}
