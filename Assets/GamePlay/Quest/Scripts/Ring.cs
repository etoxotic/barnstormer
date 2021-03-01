using UnityEngine;
using UnityEngine.Events;

namespace Quest
{
    public class Ring : MonoBehaviour
    {

        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material unactiveMaterial;
        [SerializeField] private bool isStart;

        public GameObject nextRing;
        public GameObject previousRing;
        public bool isActive;
        public int id;

        public UnityEvent EnterEvent;

        public void ResetRotation()
        {
            if(previousRing)
                transform.LookAt(previousRing.transform);
            if (nextRing)
                nextRing.GetComponent<Ring>().ResetRotation();
        }

        public void Activate()
        {
            GetComponentInChildren<MeshRenderer>().material = activeMaterial;
            isActive = true;
            if (nextRing)
                nextRing.SetActive(true);
        }
        public void CreateNextRing()
        {
            nextRing = Instantiate(gameObject, transform.TransformPoint(transform.forward * 10), transform.rotation, transform.parent);
            nextRing.name = "Ring " + (id + 1);
            nextRing.GetComponent<Ring>().id = id + 1;
            nextRing.GetComponent<Ring>().previousRing = gameObject;
        }
        private void Start()
        {
            if (isStart)
                Activate();
            else
                gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isActive)
            {
                if (nextRing)
                    nextRing.GetComponent<Ring>().Activate();

                // Particles

                EnterEvent.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}