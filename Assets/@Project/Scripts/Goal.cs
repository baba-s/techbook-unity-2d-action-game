using UnityEngine;

// ゴールを制御するスクリプト
public class Goal : MonoBehaviour
{
	// ゴールした時に再生する SE
	public AudioClip m_goalClip;

	// ゴールしたかどうか
	private bool m_isGoal;

	// 他のオブジェクトと当たった時に呼び出される関数
	private void OnTriggerEnter2D( Collider2D other )
	{
		// まだゴールしておらず
		if ( !m_isGoal )
		{
			// 名前に「Player」が含まれるオブジェクトと当たったら
			if ( other.name.Contains( "Player" ) )
			{
				// シーンに存在する CameraShaker スクリプトを検索する
				var cameraShake = FindObjectOfType<CameraShaker>();

				// CameraShaker を使用してカメラを揺らす
				cameraShake.Shake();

				// 何回もゴールしないように、ゴールしたことを記憶しておく
				m_isGoal = true;

				// ゴールのアニメーターを取得する
				var animator = GetComponent<Animator>();

				// ゴールした時のアニメーションを再生する
				animator.Play( "Pressed" );

				// ゴールした時の SE を再生する
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_goalClip );
			}
		}
	}
}