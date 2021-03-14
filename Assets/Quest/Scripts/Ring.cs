using UnityEngine;
using UnityEngine.Events;

namespace Quest
{
    // Этот скрипт висит на кольце и служит для отправки сообщений Quest-у
    public class Ring : MonoBehaviour
    {

        public UnityEvent OnEnter;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material finishMaterial;

        private void OnTriggerEnter(Collider other)
        {
            // При входе самолетика в кольцо вызывается событи OnEnter
            OnEnter.Invoke();
        }
        public void Activate(bool isFinish)
        {
            // Выбираем активный цвет кольца
            if (isFinish)
            {
                GetComponent<MeshRenderer>().material = finishMaterial;
            }
            else
            {
                GetComponent<MeshRenderer>().material = activeMaterial;
            }
        }
    }
}