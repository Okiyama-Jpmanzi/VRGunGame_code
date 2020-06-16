using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fly_enemy : MonoBehaviour
{
    [SerializeField] private GameObject _attack = null;
    [SerializeField] private Transform _trans = null;

    private float _time = 0f;
    private int _ycheak;
    private int _xcheak;
    private Vector3 _ypos = new Vector3(0f, 0.01f, 0f);
    private Vector3 _xpos = new Vector3(0.01f, 0f, 0f);
    private GameObject Enemy;

    private void Start()
    {
        enabled = true;
        Enemy = this.gameObject;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        switch (_xcheak)
        {
            case 0:
                this.gameObject.transform.localPosition += _xpos;
                break;

            case 1:
                this.gameObject.transform.localPosition -= _xpos;
                break;
        }

        if (gameObject.transform.localPosition.x <= -17.0f)
        {
            _xcheak = 0;
        }

        if (gameObject.transform.localPosition.x >= -10.0f)
        {
            _xcheak = 1;
        }
        switch (_ycheak)
        {
            case 0:
                this.gameObject.transform.localPosition += _ypos;
                break;

            case 1:
                this.gameObject.transform.localPosition -= _ypos;
                break;
        }

        if (gameObject.transform.localPosition.y <= 8.0f)
        {
            _ycheak = 0;
        }

        if (gameObject.transform.localPosition.y >= 10.0f)
        {
            _ycheak = 1;
        }
        
        if (_time >= 5.0f)
        {
            Attack();
        }
    }

   private void Attack()
    {
        enabled = false;
        _time = 0f;
        Instantiate(_attack,_trans.position,_trans.rotation);
        enabled = true;
   } 
}

