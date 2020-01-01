using UnityEngine;

public class player : MonoBehaviour
{
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    public float speed;
    public float turn;
    [Header("撿東西")]
    public Rigidbody cat_rig;
    //public GameObject box;
    private void OnTriggerStay(Collider other)
    {
        print(other);
        
        if (other.name == "箱子" && ani.GetCurrentAnimatorStateInfo(0).IsName("a_Idle_Battle"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = cat_rig;
            //other.GetComponent<BoxCollider>().enabled = false;
            //box.SetActive(true);
        }
       // else if (other.name == "我一定要放" && ani.GetCurrentAnimatorStateInfo(0).IsName("a_Idle_Battle") && GameObject.Find("箱子").GetComponent<HingeJoint>().connectedBody == cat_rig)
       // {
            //GameObject.Find("箱子").GetComponent<HingeJoint>().connectedBody = null;
            //GameObject.Find("箱子").GetComponent<BoxCollider>().enabled = true;
        //}
    }

    private void Update()
    {
        Walk();
        Run();
        Battle();


    }
    private void Walk()
    {   if (ani.GetCurrentAnimatorStateInfo(0).IsName("a_Idle_Battle")) return;
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * v *speed*Time.deltaTime);
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, h * turn * Time.deltaTime, 0);
        ani.SetBool("走路", v != 0);
        
    }
    private void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift)&&ani.GetBool("走路"))
        {
            
            speed = 500;
            ani.SetBool("跑步", true);
            ani.SetBool("走路", false);
        }
        else
        {
            speed = 400;
            ani.SetBool("跑步", false);
            
        }
    }
    private void Battle()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("戰鬥");
        }
    }

}                                                   
