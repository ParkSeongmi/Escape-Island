using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName;
    public float range;//총 사정 거리
    public float accuracy;// 정확도
    public float fireRate;//연사속도
    public float reloadTime;
    

    public int damage;

    public int reloadBulletCount;
    public int courrentBulletCount;
    public int maxBulloetCount;
    public int carryBulletCount;

    public float retroActionForce;//반동세기
    public float retroActionFineSightForce;//정조준시 반동 세기

    public Vector3 retroActionFineSightOriginePos;
    public Animator anim;
    public ParticleSystem muzzleFlash;

    public AudioClip fire_Sound;

}
