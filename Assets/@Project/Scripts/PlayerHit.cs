using UnityEngine;

// プレイヤーのやられアニメーションを制御するスクリプト
public class PlayerHit : MonoBehaviour
{
	// やられアニメーションの移動の速さ
	public Vector3 m_velocity = new Vector3( 0, 15, 0 );

	// やられアニメーションの移動にかかる重力の強さ
	public float m_gravity = 30;

	// 毎フレーム呼び出される関数
	private void Update()
	{
		// やられアニメーションを移動します
		transform.localPosition += m_velocity * Time.deltaTime;

		// 重力を適用してだんだん落下するようにします
		m_velocity.y -= m_gravity * Time.deltaTime;
	}
}