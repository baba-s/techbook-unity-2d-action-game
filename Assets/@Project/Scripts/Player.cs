using UnityEngine;
using UnityEngine.SceneManagement;

// プレイヤーを制御するスクリプト
public class Player : MonoBehaviour
{
	// プレイヤーのやられアニメーションのプレハブ
	public GameObject m_playerHitPrefab;

	// ジャンプした時に再生する SE
	public AudioClip m_jumpClip;

	// やられた時に再生する SE
	public AudioClip m_hitClip;

	// ジャンプした時のSEをスキップするかどうか
	public bool IsSkipJumpSe;

	// プレイヤーがやられた時に呼び出す関数
	public void Dead()
	{
		// プレイヤーを非表示にする
		// Destroy 関数でプレイヤーを削除してしまうと
		// OnRetry 関数が呼び出されなくなるため
		// SetActive 関数で非表示にする
		gameObject.SetActive( false );

		// シーンに存在する CameraShaker スクリプトを検索する
		var cameraShake = FindObjectOfType<CameraShaker>();

		// CameraShaker を使用してカメラを揺らす
		cameraShake.Shake();

		// 2 秒後にリトライする
		Invoke( "OnRetry", 2 );

		// プレイヤーのやられアニメーションのオブジェクトを生成する
		Instantiate
		(
			m_playerHitPrefab,
			transform.position,
			Quaternion.identity
		);

		// やられた時の SE を再生する
		var audioSource = FindObjectOfType<AudioSource>();
		audioSource.PlayOneShot( m_hitClip );
	}

	// リトライする時に呼び出される関数
	private void OnRetry()
	{
		// 現在のシーンを読み込み直してリトライする
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}

	// シーンが開始する時に呼び出される関数
	private void Awake()
	{
		// プレイヤーの移動を制御するコンポーネントを取得する
		var motor = GetComponent<PlatformerMotor2D>();

		// ジャンプした時に呼び出されるイベントに関数を登録する
		motor.onJump += OnJump;
	}

	// ジャンプした時に呼び出される関数
	private void OnJump()
	{
		// ジャンプした時の SE をスキップする場合
		if ( IsSkipJumpSe )
		{
			// ジャンプした時の SE は再生しません
			IsSkipJumpSe = false;
		}
		// スキップしない場合
		else
		{
			// ジャンプした時の SE を再生する
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_jumpClip );
		}
	}
}