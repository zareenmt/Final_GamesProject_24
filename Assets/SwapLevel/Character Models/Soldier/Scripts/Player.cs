using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;
	public Transform playerTrans;
	
	
	void FixedUpdate(){
		if(Input.GetKey(KeyCode.W)){
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)){
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.W)){
			playerAnim.SetTrigger("JogForward");
			playerAnim.ResetTrigger("IdleSoldier");
			walking = true;
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.W)){
			playerAnim.ResetTrigger("JogForward");
			playerAnim.SetTrigger("IdleSoldier");
			walking = false;
			//steps1.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.S)){
			playerAnim.SetTrigger("Jog Backward");
			playerAnim.ResetTrigger("IdleSoldier");
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			playerAnim.ResetTrigger("Jog Backward");
			playerAnim.SetTrigger("IdleSoldier");
			//steps1.SetActive(false);
		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
	
	}
}



