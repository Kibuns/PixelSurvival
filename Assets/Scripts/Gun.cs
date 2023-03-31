using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public GameObject shootPoint;
    private GameObject target;
    public GameObject flash;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            target = gameObject.GetComponentInParent<WeaponManager>().target;
        }
    }

    public void Fire()
    {
        RaycastHit hit;

        Vector3 fireDirection = (target.transform.position - transform.position).normalized;

        Debug.DrawRay(shootPoint.transform.position, fireDirection, Color.white, 2);

        if (Physics.Raycast(shootPoint.transform.position, fireDirection, out hit, Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            tempBullet.GetComponent<MoveBullet>().direction = (hit.point - shootPoint.transform.position).normalized;
            Instantiate(flash, shootPoint.transform.position, Quaternion.identity);
        }
        else
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            tempBullet.GetComponent<MoveBullet>().direction = fireDirection;
            Instantiate(flash, shootPoint.transform.position, Quaternion.identity);
        }
    }

}
