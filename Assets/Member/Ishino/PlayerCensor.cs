using UnityEngine;

public class PlayerCensor : MonoBehaviour
{
    private GameObject player; // �v���C���[�I�u�W�F�N�g
    private Collider objectCollider; // ���̃I�u�W�F�N�g�̃R���C�_�[

    void Start()
    {
        player = GameObject.Find("PlayerPos");

        // ���̃I�u�W�F�N�g�̃R���C�_�[���擾
        objectCollider = GetComponent<Collider>();

        // �ŏ��̓R���C�_�[�𖳌���
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }

    void Update()
    {
        

        // �v���C���[��Y���W�Ƃ��̃I�u�W�F�N�g��Y���W���r
        if (player.transform.position.y > transform.position.y)
        {
            // �v���C���[����ɂ���ꍇ�A�R���C�_�[��L����
            if (objectCollider != null)
            {
                objectCollider.enabled = true;
            }
        }
        else
        {
            // �v���C���[����ɂȂ��ꍇ�A�R���C�_�[�𖳌���
            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }
        }
    }
}
