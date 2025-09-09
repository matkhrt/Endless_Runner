using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] _levelPart;
    [SerializeField]
    private Vector3 _nextPartPosition;
    [SerializeField]
    private float _distanceToSpawn;
    [SerializeField]
    private float _distanceToDelete;
    [SerializeField]
    private Transform _player;

    void Start()
    {

    }

    void Update()
    {
        GeneratePlatform();
        DeletePlatform();
    }

    private void GeneratePlatform()
    {
        while (Vector2.Distance(_player.transform.position, _nextPartPosition) < _distanceToSpawn)
        {
            Transform part = _levelPart[Random.Range(0, _levelPart.Length)];

            //Transform newPart = Instantiate(part, _nextPartPosition - part.Find("StartPoint").position, transform.rotation, transform);

            Vector2 newPosition = new Vector2(_nextPartPosition.x - part.Find("StartPoint").position.x, 0);

            Transform newPart = Instantiate(part, newPosition, transform.rotation, transform);

            _nextPartPosition = newPart.Find("EndPoint").position;

        }
    }

    private void DeletePlatform() 
    {
        if (transform.childCount > 0)
        {
            Transform partToDelete = transform.GetChild(0);

            if(Vector2.Distance(_player.transform.position,partToDelete.transform.position) > _distanceToDelete) 
            {
                Destroy(partToDelete.gameObject);
            }

        }
    }
}
