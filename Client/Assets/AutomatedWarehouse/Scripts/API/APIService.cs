using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace AutomatedWarehouse.API
{
    public class APIService : MonoBehaviour
    {
        [Header("Настройки")]
        [SerializeField] private string _requestUri;

        private void Start()
        {
            StartCoroutine(GetLayout());
        }

        private IEnumerator GetLayout()
        {
            UnityWebRequest request = UnityWebRequest.Get(_requestUri);
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Ошибка при подключении.");
            }
            else
            {
                string data = request.downloadHandler.text;
                Debug.Log(data);
            }
        }
    }
}