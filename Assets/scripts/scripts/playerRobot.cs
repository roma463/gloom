using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class playerRobot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _anim;
    [SerializeField] private Text energy;
    private float EnergyPlayer;
    private bool _flipTruy;
    private bool isenergy;
    private Vector2 move;
    private energy collisionEnergy;
    public playerRobot player { get; private set; }
    private Dictionary<string, Func<GameObject, object>> TagCollision = new Dictionary<string, Func<GameObject, object>>();
    public static playerRobot ItsPlayer { private set; get; }
    public delegate void Some();
    public event Some some;
    private float thisTime;
    [SerializeField] private cinema _cinema;

    private void Awake()
    {
        ItsPlayer = this;
    }

    private void Start()
    {
        player = this;
        #region
        TagCollision.Add("energy", x =>
        {
            isenergy = true;
            return x.GetComponent<energy>();
        });
        #endregion
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            some.Invoke();
        }
        _anim.SetBool("run", move.x != 0);
       
        if (move.x > 0 && _flipTruy)
        {
            flip();
        }
        if (move.x < 0 && !_flipTruy)
        {
            flip();
        }
        if (isenergy && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(energyUp(collisionEnergy));
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isenergy = false;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
          thisTime =  _cinema.move(thisTime);
        }


    }
    private void FixedUpdate()
    {
        move = new Vector2(Input.GetAxis("Horizontal") * _speed, 0);
      
        transform.Translate(move);
    }

    private void flip()
    {
        _flipTruy = !_flipTruy;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out energy energy))
        {
            isenergy = true;
            collisionEnergy = energy;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isenergy = false;
    }
    IEnumerator energyUp(energy col)
    {
        if (EnergyPlayer < 100 && isenergy)
        {
            
            EnergyPlayer = col.toSendEnergy(EnergyPlayer);
            energy.text = EnergyPlayer.ToString();
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(energyUp(col));

        }
    }
}
