using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{

    [SerializeField] int damageDealt = 20;
    [SerializeField] GameObject bloodHit;
    AudioSource audioSrc;
    [SerializeField] AudioClip shootclip;
    public LayerMask layermask;
    Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        audioSrc=GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        layermask |= Physics.IgnoreRaycastLayer;
        layermask = ~layermask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("Fire1")) {
            print("fire");
            //Make a raycast with the line starting from center of camera.
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            anim.SetTrigger("Fire");
            audioSrc.clip = shootclip;
            audioSrc.Play();
            GetComponentInChildren<ParticleSystem>().Play();
            //Send the raycast and if the raycast hits something, print out the name to console.
            if (Physics.Raycast(mouseRay, out hitInfo,100,layermask)) {
                print("hit" + hitInfo.transform.gameObject);
                Health enemyHealth = hitInfo.transform.GetComponent<Health>();

                if (enemyHealth != null)
                {
                    enemyHealth.Damage(damageDealt);
                    Vector3 bloodHitPos = hitInfo.point;
                    Quaternion bloodHitRot = Quaternion.FromToRotation(Vector3.forward,hitInfo.normal);
                    Instantiate(bloodHit, bloodHitPos, bloodHitRot);
                }
            }
        }
    }
}
