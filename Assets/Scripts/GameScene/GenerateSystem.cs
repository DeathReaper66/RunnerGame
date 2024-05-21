using UnityEngine;

public class GenerateSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _spawnCooldown = 4f;
    private float _spawnCooldownTimer = 0f;
    private float _spawnValue = 0;

    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _enemy;
    private int _enemyValue = 0;
    [SerializeField] private GameObject _coin;
    private int _coinValue = 0;
    [SerializeField] private GameObject _heart;
    private int _heartValue = 0;

    [SerializeField] private GameObject[] _boxSpawners;
    [SerializeField] private GameObject[] _enemySpawners;
    [SerializeField] private GameObject[] _coinSpawners;
    [SerializeField] private GameObject[] _heartSpawners;

    private void Start()
    {
        Spawn();
    }

    private void FixedUpdate()
    {
        if (!Score.IsPaused)
        {
            _spawnCooldownTimer += Time.fixedDeltaTime;
            if (_spawnCooldownTimer > _spawnCooldown && _spawnValue > 0f)
            {
                _spawnValue = 0f;
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        _spawnCooldownTimer = 0f;
        _spawnValue = 1f;
        _player.GetComponent<PlayerMovementWithSwipes>().SpeedScale = Mathf.Clamp(_player.GetComponent<PlayerMovementWithSwipes>().SpeedScale + 0.03f, 1, 3);
        _spawnCooldown = Mathf.Clamp(_spawnCooldown - 0.02f, 1, 4);
        SpawnEnemy();
        SpawnBox();
        SpawnHeal();
        SpawnCoin();
    }

    private void SpawnBox()
    {
        int OneOrTwo = Random.Range(1, 3);

        for (int i = 0; i < OneOrTwo; i++)
        {
            int OneOrTwoOrThree = Random.Range(0, 3);
            Instantiate(_box, _boxSpawners[OneOrTwoOrThree].transform);
        }
    }

    private void SpawnEnemy()
    {
        _enemyValue++;
        if (_enemyValue == 2)
        {
            _enemyValue = 0;
            int OneOrTwo = Random.Range(1, 3);

            for (int i = 0; i < OneOrTwo; i++)
            {
                int OneOrTwoOrThree = Random.Range(0, 3);
                Instantiate(_enemy, _enemySpawners[OneOrTwoOrThree].transform);
            }
        }
        else
        {
            int OneOrTwoOrThree = Random.Range(0, 3);
            Instantiate(_enemy, _enemySpawners[OneOrTwoOrThree].transform);
        }
    }

    private void SpawnHeal()
    {
        _heartValue++;
        if (_heartValue == 5)
        {
            _heartValue = 0;
            int OneOrTwoOrThree = Random.Range(0, 3);
            Instantiate(_heart, _heartSpawners[OneOrTwoOrThree].transform);
        }
    }

    private void SpawnCoin()
    {
        _coinValue++;
        if (_coinValue == 3)
        {
            _coinValue = 0;
            int OneOrTwoOrThree = Random.Range(0, 3);
            Instantiate(_coin, _coinSpawners[OneOrTwoOrThree].transform);
        }
    }
}
