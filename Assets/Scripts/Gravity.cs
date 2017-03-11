using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject Earth;
    public GameObject planet;

    public float gravitationalPull;

    void FixedUpdate()
    {
        //apply spherical gravity to the planet
        if (Earth.GetComponent<Rigidbody>())
        {
                if(Earth.GetComponent<Rigidbody>().velocity.z <= Controller.staticForwardSpeed)
            Earth.GetComponent<Rigidbody>().AddForce((planet.transform.position - Earth.transform.position).normalized * gravitationalPull);
            Debug.Log((planet.transform.position - Earth.transform.position).normalized * gravitationalPull);
            Debug.Log(Earth.GetComponent<Rigidbody>().velocity.z + " ** " + Controller.staticForwardSpeed);
        }
    }


        /* 2nd  public List<GameObject> affected = new List<GameObject>();

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Rigidbody>() != null && other.tag != "Projectile")
            {
                affected.Add(other.gameObject);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (affected.IndexOf(other.gameObject) != -1)
            {
                affected.Remove(other.gameObject);
            }
        }


        void FixedUpdate()
        {
            foreach (GameObject cur in affected)
            {
                float distance = Vector3.Distance(transform.position , cur.transform.position);
                cur.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(transform.position - cur.transform.position) * (1 / distance * distance) * Gravity);
                //this is basically newton's gravity law with the two masses each being one
            }
        }*/

        /*3rd public float pullRadius = 100;
        public float pullForce = 20;

        public void FixedUpdate()
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) 
            {
                // calculate direction from target to me
                Vector3 forceDirection = transform.position - collider.transform.position;

                // apply force on target towards me
                collider.attachedRigidbody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
            }
        }*/
        /*[SerializeField]
        private GameObject meteor;

        [SerializeField]
        private Camera Cam;

        [SerializeField]
        private float minSize, maxSize;

        void Spawn()
        {
            GameObject x=Instantiate(meteor, new Vector3(Cam.ScreenToWorldPoint(Input.mousePosition).x, Cam.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity) as GameObject;

            float i = Random.Range(minSize, maxSize);

            x.transform.localScale = new Vector3(i, i, i);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Spawn();
            }
        }*/
    }

