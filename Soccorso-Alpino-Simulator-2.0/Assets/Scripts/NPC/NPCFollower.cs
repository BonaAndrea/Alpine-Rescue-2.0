using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class NPCFollower : MonoBehaviour
{
    public bool IsFollowing = false;

    [SerializeField]
    private Transform _transformToFollow;
    private NavMeshAgent _agent;
    private Animator _animator;
    private FirstPersonController _firstPersonController;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _firstPersonController = _transformToFollow.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsFollowing) return;

        ChangeSpeed();
        _agent.destination = _transformToFollow.position;
        Vector3 GoHere = _transformToFollow.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        _animator.SetBool(SRAnimators.SoccorritoreBaita.Parameters.isWalking, _agent.velocity != Vector3.zero);
        _animator.SetBool(SRAnimators.SoccorritoreBaita.Parameters.isIdle, _agent.velocity == Vector3.zero);
    }
    private void ChangeSpeed()
    {
        if (_firstPersonController.IsWalking)
        {
            _agent.speed = _firstPersonController.WalkSpeed;
            _animator.SetFloat(SRAnimators.SoccorritoreBaita.Parameters.runMultiplier, 1f);
        }
        else
        {
            _agent.speed = _firstPersonController.RunSpeed;
            _animator.SetFloat(SRAnimators.SoccorritoreBaita.Parameters.runMultiplier, 2f);
        }
    }

    public void SetIsFollowing(bool status)
    {
        IsFollowing = status;
    }

}