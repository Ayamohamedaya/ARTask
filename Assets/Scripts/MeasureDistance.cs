using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeasureDistance : MonoBehaviour
{
    [SerializeField]Transform marker_1;
    [SerializeField]Transform marker_2;
    [SerializeField] Transform chair;
    [SerializeField] Animator character_Anim;
    [SerializeField] float speed=2f;
    [SerializeField] float distance=350;
    [SerializeField]Transform originalPosition;
    float targetY;
    Vector3 dir;
    float velocityTurn;
    bool isPicked = false;
    bool isMove=true;
    // Start is called before the first frame update
    void Start()
    {
        marker_1 = GameObject.Find("CharacterMarker").transform;
        marker_2 = GameObject.Find("ObjectMarker").transform;
        chair = GameObject.FindGameObjectWithTag("Chair").transform;
        originalPosition = GameObject.FindGameObjectWithTag("OriginalPosition").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove==true && (marker_1.transform.position-marker_2.transform.position).sqrMagnitude<=distance)
        {
            Move(chair.position);
        }
        else if ((marker_1.transform.position - marker_2.transform.position).sqrMagnitude > distance && transform.position != originalPosition.position)
        {

            Move(originalPosition.position);
        }
        if (isPicked==true)
        {
            
            Move(originalPosition.position);
        }        
        if(transform.position==originalPosition.position)

        {
            isPicked = false;
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
            chair.parent = this.transform;
            isPicked = true;
        }
    }
}
