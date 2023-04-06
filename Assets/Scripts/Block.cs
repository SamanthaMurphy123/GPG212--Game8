using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor
{
    Green,
    Red
}
public class Block : MonoBehaviour
{
    public BlockColor color;
    public GameObject brokenBlockLeft;
    public GameObject brokenBlockRight;

    public float brokenBlockForce;
    public float brokenBlockTorque;
    public float brokenBlockDestroyDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordRed"))
        {
            if(color == BlockColor.Red)
            {
                GameManager.instance.AddScore();
            }
            else
            {
                GameManager.instance.HitWrongBlock();
            }

            Hit();
        }
        else if(other.CompareTag("SwordGreen"))
        {
            if (color == BlockColor.Green)
            {
                GameManager.instance.AddScore();
            }
            else
            {
                GameManager.instance.HitWrongBlock();
            }
            Hit();
        }
    }

    void Hit()
    {
        //enable broken pieces
        brokenBlockLeft.SetActive (true);
        brokenBlockRight.SetActive(true);

        //remove them as children
        brokenBlockLeft.transform.parent = null;
        brokenBlockRight.transform.parent = null;

        //Add force to them
        Rigidbody leftRig = brokenBlockLeft.GetComponent<Rigidbody>();
        Rigidbody rightRig = brokenBlockRight.GetComponent<Rigidbody>();

        leftRig.AddForce(-transform.right * brokenBlockForce, ForceMode.Impulse);
        rightRig.AddForce(transform.right * brokenBlockForce, ForceMode.Impulse);

        //Add torque to them
        leftRig.AddTorque(-transform.forward * brokenBlockTorque, ForceMode.Impulse);
        rightRig.AddTorque(transform.forward * brokenBlockTorque, ForceMode.Impulse);

        //Destroy mmain block
        Destroy(gameObject);

        //Destroy pieces after few secs
        Destroy(brokenBlockLeft, brokenBlockDestroyDelay);
        Destroy(brokenBlockRight, brokenBlockDestroyDelay);

    }
}
