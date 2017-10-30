using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMScript : MonoBehaviour {

	static BGMScript _instance = null;

	static BGMScript instance
    {
        get{ return _instance ?? (_instance = FindObjectOfType<BGMScript>()); }
    }

	public AudioClip keep; //タイトル曲
	public AudioClip polp; //戦闘曲
	public AudioClip madoka; //リザルト曲
	private AudioSource audioSource;

	void Awake()
    {

        // ※オブジェクトが重複していたらここで破棄される

        // 自身がインスタンスでなければ自滅
        if (this != instance)
        {
            Destroy(this.gameObject);
            return;
        }

        // 以降破棄しない
        DontDestroyOnLoad(gameObject);

    }

	// Use this for initialization
	void Start () {

		audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = keep;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "StartStage" && audioSource.clip != keep){
			audioSource.clip = keep;
			audioSource.Play();
		}
		else if(SceneManager.GetActiveScene().name == "SelectEquipment" && audioSource.clip != keep){
			audioSource.clip = keep;
			audioSource.Play();
		}
		else if(SceneManager.GetActiveScene().name == "EndlessStage" && audioSource.clip != polp)
		{
			audioSource.clip = polp;
			audioSource.Play();
		}
		else if(SceneManager.GetActiveScene().name == "Result" && audioSource.clip != madoka)
		{
			audioSource.clip = madoka;
			audioSource.Play();
		}
	}

	void OnDestroy()
    {

        // ※破棄時に、登録した実体の解除を行なっている

        // 自身がインスタンスなら登録を解除
        if (this == instance) _instance = null;

    }
}
