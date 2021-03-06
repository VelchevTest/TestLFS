using System.Collections;
using UnityEngine;


    public class ThirdPersonUserControl : MonoBehaviour{
        private float m_MovingTurnSpeed = 360;
		private float m_StationaryTurnSpeed = 180;

		private Rigidbody m_Rigidbody;
		private Animator m_Animator;
		private bool m_IsGrounded = true;
		private const float k_Half = 0.5f;
		private float m_TurnAmount;
		private float m_ForwardAmount;
		private CapsuleCollider m_Capsule;

    
        public float Vertical;
        private Transform m_Cam;                  
        private Vector3 m_CamForward;          
        private Vector3 m_Move;
        private float Horizontal , stopDistance = 1 ,rotationSeed ,maxSteerValue = 1 , distance;
        public waypoint currentWaypoint;
        private bool reachedDestination;
        private Vector3 velocity ,Destination, lastPosition;

        public int headingDirection = 0 ;
        
        private void Start(){
            m_Cam = gameObject.transform;
            setDestination(currentWaypoint.getPosition());
            Vertical = Random.Range(0.2f, .45f);
            headingDirection = Random.Range(0,2);

            m_Animator = GetComponent<Animator>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            
        }

        private void FixedUpdate()
        {
            
            if(reachedDestination){
                if(currentWaypoint.nextWaypoint == null ){
                    headingDirection = headingDirection == 0 ? 1 : 0;
                    currentWaypoint = currentWaypoint.previousWaypont;
                    setDestination(currentWaypoint.getPosition());
                    return;
                }
                if(currentWaypoint.previousWaypont == null ){
                    headingDirection = headingDirection == 0 ? 1 : 0;
                    currentWaypoint = currentWaypoint.nextWaypoint;
                    setDestination(currentWaypoint.getPosition());
                    return;
                }
                currentWaypoint = headingDirection == 0 ?  currentWaypoint.nextWaypoint :  currentWaypoint.previousWaypont;
                
                setDestination(currentWaypoint.getPosition());
            }
            operateAi();




            float h = Horizontal ;
            float v = Vertical;

            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v*m_CamForward + h*m_Cam.right;

            Move(m_Move, false, false);



        }
    
        public void setDestination(Vector3 destinationUknown){
            this.Destination = destinationUknown;
            reachedDestination = false;
        }
    
        private void operateAi(){
            if(transform.position != Destination){
                Vector3 destinationDirection = Destination - transform.position;
                Destination.y = 0;
                distance = destinationDirection.magnitude;
                if(Vector3.Distance(transform.position , currentWaypoint.transform.position) <= stopDistance){
                    reachedDestination = true;
                }
                else{
                    reachedDestination = false;
                }

                Vector3 relativeVector = transform.InverseTransformPoint(currentWaypoint.transform.position);
                relativeVector /= relativeVector.magnitude;
                float newSteer = (relativeVector.x  / relativeVector.magnitude) * maxSteerValue;

                Horizontal = newSteer;
            }
        }

		public void Move(Vector3 move, bool crouch, bool jump){

			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			m_TurnAmount = Mathf.Atan2(move.x, move.z);
			m_ForwardAmount = move.z;

			ApplyExtraTurnRotation();

			UpdateAnimator(move);
		}

		void UpdateAnimator(Vector3 move)
		{
			// update the animator parameters
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
			m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
			m_Animator.SetBool("OnGround", m_IsGrounded);
			if (!m_IsGrounded)
			{
				m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
			}


		}

		void ApplyExtraTurnRotation(){
			float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
		}

    }

