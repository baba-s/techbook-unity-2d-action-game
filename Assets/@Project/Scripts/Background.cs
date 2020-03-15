using UnityEngine;

// 背景を制御するスクリプト
public class Background : MonoBehaviour
{
	// 背景がスクロールする速さ
	public Vector2 m_speed;

	// 毎フレーム呼び出される関数
	private void Update()
	{
		// 背景のスプライトを表示する機能を取得する
		var spriteRenderer = GetComponent<SpriteRenderer>();

		// 背景のテクスチャを表示するマテリアルを取得する
		var material = spriteRenderer.material;

		// 背景のテクスチャをスクロールする
		material.mainTextureOffset += m_speed * Time.deltaTime;
	}
}