using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    GameObject _enemyspwner_obj;
    EnemySpawner _enemyspawner;
    GameObject _flash_obj;
    Flash _flash;

    private Transform _target;
    private GameObject _target_obj; // gameobjectとtransformの両方をとる
    private Transform _target1;
    private GameObject _target1_obj;　// gameobjectとtransformの両方をとる
    private Transform _target2;
    private GameObject _target2_obj;　// gameobjectとtransformの両方をとる
    private Transform _mark;
    private GameObject _mark_obj;　// gameobjectとtransformの両方をとる

    private int unko = 0;　 //ここの数字で通過する場所を決める
    private NavMeshAgent _navmesh;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _damage = null;


    private void Awake()
    {
        _navmesh = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        _flash = gameObject.GetComponent<Flash>();
    }

    private void Start()
    {
        _enemyspawner = gameObject.GetComponent<EnemySpawner>();    //スクリプト呼び出し
        _enemyspwner_obj = GameObject.Find("Script_obj");
        _flash_obj = GameObject.Find("Script_obj");

        unko = Random.Range(0, 3);　// 0~2がランダムででる
        switch(unko)    
        {
            case 0:
                _target_obj = GameObject.Find("Mark1");
                _target = _target_obj.GetComponent<Transform>();    //ここでgemeobjectとtransformを追加
                break;
            case 1:
                _target_obj = GameObject.Find("Mark2");
                _target1 = _target_obj.GetComponent<Transform>();   //ここでgemeobjectとtransformを追加
                break;
            case 2:
                _target_obj = GameObject.Find("Mark3");
                _target2 = _target_obj.GetComponent<Transform>();   //ここでgemeobjectとtransformを追加
                break;
        }
        _mark_obj = GameObject.Find("Player");
        _mark = _mark_obj.GetComponent<Transform>();    //ここでgemeobjectとtransformを追加
    }

    private void Update()
    {
       // if (_navmesh.pathStatus != NavMeshPathStatus.PathInvalid)
        
            switch (unko)
            {
                case 0:

                    _navmesh.SetDestination(_target.position);
                    break;  //ここで場所を決める

                case 1:
                    _navmesh.SetDestination(_target1.position);
                    break;  //ここで場所を決める

                case 2:
                    _navmesh.SetDestination(_target2.position);
                    break;  //ここで場所を決める

                case 3:
                    _navmesh.destination = _mark.position;
                    break;  //プレイヤーの位置
            }
        
    }

    private void OnTriggerEnter(Collider other) //targetについたときの挙動
    {
        if (other.gameObject.tag == "Goal")
        {
            unko = 3;　//次にプレイヤーの場所に行く
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")    //プレイヤーに当たった時の挙動
        {
            Destroy(gameObject);
        //    _audioSource.PlayOneShot(_damage);

        }
        if(collision.gameObject.tag == "Bullet")
        {
           // _enemyspawner.OnHitBullet(); //総数を減らす
            Destroy(gameObject);
        }
    }
}
