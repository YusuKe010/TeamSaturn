using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoker : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 ThisPosition;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        playerPos = player.transform.position;
        ThisPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        this.transform.position = new Vector3(0,playerPos.y + 0.5f, 0);
        //ThisPosition.y = playerPos.y;

        //// �I�u�W�F�N�g�̍��W��ϐ� pos �Ɋi�[
        //Vector3 pos = transform.position;
        //// �^�[�Q�b�g�I�u�W�F�N�g��Y���W�ɕϐ� offset �̃I�t�Z�b�g�l��������
        //// �ϐ� pos��Y���W�ɑ��
        //pos.y = playerPos.y + offset;
        //// �ϐ� pos �̒l���I�u�W�F�N�g���W�Ɋi�[
        //transform.position = pos;
    }
}
