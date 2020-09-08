using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeasureDistance : MonoBehaviour
{
    [SerializeField]GameObject chair;
    [SerializeField]GameObject character;
    [SerializeField] Animator character_Anim;
    [SerializeField] float speed=0.2f;
    [SerializeField] float distance;
    float targetY;
    Vector3 dir;
    float velocityTurn;
    bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((character.transform.position-chair.transform.position).sqrMagnitude<=distance)
        {
            Move();
        }
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, chair.transform.position, speed * Time.deltaTime);
        dir = (chair.transform.position - transform.position).normalized;
        targetY = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetY, ref velocityTurn, 0.5f);
        character_Anim.SetBool("walk", true);
    }
}
