using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    public GameObject heldWeapon;
    private PlayerControlls playerControlls;
    public GameObject target;

    private Gun heldGun;


    private bool wepPositionSet = false;
    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }
    void Start()
    {
        heldGun = heldWeapon.gameObject.GetComponent<Gun>();
    }

    void Update()
    {
        SetWeaponPositionAndParent();
        if (playerControlls.Player.Fire1.triggered)
        {
            heldGun.Fire();
        }
    }

    void SetWeaponPositionAndParent()
    {
        if (wepPositionSet) return;
        if (heldWeapon)
        {
            heldWeapon.transform.parent = transform;
            heldWeapon.transform.position = Vector3.zero;
            Rigidbody rb = heldWeapon.gameObject.GetComponentInChildren<Rigidbody>();
            Destroy(rb);
            Collider col = heldWeapon.gameObject.GetComponentInChildren<Collider>();
            Destroy(col);
            wepPositionSet = true;
        }
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }


}
