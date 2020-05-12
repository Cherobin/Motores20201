using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{

    Vector3 touchPosWorld;

    TouchPhase touchPhase = TouchPhase.Ended;

    public GameObject prefab;
    public GameObject objectCoins;
    public int countClick = 1;


    bool isMobile = (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer);

    private void Start()
    {
        if (prefab == null)
        {
            Debug.Log("prefab is null in ->" + name);
        }

        if (objectCoins == null)
        {
            Debug.Log("objectCoins is null in ->" + name);
        }
    }

    void Update()
    {
        //DELETE
        if (isMobile)
        {
            Mobile();
        } else
        {
            Desktop();
        }

        //CREATE
        if (Input.GetButtonDown("Fire1") && !GameController.isPause && GameController.isPlayerOne)
        {
            PutCoin(Input.mousePosition);
        }

    }

    public void Mobile()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.transform.CompareTag("Pick Up"))
                {
                    Destroy(hit.transform.gameObject);
                }

            }
        }

    }

    public void Desktop()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.transform.CompareTag("Pick Up"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    public void PutCoin(Vector3 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000);

        if (hit.collider != null && hit.transform.CompareTag("create"))
        {
            GameObject c = Instantiate(prefab, hit.point, Quaternion.identity, objectCoins.transform);
            c.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            c.GetComponent<CoinBehaviourScript>().maxValueCoin += countClick;
            countClick++;
        }
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLenth)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayLenth, Color.yellow, rayLenth);
        Physics.Raycast(ray, out hit);
        return hit;
    }


    // convert point mouse screen wolrd to point 2D
    /*
    Vector3 cursorWorld()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            -1*Camera.main.transform.position.z));
    }
    */
}
