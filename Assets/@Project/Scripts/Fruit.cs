using UnityEngine;

// フルーツを制御するスクリプト
public class Fruit : MonoBehaviour
{
	// 獲得演出のプレハブ
	public GameObject m_collectedPrefab;

	// フルーツを取った時に再生する SE
	public AudioClip m_collectedClip;

	// 他のオブジェクトと当たった時に呼び出される関数
	private void OnTriggerEnter2D( Collider2D other )
	{
		// 名前に「Player」が含まれるオブジェクトと当たったら
		if ( other.name.Contains( "Player" ) )
		{
			// 獲得演出のオブジェクトを作成する
			var collected = Instantiate
			(
				m_collectedPrefab,
				transform.position,
				Quaternion.identity
			);

			// 獲得演出のオブジェクトからアニメーターの情報を取得する
			var animator = collected.GetComponent<Animator>();

			// 現在再生中のアニメーションの情報を取得する
			var info = animator.GetCurrentAnimatorStateInfo( 0 );

			// 現在再生中のアニメーションの再生時間（秒）を取得する
			var time = info.length;

			// アニメーションの再生が完了したら
			// 獲得演出を削除するように登録する
			Destroy( collected, time );

			// 自分自身を削除する
			Destroy( gameObject );

			// フルーツを取った時の SE を再生する
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_collectedClip );
		}
	}
}