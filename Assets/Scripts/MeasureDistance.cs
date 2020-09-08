using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeasureDistance : MonoBehaviour
{
    [SerializeField]GameObject marker_1;
    [SerializeField]GameObject marker_2;
    [SerializeField] GameObject chair;
    [SerializeField] Animator character_Anim;
    [SerializeField] float speed=0.2f;
    [SerializeField] float distance;
    [SerializeField]Transform originalPosition;
    float targetY;
    Vector3 dir;
    float velocityTurn;
    bool isPicked = false;
    bool isMove=true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove==true && (marker_1.transform.position-marker_2.transform.position).sqrMagnitude<=distance)
        {
            Move(chair.transform.position);
        }
        if(isPicked==true)
        {
            
            Move(originalPosition.position);
           // isPicked = false;
        }
        if(transform.position==originalPosition.position)
        {
            
            isPicked = false;
            Debug.Log("right");
            character_Anim.SetBool("walk",false);
        }
    }
    private void Move(Vector3 headedPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, headedPosition, speed * Time.deltaTime);
        dir = (headedPosition - transform.position).normalized;
        targetY = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetY, ref velocityTurn, 0.5f);
        character_Anim.SetBool("walk", true);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chair")
        {
            isMove = false;
            Debug.Log("chair");
            chair.transform.parent = this.transform;
            isPicked = true;
        }
    }
}
