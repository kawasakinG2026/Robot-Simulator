using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Damage)]
    //弾丸のダメージ
    public float damage = 50f;

    [Header("LifeTime")]
    //弾丸が消えるまでの時間（処理対策）
    public float lifeTime = 5f;

    void Start()
    {
        // 時間経過で自動削除
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // ダメージ処理
        //EnemyesHPのスクリプトを参照（スクリプト名一致必須）
        var target = collision.gameObject.GetComponent<EnemyesHP>();
        if (target != null)
        {
            //弾丸命中時
            target.TakeDamage(damage);
        }

        // 弾を削除
        Destroy(gameObject);
    }
}
