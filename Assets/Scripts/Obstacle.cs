using UnityEngine;
public class Obstacle : MonoBehaviour
{
    public Player_Controller controller;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            controller.enabled = false;
        }
    }

}