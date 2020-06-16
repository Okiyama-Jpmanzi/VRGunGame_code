using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    GameObject _navmesh_obj;
    Navmesh _navmesh;

    [SerializeField] private GameObject _prefab_enemy = null; //でで来る敵
    [SerializeField] private float _appearnexttime = 0.0f;　//次に湧いてくる時間
    [SerializeField] private int _maxnumofenemys = 0;   //最大数
    private int _numberofenemys;    //今の敵の総数
    private float _elapsedtime;    //出現時間

    private void Start()
    {
        _navmesh_obj = GameObject.Find("Spawner");
        _navmesh = gameObject.GetComponent<Navmesh>();
        _numberofenemys = 0;    
        _elapsedtime = 0.0f;

    }

    private void Update()
    {

        if(_numberofenemys >= _maxnumofenemys ) {   //最大数を超えたら敵を出さない
            return;
        }
        _elapsedtime += Time.deltaTime; 
        if(_elapsedtime > _appearnexttime)  //出現時間を超えたら
        {
            _elapsedtime = 0.0f;    //時間をリセット
            GameObject.Instantiate(_prefab_enemy, transform.position, transform.rotation); //敵出現
        }
    }

    public void OnHitBullet()     //ここで総数を減らす
    {
        _numberofenemys--;
        Debug.Log("転送");
    }   
}

