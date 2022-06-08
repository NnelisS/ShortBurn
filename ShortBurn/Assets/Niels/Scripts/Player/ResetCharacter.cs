using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCharacter : MonoBehaviour
{
    public Animator Elevator;
    
    public UnityEngine.CharacterController CharCont;

    public Transform Player;
    public MeshCollider Lift;
    public CapsuleCollider PlayerCol;

    public Transform Gate;
    public Transform Goto;

    private float timer = 2;
    private bool On = false;

    void Update()
    {
        if (On)
        {
            Gate.transform.position = Vector3.MoveTowards(Gate.transform.position, Goto.transform.position, 1 * Time.maximumDeltaTime);
            Physics.IgnoreCollision(Lift, PlayerCol);
            Player.SetParent(null);
            CharCont.enabled = true;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                On = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            On = true;
            Elevator.Play("Block_lift_Back");
        }
    }
}
