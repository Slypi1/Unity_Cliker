using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Object _spritePrefab;
    [SerializeField] private float _radiusCirle;

    [SerializeField] private float _timerSpawn;
    [SerializeField] public int _count;

    private int _numberInTheGame;

    private void Start()
    {
        StartCoroutine("SpawnObjectAtRandom");
    }
    void OnEnable()
    {
        Drag¿ndDrop.Spawn += CountGameObject;
    }

    void OnDisable()
    {
        Drag¿ndDrop.Spawn -= CountGameObject;
    }

    private void RepeatSpawn(int a)
    {
        if (_numberInTheGame <= _count)
             StartCoroutine("SpawnObjectAtRandom");
            ///_numberInTheGame++;
    }

    private IEnumerator SpawnObjectAtRandom()
    {               
            yield return new WaitForSeconds(_timerSpawn);
            Vector3 randoms = Random.insideUnitCircle * _radiusCirle;
            Instantiate(_spritePrefab, randoms, Quaternion.identity);           
            _numberInTheGame++;
             RepeatSpawn(_numberInTheGame);           
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusCirle);
    } 
    
    private void CountGameObject(bool drop)
    {      
        if (drop)
        {
           _numberInTheGame -= 2;
           RepeatSpawn(_numberInTheGame);
        }
    }
}
