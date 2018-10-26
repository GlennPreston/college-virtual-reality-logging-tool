using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

        public GameObject mCamera;
        public Collider playerCollider;
        private Collider coll;
        private bool pickedUp;
        private Vector3 distance = new Vector3(0.5f, 0.5f, 0.5f);

        public void Start()
        {
            coll = GetComponent<Collider>();
            pickedUp = false;
        }

        public void FixedUpdate()
        {
            if (pickedUp)
            {
                Move();
            }
        }

        public void Move()
        {
            transform.position = Camera.main.ViewportToWorldPoint(distance);
        }

        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            if (pickedUp)
            {
                coll.attachedRigidbody.useGravity = true;
                coll.attachedRigidbody.freezeRotation = false;
                Physics.IgnoreCollision(coll, playerCollider, false);
                pickedUp = false;
            } else
            {
                coll.attachedRigidbody.useGravity = false;
                coll.attachedRigidbody.freezeRotation = true;
                Physics.IgnoreCollision(coll, playerCollider, true);
                pickedUp = true;
            }
            Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}