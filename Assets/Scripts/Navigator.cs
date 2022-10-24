using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    //Public variables
    public GameObject[] points;
    public float speed;
    public int c_position;
    public bool should_move;

    // Start is called before the first frame update
    void Start()
    {
        should_move = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Set next position
        if(should_move == true)
        {
            should_move = false;
            c_position++;

            if(c_position > 6)
            {
                c_position = 0;
            }

            transform.LookAt(points[c_position].transform);
            Quaternion originalRot = transform.rotation;
            transform.rotation = originalRot * Quaternion.AngleAxis(-90, Vector3.up);
        }

        //Position where it is going
        Vector3 checker = new Vector3(points[c_position].transform.position.x, points[c_position].transform.position.y, points[c_position].transform.position.z);

        if (transform.position == checker)
        {
            should_move = true;
        }
        else
        {
            //Move to the block
            MovetoBlock(points[c_position], speed);
        }
    }

    //Move over another block
    public void MovetoBlock(GameObject target, float speed)
    {
        //Get variables
        float step = speed * Time.deltaTime;

        //Move to that position
        Vector3 target_pos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target_pos, step);
    }
}
