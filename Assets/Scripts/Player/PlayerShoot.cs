using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] int bulletDamage;
        [SerializeField] Transform fireTransform;
        [SerializeField] Animator gunAnim;
        [SerializeField] AnimationClip shootAnim;
        [SerializeField] AudioClip shootSFX;
        [SerializeField] GameObject muzzleFlash;
        [SerializeField] GameObject bloodPrefab;
        public float weaponCooldown = 0.5f;
        [SerializeField] float cooldownCap = 0.1f;
        float currentCooldown = 0;
        Transform cam;
        int layer = ~(1 << 10);

        public delegate void OnShoot();
        public event OnShoot onShoot;

        private void Start()
        {
            cam = Camera.main.transform;
            gunAnim.SetFloat("AnimMultiplier", shootAnim.length / weaponCooldown);
        }

        void Update()
        {
            currentCooldown += Time.unscaledDeltaTime;
            if(Time.timeScale != 1 && Time.timeScale != 0)
            {
                gunAnim.SetFloat("AnimMultiplier", (shootAnim.length / weaponCooldown) / (Time.timeScale / 1.5f));
            }
            else if (gunAnim.GetFloat("AnimMultiplier") != shootAnim.length / weaponCooldown)
            {
                gunAnim.SetFloat("AnimMultiplier", shootAnim.length / weaponCooldown);
            }
            if (Input.GetButtonDown("Fire1") && currentCooldown > weaponCooldown && Time.timeScale > 0.1f)
            {
                onShoot?.Invoke();
                currentCooldown = 0;
                gunAnim.SetTrigger("Fire");
                GameObject mFlash = Instantiate(muzzleFlash, fireTransform);
                Destroy(mFlash, 0.3f);
                if(AudioManager.Instance)
                {
                    AudioManager.Instance.SpawnAudio(shootSFX, transform);
                }
                if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, Mathf.Infinity, layer))
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.GetComponent<Health>().ReduceHealth(bulletDamage);
                        GameObject bp = Instantiate(bloodPrefab, hit.point, Quaternion.identity);
                        bp.transform.LookAt(transform);
                        bp.transform.parent = hit.transform;
                        Destroy(bp, 1f);
                    }
                }
            }
        }

        public void IncreaseFireRate(float amt)
        {
            if (weaponCooldown - amt >= cooldownCap)
            {
                weaponCooldown -= amt;
                gunAnim.SetFloat("AnimMultiplier", shootAnim.length / weaponCooldown);
            }
        }

        public void IncreaseDamage(int amt)
        {
            bulletDamage += amt;
        }
    }
}

