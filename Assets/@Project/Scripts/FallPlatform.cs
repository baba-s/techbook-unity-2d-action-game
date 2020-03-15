using UnityEngine;

// 落ちる床を制御するスクリプト
public class FallPlatform : MonoBehaviour
{
	// 落ちる速さ
	public float m_speed = 0.3f;

	// プレイヤーが上に乗ったかどうか
	private bool m_isHit;

	// シーンが開始する時に呼び出される関数
	private void Awake()
	{
		// 自分自身の MovingPlatformMotor2D を取得して
		var motor = GetComponent<MovingPlatformMotor2D>();

		// プレイヤーが当たった時に呼び出されるイベントに関数を登録する
		motor.onPlatformerMotorContact += OnContact;
	}

	// プレイヤーが当たった時に呼び出される関数
	private void OnContact( PlatformerMotor2D player )
	{
		// プレイヤーが落下中の場合
		if ( player.IsFalling() )
		{
			// プレイヤーが上に乗ったことにする
			m_isHit = true;
		}
	}

	// 毎フレーム呼び出される関数
	private void Update()
	{
		// プレイヤーが上に乗った場合
		if ( m_isHit )
		{
			// 自分自身の MovingPlatformMotor2D を取得して
			var motor = GetComponent<MovingPlatformMotor2D>();

			// 落下させる
			motor.velocity = Physics2D.gravity * m_speed;
		}
	}
}