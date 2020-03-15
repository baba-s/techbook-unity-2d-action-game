using System.Collections;
using UnityEngine;

// カメラを揺らすスクリプト
public class CameraShaker : MonoBehaviour
{
	// カメラを揺らす時間（秒）
	public float m_duration = 0.25f;

	// カメラを揺らす強さ
	public float m_magnitude = 0.1f;

	// カメラを揺らす
	public void Shake()
	{
		StartCoroutine( DoShake() );
	}

	// カメラを揺らす処理をコルーチンで実装する関数
	private IEnumerator DoShake()
	{
		// カメラの位置を記憶しておく
		var pos = transform.localPosition;

		// カメラを揺らし始めてからの経過時間
		var elapsed = 0f;

		// まだカメラを揺らす時間内の場合
		while ( elapsed < m_duration )
		{
			// カメラを揺らすために位置をランダムに動かす
			var x = pos.x + Random.Range( -1f, 1f ) * m_magnitude;
			var y = pos.y + Random.Range( -1f, 1f ) * m_magnitude;

			transform.localPosition = new Vector3( x, y, pos.z );

			// カメラを揺らし始めてからの経過時間を進める
			elapsed += Time.deltaTime;

			// このフレームでの処理を一旦中断する
			yield return null;
		}

		// カメラを揺らし終わったら初期位置に戻す
		transform.localPosition = pos;
	}
}