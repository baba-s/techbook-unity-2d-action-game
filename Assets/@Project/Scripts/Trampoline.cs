using UnityEngine;

// トランポリンを制御するスクリプト
public class Trampoline : MonoBehaviour
{
	// プレイヤーをジャンプさせる高さ
	public float m_jumpHeight = 10;

	// 他のオブジェクトと当たった時に呼び出される関数
	private void OnTriggerEnter2D( Collider2D other )
	{
		// 名前に「Player」が含まれるオブジェクトと当たったら
		if ( other.name.Contains( "Player" ) )
		{
			// プレイヤーの操作を制御するスクリプトを取得して
			var motor = other.GetComponent<PlatformerMotor2D>();

			// プレイヤーをジャンプさせる
			motor.ForceJump( m_jumpHeight );

			// トランポリンのアニメーターを取得する
			var animator = GetComponent <Animator >();

			// ジャンプする時のアニメーションを再生する
			animator.Play( "Jump" );
		}
	}
}