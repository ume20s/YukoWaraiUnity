using UnityEngine;

public class tapToStart : MonoBehaviour
{
    public void tapToLaugh()
    {
        // タップされたら笑いだす
        WaraiDirector.isLaughing = true;
    }
}
