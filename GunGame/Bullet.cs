using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private GameObject _player_obj; 
    private Transform _target;
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private playerHP player_hp = null;
    [SerializeField] private int p_hp = 3;

    private void Start()
    {
        _player_obj = GameObject.Find("Player");
        _target = _player_obj.GetComponent<Transform>();    //ここでgameobjectとtransformの両方を取る

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);     //距離をつめる

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")    //プレイヤーに当たった時
        { 
            Debug.Log("Hit");
            if(player_hp == null)player_hp = collision.gameObject.GetComponent<playerHP>();
            player_hp.hp--; 
            Destroy(gameObject);
        } 

        if(collision.gameObject.tag == "Bullet"||collision.gameObject.tag == "Enemy")      //物や弾に当たった時の挙動
        {
            Destroy(gameObject);
        }

    }

   

}
