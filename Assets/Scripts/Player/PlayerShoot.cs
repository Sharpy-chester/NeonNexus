using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] int bulletDamage;
    [SerializeField] Transform fireTransform;
    [SerializeField] Animator gunAnim;
    [SerializeField] GameObject muzzleFlash;
    public float weaponCooldown = 0.5f;
    [SerializeField] float cooldownCap = 0.1f;
    float currentCooldown = 0;
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        currentCooldown += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && currentCooldown > weaponCooldown)
        {
            currentCooldown = 0;
            gunAnim.SetTrigger("Fire");
            GameObject mFlash = Instantiate(muzzleFlash, fireTransform);
            Destroy(mFlash, 1);

            if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<Turret>())
                {
                    hit.transform.GetComponent<Health>().ReduceHealth(bulletDamage);
                }
            }
        }
    }

    public void IncreaseFireRate(float amt)
    {
        if (weaponCooldown - amt >= cooldownCap)
        {
            weaponCooldown -= amt;
        }
    }
}
