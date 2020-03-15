using UnityEngine;

// 動く床を制御するスクリプト
public class MovePlatform : MonoBehaviour
{
	// 動く床の移動距離
	public Vector3 m_distance = new Vector3( 5, 0, 0 );

	// 動く床の移動速度
	public float m_speed = 0.5f;

	// 開始位置
	private Vector3 m_startPosition;

	// 終了位置
	private Vector3 m_endPosition;

	// シーンが開始する時に呼び出される関数
	private void Awake()
	{
		// 現在位置を開始位置として記憶する
		m_startPosition = transform.localPosition;

		// 開始位置と移動距離から終了位置を設定する
		m_endPosition = m_startPosition + m_distance;
	}

	// 毎フレーム呼び出される関数
	private void Update()
	{
		// 現在の位置を計算する
		var t           = Mathf.PingPong( Time.time * m_speed, 1 );
		var newPosition = Vector3.Lerp( m_startPosition, m_endPosition, t );

		// 現在の位置を反映する
		transform.localPosition = newPosition;
	}
}