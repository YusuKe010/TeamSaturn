using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �t�F�[�h�C���A�t�F�[�h���V�[���J�ڂ��s���B
/// ���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�̎q��Canvas�A����Image������O��B
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // �V���O���g��
    static SceneLoader Instance;

    [Header("�t�F�[�h�̑���")]
    [SerializeField] float _fadeSpeed = 2.0f;

    // �V�[���J�ڂ̏������d�����Ď��s�����Ȃ��悤�A�t���O�Ő��䂷��B
    bool _isRunning;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (Instance != null) Instance = null;
    }

    /// <summary>
    /// �t�F�[�h�C���B
    /// </summary>
    /// <param name="callback">�t�F�[�h�C����ɌĂԃR�[���o�b�N</param>
    public static void FadeIn(UnityAction callback = null)
    {
        if (Instance != null) Instance.StartCoroutine(FadeInAsync(callback));
        else Debug.LogWarning($"{nameof(SceneLoader)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂Ńt�F�[�h�C���s�\");
    }

    // �񓯊������Ńt�F�[�h�C�������s���A������ɃR�[���o�b�N���ĂԁB
    // ���Ƀt�F�[�h��V�[���J�ڂ����s����Ă���ꍇ�͒e���B
    private static IEnumerator FadeInAsync(UnityAction callback)
    {
        if (Instance._isRunning) yield break;
        else Instance._isRunning = true;

        Image fadeImage = Instance.GetComponentInChildren<Image>();
        float speed = Instance._fadeSpeed;
        yield return FadeInAsync(fadeImage, speed);

        callback?.Invoke();

        Instance._isRunning = false;
    }

    /// <summary>
    /// �V�[���J�ځB
    /// </summary>
    /// <param name="sceneName">�J�ڐ�̃V�[����</param>
    /// <param name="callback">�J�ڌ�A�t�F�[�h�C�������������^�C�~���O�ŌĂԃR�[���o�b�N</param>
    public static void ChangeScene(string sceneName, UnityAction callback = null)
    {
        if (Instance != null) Instance.StartCoroutine(ChangeSceneAsync(sceneName, callback));
        else Debug.LogWarning($"{nameof(SceneLoader)}�̃C���X�^���X���V�[����ɑ��݂��Ȃ��̂ŃV�[���J�ڕs�\");
    }

    // �񓯊������� �t�F�[�h�A�E�g -> �V�[���J�� -> �t�F�[�h�C�� �����s���A������ɃR�[���o�b�N���ĂԁB
    // ���Ƀt�F�[�h��V�[���J�ڂ����s����Ă���ꍇ�͒e���B
    private static IEnumerator ChangeSceneAsync(string sceneName, UnityAction callback)
    {
        if (Instance._isRunning) yield break;
        else Instance._isRunning = true;

        Image fadeImage = Instance.GetComponentInChildren<Image>();
        float speed = Instance._fadeSpeed;
        yield return FadeOutAsync(fadeImage, speed);
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return FadeInAsync(fadeImage, speed);

        callback?.Invoke();

        Instance._isRunning = false;
    }

    // �t�F�[�h�C���B
    private static IEnumerator FadeInAsync(Image fadeImage, float speed)
    {
        yield return FadeAsync(fadeImage, 1, 0, speed);
        fadeImage.enabled = false;
    }

    // �t�F�[�h�A�E�g�B
    private static IEnumerator FadeOutAsync(Image fadeImage, float speed)
    {
        fadeImage.enabled = true;
        yield return FadeAsync(fadeImage, 0, 1, speed);
    }

    // ���l��M���ăt�F�[�h���o����B
    private static IEnumerator FadeAsync(Image fadeImage, float begin, float end, float speed)
    {
        Color c = fadeImage.color;
        for (float t = 0; t <= 1; t += Time.deltaTime * speed)
        {
            c.a = Mathf.Lerp(begin, end, t);
            fadeImage.color = c;

            yield return null;
        }

        c.a = end;
        fadeImage.color = c;
    }
}