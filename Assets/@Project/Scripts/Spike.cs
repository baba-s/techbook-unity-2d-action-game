using UnityEngine;

// 針を制御するスクリプト
public class Spike : MonoBehaviour
{
	// 他のオブジェクトと当たった時に呼び出される関数
	private void OnTriggerEnter2D( Collider2D other )
	{
		// 名前に「Player」が含まれるオブジェクトと当たったら
		if ( other.name.Contains( "Player" ) )
		{
			// プレイヤーから Player スクリプトを取得する
			var player = other.GetComponent<Player>();

			// プレイヤーがやられた時に呼び出す関数を実行する
			player.Dead();
		}
	}
}