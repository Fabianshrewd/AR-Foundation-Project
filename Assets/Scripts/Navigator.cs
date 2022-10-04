using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    //Public variables
    public GameObject[] points;
    public float speed;
    public int c_position;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Position where it is going
        Vector3 checker = new Vector3(points[c_position].transform.position.x, transform.position.y, points[c_position].transform.position.z);

        if (transform.position == checker)
        {
            
        }
        else
        {
            //Move to the block
            MovetoBlock(points[c_position], speed);

            //Look at the direction it is going
            transform.LookAt(checker);
            Quaternion originalRot = transform.rotation;
            transform.rotation = originalRot * Quaternion.AngleAxis(-90, Vector3.up);
        }
    }

    //Move over another block
    public void MovetoBlock(GameObject target, float speed)
    {
        //Get variables
        float step = speed * Time.deltaTime;
        float current_y = transform.position.y;

        //Move to that position
        Vector3 target_pos = new Vector3(target.transform.position.x, current_y, target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target_pos, step);
    }
}
