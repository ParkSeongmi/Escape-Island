using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    private Gun currentGun;

    private float currentFireRate;

    private AudioSource audioSource;

    //레이저 충돌 정보 받아옴
    private RaycastHit hitInfo;

    //카메라 정보(필요한 컴포넌트)
    [SerializeField]
    private Camera theCam;
    private Crosshair theCrosshair;

    //피격 이펙트
    [SerializeField]
    private GameObject hit_effect_prefab;

    public GameObject bullet;
    public float bulletspeed = 10.0f;

    //private Rigidbody rigidbody;

    void Start()
    {
        //효과음
       audioSource = GetComponent<AudioSource>();
       theCrosshair = FindObjectOfType<Crosshair>();

       //WeaponManager.currentWeapon = currentGun.GetComponent<Transform>();
       //WeaponManager.currentWeaponAnim = currentGun.anim;
    }

    // Update is called once per frame
    void Update()
    {
        GunFireRateCalc();
        GunFireRateCalc();
        TryFire();

        if(Input.GetKeyDown(0))
        {
        GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation) as GameObject;
        Rigidbody rbBullet = newBullet.GetComponent<Rigidbody>();
        rbBullet.velocity = transform.forward * bulletspeed;
        
        }
    }

    private void GunFireRateCalc()
    {
        if(currentFireRate > 0)
           currentFireRate -= Time.deltaTime;
    }
    
    private void TryFire()
    {
        if(Input.GetButton("Fire1") && currentFireRate <= 0)
        {
           Fire();
        }
    }

    private void Fire()
    {
        Shoot();
    }

    private void Shoot()
    {
        theCrosshair.FireAnimation();
        currentFireRate = currentGun.fireRate;
        PlaySE(currentGun.fire_Sound);
        currentGun.muzzleFlash.Play();
        Hit();
    }

    private void Hit()
    {
        if(Physics.Raycast(theCam.transform.position, theCam.transform.forward + 
        new Vector3(Random.Range(-theCrosshair.GetAccuracy() - currentGun.accuracy, theCrosshair.GetAccuracy() + currentGun.accuracy),
                    Random.Range(-theCrosshair.GetAccuracy() - currentGun.accuracy, theCrosshair.GetAccuracy() + currentGun.accuracy),
                    0), out hitInfo, currentGun.range))
    
        
        
        {
            GameObject clone = Instantiate(hit_effect_prefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(clone, 2f);
        }
    }
    
    


    //사운드 재생
    private void PlaySE(AudioClip _clip) 
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }

 

}
