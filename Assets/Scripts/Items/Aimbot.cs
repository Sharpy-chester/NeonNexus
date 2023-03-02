using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aimbot", menuName = "Items/Aimbot", order = 10)]
public class Aimbot : Item
{
    PlayerShoot shoot;
    GameObject player;
    PlayerLook playerLook;
    Camera cam;
    [SerializeField] float lockOnAngle; //in radians
    Enemy[] enemies;

    void LockOn()
    {
        
        enemies = FindObjectsOfType<Enemy>();
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        foreach (Enemy e in enemies)
        {
            Vector3 toEnemy = e.transform.position - cam.transform.position;
            float angle = Vector3.Angle(cam.transform.forward, toEnemy);
            if (angle <= lockOnAngle && toEnemy.magnitude < closestDistance)
            {
                closestEnemy = e;
                closestDistance = toEnemy.magnitude;
            }
        }
        
        if (closestEnemy != null)
        {
            
            cam.transform.LookAt(closestEnemy.head);
            float adjust = 0;
            if (cam.transform.eulerAngles.x > 90)
            {
                adjust = -360;
            }
            else if (cam.transform.eulerAngles.x < -90)
            {
                adjust = 360;
            }
            Debug.Log(cam.transform.eulerAngles.x + adjust + " : " + (cam.transform.eulerAngles.x > 90));
            playerLook.UpdateRot(cam.transform.eulerAngles.x + adjust, cam.transform.eulerAngles.y);
        }
    }

    public override void OnUpdate()
    {
    }

    public override void OnAdd(GameObject playerGO)
    {
        shoot = playerGO.GetComponent<PlayerShoot>();
        shoot.onShoot += LockOn;
        cam = Camera.main;
        player = playerGO;
        playerLook = player.GetComponent<PlayerLook>();
    }

    public override void OnCollision(Collision collision)
    {
    }
}
