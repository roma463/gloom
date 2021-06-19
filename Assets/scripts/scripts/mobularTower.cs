using System.Collections;
using UnityEngine;

public class mobularTower : MonoBehaviour
{
    private playerRobot _player;
    [SerializeField] private CinemaState _cinema;
    [SerializeField] private modul[] _moduls;
    [SerializeField] private bool _tryPlayer;

    private void Start()
    {
        _player = playerRobot.ItsPlayer;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && _tryPlayer)
        {
            StartCoroutine(nameof(m));
            _cinema.CinemaNewState(CinemaState.State.localModul);
        }
    }
    private IEnumerator m()
    {
        int x = 0;
        while (x < 100)
        {
            x++;
            print("0");
            yield break;
            print("1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collsiion");

            _tryPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

            _tryPlayer = false;
    }
}
