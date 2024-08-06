using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// フェードイン、フェードしつつシーン遷移を行う。
/// このスクリプトがアタッチされたオブジェクトの子にCanvas、孫にImageがある前提。
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // シングルトン
    static SceneLoader Instance;

    [Header("フェードの速さ")]
    [SerializeField] float _fadeSpeed = 2.0f;

    // シーン遷移の処理を重複して実行中しないよう、フラグで制御する。
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
    /// フェードイン。
    /// </summary>
    /// <param name="callback">フェードイン後に呼ぶコールバック</param>
    public static void FadeIn(UnityAction callback = null)
    {
        if (Instance != null) Instance.StartCoroutine(FadeInAsync(callback));
        else Debug.LogWarning($"{nameof(SceneLoader)}のインスタンスがシーン上に存在しないのでフェードイン不可能");
    }

    // 非同期処理でフェードインを実行し、完了後にコールバックを呼ぶ。
    // 既にフェードやシーン遷移が実行されている場合は弾く。
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
    /// シーン遷移。
    /// </summary>
    /// <param name="sceneName">遷移先のシーン名</param>
    /// <param name="callback">遷移後、フェードインが完了したタイミングで呼ぶコールバック</param>
    public static void ChangeScene(string sceneName, UnityAction callback = null)
    {
        if (Instance != null) Instance.StartCoroutine(ChangeSceneAsync(sceneName, callback));
        else Debug.LogWarning($"{nameof(SceneLoader)}のインスタンスがシーン上に存在しないのでシーン遷移不可能");
    }

    // 非同期処理で フェードアウト -> シーン遷移 -> フェードイン を実行し、完了後にコールバックを呼ぶ。
    // 既にフェードやシーン遷移が実行されている場合は弾く。
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

    // フェードイン。
    private static IEnumerator FadeInAsync(Image fadeImage, float speed)
    {
        yield return FadeAsync(fadeImage, 1, 0, speed);
        fadeImage.enabled = false;
    }

    // フェードアウト。
    private static IEnumerator FadeOutAsync(Image fadeImage, float speed)
    {
        fadeImage.enabled = true;
        yield return FadeAsync(fadeImage, 0, 1, speed);
    }

    // α値を弄ってフェード演出する。
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