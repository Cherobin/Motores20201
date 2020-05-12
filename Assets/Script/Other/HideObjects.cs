using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjects : MonoBehaviour
{
    public Transform WatchTarget;
    public LayerMask OccluderMask;

    public Material HiderMaterial;

    private Dictionary<Transform, Material> LastTransforms;

    // Start is called before the first frame update
    void Start()
    {
        LastTransforms = new Dictionary<Transform, Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LastTransforms.Count > 0)
        {
            foreach (Transform t in LastTransforms.Keys)
            {
                t.GetComponent<Renderer>().material = LastTransforms[t];
            }

            LastTransforms.Clear();

        }

        RaycastHit[] hits = Physics.RaycastAll(
         transform.position,
         WatchTarget.transform.position - transform.position,
         Vector3.Distance(WatchTarget.transform.position, transform.position),
         OccluderMask
       );

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.transform != WatchTarget && hit.collider.transform.root != WatchTarget)
                {
                    LastTransforms.Add(hit.collider.gameObject.transform, hit.collider.gameObject.GetComponent<Renderer>().material);
                    hit.collider.gameObject.GetComponent<Renderer>().material = HiderMaterial;
                }

            }

        }
          
    }
}
