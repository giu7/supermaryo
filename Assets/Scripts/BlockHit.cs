using System.Collections;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject item;
    public Sprite emptyBlock;
    public int maxHits = -1;
    private bool animating;

    private void OnCollisionEnter2D(Collision2D collision) {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player")) {
            if (collision.transform.DotTest(transform, Vector2.up)) {
                Debug.Log("da sotto");
                Hit();
            }
            else if (!spriteRenderer.enabled){
                Debug.Log("da sopra");
                Debug.Log("invisibile");
                //collider.enabled = false;
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision) {
    //     SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    //     BoxCollider2D collider = GetComponent<BoxCollider2D>();

    //     if (collision.gameObject.CompareTag("Player")) {
    //         Debug.Log("trigger enter");
    //         collider.enabled = false;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collision) {
    //     SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    //     BoxCollider2D collider = GetComponent<BoxCollider2D>();
    //     CircleCollider2D circle = GetComponent<CircleCollider2D>();

    //     if (collision.gameObject.CompareTag("Player")) {
    //         Debug.Log("trigger exit");
    //         collider.enabled = true;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision) {
    //     SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    //     BoxCollider2D collider = GetComponent<BoxCollider2D>();

    //     if (collision.gameObject.CompareTag("Player") && !spriteRenderer.enabled){
    //         Debug.Log("exit collision");
    //     }
    //     BoxCollider2D collider = GetComponent<BoxCollider2D>();

    //     if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
    //     {
    //         if (collision.transform.DotTest(transform, Vector2.up)) {
    //             Debug.Log("da sotto");
    //             Hit();
    //         }
    //         else {
    //             Debug.Log("da sopra");
    //             if (!spriteRenderer.enabled){
    //                 Debug.Log("invisibile");
    //                 collider.enabled = false;
    //             }
    //         }
    //     }
    // }

    private void Hit() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //BoxCollider2D collider = GetComponent<BoxCollider2D>();

        spriteRenderer.enabled = true; // show if hidden
        //collider.enabled = true;

        maxHits--;

        if (maxHits == 0) {
            spriteRenderer.sprite = emptyBlock;
        }

        if (item != null) {
            Instantiate(item, transform.position, Quaternion.identity);
        }

        StartCoroutine(Animate());
    }

    private IEnumerator Animate() {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to) {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration) {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }

}
