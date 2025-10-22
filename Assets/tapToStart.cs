using UnityEngine;

public class tapToStart : MonoBehaviour
{
    public void tapToLaugh()
    {
        // もし笑い中じゃなかったら
        if(!WaraiDirector.isLaughing)
        {
            // 笑いだす
            WaraiDirector.isLaughing = true;
            WaraiDirector.laughTimes = 4;
        }
    }
}
