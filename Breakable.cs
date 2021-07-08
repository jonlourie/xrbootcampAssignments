using System;
using UnityEngine;
using UniRx;
namespace _VIRAL._03_Scripts
{
    


    public class Breakable : MonoBehaviour
    {
        [SerializeField] private GameObject breakableModel;
        [SerializeField] private GameObject cupModel;
        [SerializeField] private GameObject grabZone;
        [SerializeField] private GameObject collider;
        [SerializeField] private Holdable cup;
        [SerializeField] private Vector3 initialPoint;
        [SerializeField] private Vector3 breakVelcoity;
        [SerializeField] private float maxForce;
        private Collision col;
        
        Vector3 x;



        private KinematicsEstimator velocityEstimation;
        private Rigidbody cupRigidbody;

        // Start is called before the first frame update
        void Start()
        {
            cupRigidbody = GetComponent<Rigidbody>();
            x = transform.position;

            velocityEstimation = GetComponent<KinematicsEstimator>();

            Vector3 velocity = velocityEstimation.GetEstimatedVelocity();

            

        }

        // Update is called once per frame
        void Update()
        {
            //BreakCup();

            Vector3 velocity = velocityEstimation.GetEstimatedVelocity();
            Debug.Log(velocity);

            

        }

        private void BreakCup()
        {

            //if(cupRigidbody.velocity == breakVelcoity)
            //{
            //   cupModel.SetActive(false);
            //  grabZone.SetActive(false);
            //    collider.SetActive(false);
            //   cupRigidbody.isKinematic = true;
            //   breakableModel.SetActive(true);
            //}
             
            
                     
          
            

           
         }

        private void OnCollisionEnter(Collision col)
        {
            if (col.impactForceSum.y > maxForce)
            {


                
                cupModel.SetActive(false);
                grabZone.SetActive(false);
                collider.SetActive(false);
                cupRigidbody.useGravity = false;
                cupRigidbody.isKinematic = true;

                breakableModel.SetActive(true);
                //disconnect joint
            }

        }


    }
}