using UnityEngine;

public class GwenScript : MonoBehaviour
{
    public GameObject player;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("END");
        anim.SetBool("end", true);
    }
}
